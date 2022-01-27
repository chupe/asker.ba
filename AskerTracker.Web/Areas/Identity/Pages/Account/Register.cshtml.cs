using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AskerTracker.Domain;
using AskerTracker.Domain.Entities;
using AskerTracker.Domain.Resources.Localization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace AskerTracker.Web.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly IEmailSender _emailSender;
    private readonly ILogger<RegisterModel> _logger;
    private readonly SignInManager<Member> _signInManager;
    private readonly UserManager<Member> _userManager;

    public RegisterModel(
        UserManager<Member> userManager,
        SignInManager<Member> signInManager,
        ILogger<RegisterModel> logger,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _emailSender = emailSender;
    }

    [BindProperty] public InputModel Input { get; set; }

    [BindProperty(SupportsGet = true)] public string ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    public async Task OnGetAsync(string returnUrl = null)
    {
        ReturnUrl = returnUrl;
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (ModelState.IsValid)
        {
            var user = new Member {
                UserName = Input.Email,
                Email = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                PhoneNumber = Input.PhoneNumber,
                JMBG = Input.JMBG
            };
            var result = await _userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    null,
                    new {area = "Identity", userId = user.Id, code, returnUrl},
                    Request.Scheme);

                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    return RedirectToPage("RegisterConfirmation", new {email = Input.Email, returnUrl});

                await _signInManager.SignInAsync(user, false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "Length3to20",
            MinimumLength = 3)]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(LastName))]
        public string LastName { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(ResourceType = typeof(UILocalization), Name = nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }
        
        private string jmbg;

        [Required]
        [StringLength(13, ErrorMessageResourceType = typeof(UILocalization),
            ErrorMessageResourceName = "PersonalIdMinLengthIs13", MinimumLength = 13)]
        public string JMBG
        {
            get => jmbg;
            set
            {
                if (value.Length != 13)
                    throw new Exception("Unique identifier (JMBG) needs to have 13 digit value");
                jmbg = value;
            }
        }
    }
}