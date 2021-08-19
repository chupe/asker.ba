using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AskerTracker.Resources.Localization;
using AskerTracker.Types;
using Microsoft.AspNetCore.Http;

namespace AskerTracker.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
