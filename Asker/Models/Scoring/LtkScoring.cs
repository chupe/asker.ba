namespace Asker.Models.Scoring
{
    public class LtkScoring
    {
        public static int GetScore(int count)
        {
            var scoringTable = ScoringTable.LtkScoringTable;

            int temp = 0;
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
