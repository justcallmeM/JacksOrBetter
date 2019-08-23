namespace Library.Utilities
{
    public interface IScorer
    {
        int AssignScore(Scorer.Combination combination);
        int CalculateScore(Deck deck);
    }
}