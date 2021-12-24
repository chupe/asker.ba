using System;

namespace AskerTracker.Core.Scoring
{
    public class TmrScoring
    {
        public static int GetScore(TimeSpan count)
        {
            var scoringTable = ScoringTable.TmrScoringTable;

            var temp = new TimeSpan(0, 22, 48);
            foreach (var key in scoringTable.Keys)
                if (key <= count)
                {
                    temp = key;
                }
                else
                {
                    break;
                }

            scoringTable.TryGetValue(temp, out var value);
            return value;
        }
    }
}