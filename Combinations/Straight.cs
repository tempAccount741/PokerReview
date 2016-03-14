using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class Straight : BaseCombinationAnalyzer
    {
        public Straight(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            int[] tStr = Straight.Select(o => o / 4).Distinct().ToArray();
            for (int j = 0; j < tStr.Length - 4; j++)
            {
                if (tStr[j] + 1 == tStr[j + 1] && tStr[j] + 2 == tStr[j + 2] && tStr[j] + 3 == tStr[j + 3] && tStr[j] + 4 == tStr[j + 4])
                {
                    UpdateHand(user, Hand.Combinations.Straight, tStr.Max() - 4 == tStr[j] ? tStr.Max() : tStr[j + 4]);
                }
                if (tStr[j] != (int)Cards.CardTypes.Ace || tStr[j + 1] != (int)Cards.CardTypes.Ten ||
                    tStr[j + 2] != (int)Cards.CardTypes.Jack || tStr[j + 3] != (int)Cards.CardTypes.Queen ||
                    tStr[j + 4] != (int)Cards.CardTypes.King) continue;

                UpdateHand(user, Hand.Combinations.Straight, 13);
            }
        }
    }
}
