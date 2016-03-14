using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class PairInHand : BaseCombinationAnalyzer
    {
        public PairInHand(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            if (RightCard != LeftCard) return;
            UpdateHand(user, Hand.Combinations.Pair, Kicker);
        }
    }
}
