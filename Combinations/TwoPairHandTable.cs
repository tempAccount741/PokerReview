using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class TwoPairHandTable : BaseCombinationAnalyzer
    {
        public TwoPairHandTable(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
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
                    var tempTable2 = hand[tc - k]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[tc - k]/4;

                    if (tc - k < 12)
                    {
                        max--;
                    }
                    if (tc - k < 12) continue;
                    if (RightCard == LeftCard || tempTable1 != tempTable2) continue;
                    for (int k1 = 16; k1 >= 12; k1--)
                    {
                        var tempTable3 = hand[k1]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[k1]/4;

                        if (LeftCard == tempTable3 && LeftCard != tempTable1)
                        {
                            UpdateHand(user, Hand.Combinations.TwoPair, LeftCard + tempTable1);
                        }
                        if (RightCard != tempTable3 || RightCard == tempTable1) continue;
                        UpdateHand(user, Hand.Combinations.TwoPair, RightCard + tempTable1);
                    }
                }
            }
        }
    }
}
