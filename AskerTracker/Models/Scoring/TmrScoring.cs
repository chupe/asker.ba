using System;

namespace AskerTracker.Models.Scoring
{
    public class TmrScoring
    {
        public TmrScoring() : base() { }

        public static int GetScore(TimeSpan count)
        {
            var scoringTable = ScoringTable.TmrScoringTable;

            TimeSpan temp = new TimeSpan(0, 22, 48);
            foreach (var key in scoringTable.Keys)
            {
                if (key <= count)
                {
                    temp = key;
                    continue;
                }
                else
                    break;
            }

            scoringTable.TryGetValue(temp, out int value);
            return value;
        }
    }
}
