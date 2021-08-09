using System;
using System.ComponentModel.DataAnnotations;

using Asker.Resources.Localization;


namespace Asker.Models
{
    public class TestingResults : BaseModel
    {
        public TestingResults() : base() { }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(EventId))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "EventRequired")]
        public Guid EventId { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(DateHeld))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "DateRequired")]
        [DataType(DataType.Date)]
        public DateTime DateHeld { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(TotalScore))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int TotalScore { get; private set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(MaximumDeadliftWeight))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int MaximumDeadliftWeight { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(StandingPowerThrow))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public float StandingPowerThrow { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(HandReleasePushup))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public float HandReleasePushup { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(SprintDragCarry))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public float SprintDragCarry { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(LegTuck))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public float LegTuck { get; set; }


        [Display(ResourceType = typeof(UILocalization), Name = nameof(TwoMileRun))]

        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public TimeSpan TwoMileRun { get; set; }

        public int CalculateTotal()
        {
            return 0;
        }

        public int CalculateExercisePts()
        {
            return 60;
        }
    }
}
