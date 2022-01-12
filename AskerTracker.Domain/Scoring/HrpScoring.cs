namespace AskerTracker.Domain.Scoring;

public static class HrpScoring
{
    public static int GetScore(int count)
    {
        var scoringTable = ScoringTable.HrpScoringTable;

        var temp = 0;
        foreach (var key in scoringTable.Keys)
            if (key <= count)
                temp = key;
            else
                break;

        scoringTable.TryGetValue(temp, out var value);
        return value;
    }
}