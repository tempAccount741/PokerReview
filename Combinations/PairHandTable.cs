using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class PairHandTable : BaseCombinationAnalyzer
    {
        public PairHandTable(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            for (int tc = 16; tc >= 12; tc--)
            {
                var tempTable1 = hand[tc]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[tc]/4;

                if (RightCard == tempTable1)
                {
                    UpdateHand(user, Hand.Combinations.Pair, RightCard * 6 + LeftCard / 6);
                }
                else if (LeftCard == tempTable1)
                {
                    UpdateHand(user, Hand.Combinations.Pair, LeftCard * 6 + RightCard / 6);
                }
            }
        }
    }
}
