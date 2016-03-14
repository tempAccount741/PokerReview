using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class ThreeOfAKind : BaseCombinationAnalyzer
    {
        public ThreeOfAKind(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            for (int j = 0; j <= 12; j++)
            {
                int[] fh = Straight.Where(o => o / 4 == j).ToArray();
                if (fh.Length != 3) continue;

                var tempT = fh.Max()/4 == (int) Cards.CardTypes.Ace ? 13 : fh.Max()/4;

                //left card != rightcard ne sa v otedelen if poneje namalqm nesting
                if (LeftCard != RightCard && LeftCard == tempT)
                {
                    UpdateHand(user, Hand.Combinations.ThreeOfAKind, LeftCard * 6 + RightCard / 4);
                }
                else if (LeftCard != RightCard && RightCard == tempT)
                {
                    UpdateHand(user, Hand.Combinations.ThreeOfAKind, RightCard * 6 + LeftCard / 4);
                }
                else if (LeftCard == RightCard && LeftCard == tempT)
                {
                    UpdateHand(user, Hand.Combinations.ThreeOfAKind, RightCard * 6);
                }
                if (LeftCard == tempT || RightCard == tempT) continue;
                UpdateHand(user, Hand.Combinations.ThreeOfAKind, tempT * 6 + Kicker / 4);
            }
        }
    }
}
