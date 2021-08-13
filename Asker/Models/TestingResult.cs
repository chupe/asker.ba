using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Asker.Models.Scoring;
using Asker.Resources.Localization;


namespace Asker.Models
{
    public class TestingResult : EntityModel
    {
        public TestingResult() : base() { }

        [ForeignKey("Event")]
        public Guid EventId { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Event))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "EventRequired")]
        public TestingEvent Event { get; set; }

        private Member member;

        [ForeignKey("Member")]
        public Guid MemberId { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(Member))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "MemberRequired")]
        public Member Member { 
            get => member; 
            set 
            {
                if (!Event.Participants.List.Contains(value.Id))
                    throw new Exception("Member not found in the list of event participants");
                else
                    member = value;
            }
        }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(TotalScore))]
        public int TotalScore { get => CalculateTotal(); private set { } }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(TotalScore))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int WeakestDisciplinePoints {
            get
            {
                var disciplines = new List<int>() {
                    mdlPoints,
                    sptPoints,
                    hrpPoints,
                    sdcPoints,
                    ltkPoints,
                    tmrPoints
                };

                return disciplines.Min();
            }
        }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(MaximumDeadliftWeight))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int MaximumDeadliftWeight { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(StandingPowerThrow))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public double StandingPowerThrow { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(HandReleasePushup))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int HandReleasePushup { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(SprintDragCarry))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public TimeSpan SprintDragCarry { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(LegTuck))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public int LegTuck { get; set; }

        [Display(ResourceType = typeof(UILocalization), Name = nameof(TwoMileRun))]
        [Required(ErrorMessageResourceType = typeof(UILocalization), ErrorMessageResourceName = "ScoreRequired")]
        public TimeSpan TwoMileRun { get; set; }

        [ScaffoldColumn(false)]
        private int mdlPoints;

        [ScaffoldColumn(false)]
        private int sptPoints;

        [ScaffoldColumn(false)]
        private int hrpPoints;

        [ScaffoldColumn(false)]
        private int sdcPoints;

        [ScaffoldColumn(false)]
        private int ltkPoints;

        [ScaffoldColumn(false)]
        private int tmrPoints;
        
        public int CalculateTotal()
        {
            CalculatePoints();
            TotalScore = mdlPoints + sptPoints + hrpPoints + sdcPoints + ltkPoints + tmrPoints;

            return TotalScore;
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
