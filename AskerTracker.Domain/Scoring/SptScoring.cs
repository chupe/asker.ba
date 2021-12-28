namespace AskerTracker.Domain.Scoring
{
    public static class SptScoring
    {
        public static int GetScore(double count)
        {
            var scoringTable = ScoringTable.SptScoringTable;

            double temp = 0;
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