namespace Asker.Models.Scoring
{
    public class MdlScoring
    {
        public static int GetScore(int count)
        {
            var scoringTable = ScoringTable.MdlScoringTable;

            int temp = 0;
            foreach (var key in scoringTable.Keys)
            {
                if (key < count)
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
