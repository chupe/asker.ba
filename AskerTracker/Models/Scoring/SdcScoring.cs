using System;

namespace AskerTracker.Models.Scoring
{
    public class SdcScoring
    {
        public static int GetScore(TimeSpan count)
        {
            var scoringTable = ScoringTable.SdcScoringTable;

            TimeSpan temp = new TimeSpan(0, 3, 35);
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
