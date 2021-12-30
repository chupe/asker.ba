namespace AskerTracker.Domain.Scoring
{
    public static class MdlScoring
    {
        public static int GetScore(int count)
        {
            var scoringTable = ScoringTable.MdlScoringTable;

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
}