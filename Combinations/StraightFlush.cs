using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class StraightFlush : BaseCombinationAnalyzer
    {
        public StraightFlush(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {

        }

        public override void Check(int[] hand, UsersProperties user)
        {
            foreach (var array in CombinedArrays)
            {
                Array.Sort(array);
            }
            foreach (var t in CombinedArrays.Where(t => t.Length >= 5).Where(t => t[0] + 4 == t[4]))
            {
                UpdateHand(user, Hand.Combinations.StraightFlush, t.Max() / 4);
            }
        }
    }
}
