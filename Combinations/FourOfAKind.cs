using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class FourOfAKind : BaseCombinationAnalyzer
    {
        public FourOfAKind(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {

        }
        public override void Check(int[] hand, UsersProperties user)
        {
            for (int j = 0; j <= 3; j++)
            {
                if (Straight[j] / 4 == Straight[j + 1] / 4 && Straight[j] / 4 == Straight[j + 2] / 4 &&
                    Straight[j] / 4 == Straight[j + 3] / 4)
                {
                    UpdateHand(user, Hand.Combinations.FourOfAKind, Straight[j] / 4 * 4);
                }
                if (Straight[j] / 4 != (int)Cards.CardTypes.Ace || Straight[j + 1] / 4 != (int)Cards.CardTypes.Ace ||
                    Straight[j + 2] / 4 != (int)Cards.CardTypes.Ace || Straight[j + 3] / 4 != (int)Cards.CardTypes.Ace)
                    continue;
                UpdateHand(user, Hand.Combinations.FourOfAKind, 13 * 4);
            }
        }
    }
}
