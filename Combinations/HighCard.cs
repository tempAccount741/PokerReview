using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class HighCard : BaseCombinationAnalyzer
    {
        public HighCard(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {
        }

        public override void Check(int[] hand, UsersProperties user)
        {
            if (user.Type != -1) return;
            user.Type = (int)Hand.Combinations.HighCard;
            user.Power = Kicker;
            MainPoker.Win.Add(new Hand { Power = user.Power, Current = user.Type });
        }
    }
}
