using System.Collections.Generic;
using Poker.Users;

namespace Poker.Combinations
{
    public class TwoPairTwoDifferent : BaseCombinationAnalyzer
    {
        public TwoPairTwoDifferent(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
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

                    if (RightCard != LeftCard && (RightCard == tempTable1 && LeftCard == tempTable2))
                    {
                        UpdateHand(user, Hand.Combinations.TwoPair, SumOfHands);
                    }
                }
            }
        }
    }
}
