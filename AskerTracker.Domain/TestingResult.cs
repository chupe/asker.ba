using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AskerTracker.Core.BaseModels;
using AskerTracker.Core.Scoring;

namespace AskerTracker.Core
{
    public class TestingResult : EntityModel
    {
        [ScaffoldColumn(false)] private int? hrpPoints;

        [ScaffoldColumn(false)] private int? ltkPoints;

        [ScaffoldColumn(false)] private int? mdlPoints;

        private Member member;

        [ScaffoldColumn(false)] private int? sdcPoints;

        [ScaffoldColumn(false)] private int? sptPoints;

        [ScaffoldColumn(false)] private int? tmrPoints;

        [ForeignKey("Event")] public Guid EventId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Event))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "EventRequired")]
        public TestingEvent Event { get; set; }

        [ForeignKey("Member")] public Guid MemberId { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Member Member
        {
            get => member;
            set
            {
                if (!Event.Participants.Contains(value))
                    throw new Exception("Member not found in the list of event participants");
                member = value;
            }
        }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TotalScore))]
        public int TotalScore
        {
            get => CalculateTotal();
            private set { }
        }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TotalScore))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int WeakestDisciplinePoints
        {
            get
            {
                var disciplines = new List<int>
                {
                    mdlPoints.GetValueOrDefault(),
                    sptPoints.GetValueOrDefault(),
                    hrpPoints.GetValueOrDefault(),
                    sdcPoints.GetValueOrDefault(),
                    ltkPoints.GetValueOrDefault(),
                    tmrPoints.GetValueOrDefault()
                };

                return disciplines.Min();
            }
        }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(MaximumDeadliftWeight))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int MaximumDeadliftWeight { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(StandingPowerThrow))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public double StandingPowerThrow { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(HandReleasePushup))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int HandReleasePushup { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(SprintDragCarry))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public TimeSpan SprintDragCarry { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(LegTuck))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int LegTuck { get; set; }

        // [Display(ResourceType = typeof(UILocalization), Name = nameof(TwoMileRun))]
        [Required] // [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public TimeSpan TwoMileRun { get; set; }

        public List<int?> GetPoints()
        {
            return new List<int?>
            {
                mdlPoints,
                sptPoints,
                hrpPoints,
                sdcPoints,
                ltkPoints,
                tmrPoints
            };
        }

        public int CalculateTotal()
        {
            foreach (var pts in GetPoints())
                if (!pts.HasValue)
                {
                    CalculatePoints();
                    break;
                }

            var total = 0;
            foreach (var pts in GetPoints()) total += pts.GetValueOrDefault();

            return total;
        }

        public void CalculatePoints()
        {
            mdlPoints = MdlScoring.GetScore(MaximumDeadliftWeight);
            sptPoints = SptScoring.GetScore(StandingPowerThrow);
            hrpPoints = HrpScoring.GetScore(HandReleasePushup);
            sdcPoints = SdcScoring.GetScore(SprintDragCarry);
            ltkPoints = LtkScoring.GetScore(LegTuck);
            tmrPoints = TmrScoring.GetScore(TwoMileRun);
        }
    }
}