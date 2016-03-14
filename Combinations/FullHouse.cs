using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class FullHouse : BaseCombinationAnalyzer
    {
        public FullHouse(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            for (int j = (int)Cards.CardTypes.Ace; j <= (int)Cards.CardTypes.King * 4; j++)
            {
                int two = -1;
                int counterForThree = Straight.Count(rep => rep / 4 == j / 4);
                if (counterForThree == 3)
                {
                    for (int k = (int)Cards.CardTypes.Ace; k <= (int)Cards.CardTypes.King * 4; k++)
                    {
                        if (k / 4 == j / 4) continue;
                        int counterForTwo = Straight.Count(rep => rep / 4 == k / 4);
                        if (counterForTwo != 2 || k / 4 == two) continue;
                        two = k / 4;
                        if (j == 0)
                        {
                            UpdateHand(user, Hand.Combinations.FullHouse, 13 * 3 + (k / 4) * 2);
                        }
                        if (k != 0) continue;
                        UpdateHand(user, Hand.Combinations.FullHouse, j / 4 * 3 + 13 * 2);
                    }
                }
            }
        }
    }
}
