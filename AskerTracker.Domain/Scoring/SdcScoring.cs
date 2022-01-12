using System;

namespace AskerTracker.Domain.Scoring;

public static class SdcScoring
{
    public static int GetScore(TimeSpan count)
    {
        var scoringTable = ScoringTable.SdcScoringTable;

        var temp = new TimeSpan(0, 3, 35);
        foreach (var key in scoringTable.Keys)
            if (key <= count)
                temp = key;
            else
                break;

        scoringTable.TryGetValue(temp, out var value);
        return value;
    }
}