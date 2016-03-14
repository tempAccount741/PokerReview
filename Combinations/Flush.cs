using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{
    public class Flush : BaseCombinationAnalyzer
    {
        public Flush(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {

        }

        public override void Check(int[] hand, UsersProperties user)
        {
            int[] currentColors = { -1, -1, -1, -1, -1 };
            int maxColor;

            int[] f1 = Straight.Skip(2).Where(o => o % 4 == (int)Cards.CardSuits.Club).ToArray();
            int[] f2 = Straight.Skip(2).Where(o => o % 4 == (int)Cards.CardSuits.Diamond).ToArray();
            int[] f3 = Straight.Skip(2).Where(o => o % 4 == (int)Cards.CardSuits.Heart).ToArray();
            int[] f4 = Straight.Skip(2).Where(o => o % 4 == (int)Cards.CardSuits.Spade).ToArray();

            int correct3 = Array.IndexOf(new[] { f1.Length == 3, f2.Length == 3, f3.Length == 3, f4.Length == 3 }, true);
            int correct4 = Array.IndexOf(new[] { f1.Length == 4, f2.Length == 4, f3.Length == 4, f4.Length == 4 }, true);
            int correct5 = Array.IndexOf(new [] { f1.Length == 5, f2.Length == 5, f3.Length == 5, f4.Length == 5 }, true);

            List<int[]> places = new List<int[]> { f1, f2, f3, f4 };

            for (int j = 0; j < places.ToArray().Length; j++)
            {
                if (correct3 != j && correct4 != j && correct5 != j) continue;
                currentColors = places[j];
                break;
            }

            if (hand[user.RightCard] % 4 == hand[user.LeftCard] % 4)
            {
                maxColor = hand[user.RightCard]/4 > hand[user.LeftCard]/4
                    ? (hand[user.LeftCard]/4 == (int) Cards.CardTypes.Ace ? hand[user.LeftCard] : hand[user.RightCard])
                    : hand[user.LeftCard];
            }
            else
            {
                if (hand[user.RightCard] % 4 == currentColors[0] % 4)
                {
                    maxColor = hand[user.RightCard];
                }
                else if (hand[user.LeftCard] % 4 == currentColors[0] % 4)
                {
                    maxColor = hand[user.LeftCard];
                }
                else
                {
                    maxColor = -1;
                }
            }
            if (maxColor == -1) return;
            if (currentColors.Length == 3)
            {
                if (hand[user.RightCard] % 4 == hand[user.LeftCard] % 4 && hand[user.RightCard] % 4 == currentColors[0] % 4)
                {
                    var tempPower = hand[user.RightCard]/4 > hand[user.LeftCard]/4
                        ? hand[user.RightCard]/4
                        : hand[user.LeftCard]/4;
                    UpdateHand(user, Hand.Combinations.Flush, tempPower);
                }
            }
            if (currentColors.Length == 4 && maxColor%4 == currentColors[0]%4)
            {
                UpdateHand(user, Hand.Combinations.Flush, maxColor == (int) Cards.CardTypes.Ace ? 13 : maxColor);
            }
            if (currentColors.Length != 5 || currentColors.Max() <= 0 || maxColor % 4 != currentColors[0] % 4)
                return;
            if (currentColors[0] / 4 == (int)Cards.CardTypes.Ace && maxColor / 4 > currentColors[1] / 4)
            {
                UpdateHand(user, Hand.Combinations.Flush, maxColor == (int)Cards.CardTypes.Ace ? 13 : maxColor);
            }
            else if (currentColors[0] / 4 < maxColor / 4)
            {
                UpdateHand(user, Hand.Combinations.Flush, maxColor == (int)Cards.CardTypes.Ace ? 13 : maxColor);
            }
        }
    }
}
