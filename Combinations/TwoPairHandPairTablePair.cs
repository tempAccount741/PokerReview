using Poker.Users;

namespace Poker.Combinations
{
    public class TwoPairHandPairTablePair : BaseCombinationAnalyzer
    {
        public TwoPairHandPairTablePair(UsersProperties user, int[] hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            for (int tc = 16; tc >= 12; tc--)
            {
                var tempTable1 = hand[tc]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[tc]/4;
                int max = tc - 12;
                for (int k = 1; k <= max; k++)
                {
                    if (tc - k < 12)
                    {
                        max--;
                    }
                    if (tc - k < 12) continue;
                    if (RightCard != LeftCard) continue;
                    if (tempTable1 != hand[tc - k] / 4 || tempTable1 == Kicker) continue;
                    UpdateHand(user, Hand.Combinations.TwoPair, Kicker + tempTable1);
                }
            }
        }
    }
}
