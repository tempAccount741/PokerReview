using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class TwoPairFromTable : BaseCombinationAnalyzer
    {
        public TwoPairFromTable(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            for (int tc = 16; tc >= 12; tc--)
            {
                var tempTable1 = hand[tc]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[tc]/4;
                for (int tc1 = 16; tc1 >= 12; tc1--)
                {
                    var tempTable2 = hand[tc1]/4 == (int) Cards.CardTypes.Ace ? 13 : hand[tc1]/4;
                    int max = tc - 12;
                    int max1 = tc1 - 12;
                    for (int k = 1; k <= max; k++)
                    {
                        if (tc - k <= 12) continue;
                        for (int k1 = 1; k1 <= max1; k1++)
                        {
                            if (tc - k < 12)
                            {
                                max--;
                            }
                            if (tc1 - k1 < 12)
                            {
                                max1--;
                            }
                            if (tc - k < 12) continue;
                            if (tc1 - k1 < 12) continue;

                            if (tempTable1 != hand[tc - k] / 4 || tempTable2 != hand[tc1 - k1] / 4 ||
                                tempTable1 == tempTable2) continue;
                            UpdateHand(user, Hand.Combinations.TwoPair, tempTable1 + tempTable2);
                        }
                    }
                }
            }
        }
    }
}
