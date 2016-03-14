using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class RoyalFlush : BaseCombinationAnalyzer
    {
        public RoyalFlush(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            foreach (
                var t in
                    CombinedArrays.Where(t => t.Length >= 5)
                        .Where(
                            t =>
                                t.Contains((int) Cards.CardTypes.Ace) && t.Contains((int) Cards.CardTypes.Ten) &&
                                t.Contains((int) Cards.CardTypes.Jack) && t.Contains((int) Cards.CardTypes.Queen) &&
                                t.Contains((int) Cards.CardTypes.King)))
            {
                UpdateHand(user, Hand.Combinations.RoyalFlush, t.Max() / 4);
            }
        }
    }
}
