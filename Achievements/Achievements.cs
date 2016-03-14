using System;

namespace Poker.Achievements
{
    public static class Achievements
    {
        public static Classic Classic = new Classic();
        public static RoyalFlush RoyalFlush = new RoyalFlush(1, new Tuple<string, int?>("Royal Card Pack", 100000));

        public static StraightFlush StraightFlush = new StraightFlush(1,
            new Tuple<string, int?>("Bicycle Card Back", 50000));

        public static FourOfAKind FourOfAKind = new FourOfAKind(1, new Tuple<string, int?>("Angel Card Back", 35000));
        public static FullHouse FullHouse = new FullHouse(3, new Tuple<string, int?>("Awesome Card Back", 30000));
        public static Flush Flush = new Flush(5, new Tuple<string, int?>("Water Card Back", 20000));
        public static Straight Straight = new Straight(5, new Tuple<string, int?>("Twisted Card Back", 15000));
        public static MoneyFirst MoneyFirst = new MoneyFirst(500000, new Tuple<string, int?>("Rich Card Back", null));

        public static MoneySecond MoneySecond = new MoneySecond(2000000,
            new Tuple<string, int?>("Mansion Card Back", null));

        public static PlayedHands PlayedHands = new PlayedHands(100, new Tuple<string, int?>("Blue Card Pack", null));
    }
}
