namespace Poker
{
    public class Hand
    {
        public enum Combinations
        {
            Default = -1,
            HighCard = -1,
            PairTable = 0,
            Pair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourOfAKind = 7,
            StraightFlush = 8,
            RoyalFlush = 9
        }
        public double Power { get; set; }
        public int Current { get; set; }
    }
}
