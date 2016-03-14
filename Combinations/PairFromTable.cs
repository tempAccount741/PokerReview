using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class PairFromTable : BaseCombinationAnalyzer
    {
        public PairFromTable(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            if (user.Type != -1) return;
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
                    if (tempTable1 != tempTable2) continue;
                    UpdateHand(user, Hand.Combinations.PairTable, tempTable1 + Kicker / 6);
                }
            }
        }
    }
}
