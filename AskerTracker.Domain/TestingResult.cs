using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AskerTracker.Domain.BaseModels;
using AskerTracker.Domain.Scoring;

namespace AskerTracker.Domain;

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

    [Required] public TestingEvent Event { get; set; }

    [ForeignKey("Member")] public Guid MemberId { get; set; }

    [Required]
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

    public int TotalScore
    {
        get => CalculateTotal();
        private set { }
    }

    [Required]
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

    [Required] public int MaximumDeadliftWeight { get; set; }

    [Required] public double StandingPowerThrow { get; set; }

    [Required] public int HandReleasePushup { get; set; }

    [Required] public TimeSpan SprintDragCarry { get; set; }

    [Required] public int LegTuck { get; set; }

    [Required] public TimeSpan TwoMileRun { get; set; }

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