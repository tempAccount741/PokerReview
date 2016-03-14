using System.Collections.Generic;
using System.Linq;
using Poker.Users;

namespace Poker.Combinations
{

    public interface ICombination
    {
        void Check(int[] hand, UsersProperties user);
        void UpdateHand(UsersProperties user, Hand.Combinations combinationType, int power);
    }

    public abstract class BaseCombinationAnalyzer : CardVariables, ICombination
    {
        public abstract void Check(int[] hand, UsersProperties user);

        public void UpdateHand(UsersProperties user, Hand.Combinations combinationType, int power)
        {
            user.Type = (int)combinationType;
            user.Power = power + user.Type * 100;
            MainPoker.Win.Add(new Hand { Power = user.Power, Current = user.Type });
        }

        protected BaseCombinationAnalyzer(UsersProperties user, IReadOnlyList<int> hand) : base(user, hand)
        {

        }
    }

    public class CardVariables
    {
        public int Kicker { get; set; }
        public int RightCard { get; set; }
        public int LeftCard { get; set; }
        public int SumOfHands { get; set; }
        public int[] Straight { get; set; } = new int[7];
        public int[] Clubs { get; set; }
        public int[] Diamonds { get; set; }
        public int[] Hearts { get; set; }
        public int[] Spades { get; set; }
        public int[] ClubsDistincted { get; set; }
        public int[] DiamondsDistincted { get; set; }
        public int[] HeartsDistincted { get; set; }
        public int[] SpadesDistincted { get; set; }
        public int[][] CombinedArrays { get; set; }

        private static int[] SeparateSuits( IEnumerable<int> deckCards,Cards.CardSuits cardSuit)
        {
            return  deckCards.Where(card => card%4 == (int) cardSuit).ToArray();
        }

        private static int[] SeparateCardTypes(IEnumerable<int> deckCards)
        {
            return deckCards.Select(card => card / 4).Distinct().ToArray();
        }
        public CardVariables(UsersProperties user, IReadOnlyList<int> hand)
        {
            var k = (int)MainPoker.TableCards.FirstCard;
            Straight[0] = hand[user.RightCard];
            Straight[1] = hand[user.LeftCard];
            for (int j = 2; j < Straight.Length; j++)
            {
                Straight[j] = hand[k];
                k++;
            }
            Clubs = SeparateSuits(Straight, Cards.CardSuits.Club);
            Diamonds = SeparateSuits(Straight, Cards.CardSuits.Diamond);
            Hearts = SeparateSuits(Straight, Cards.CardSuits.Heart);
            Spades = SeparateSuits(Straight, Cards.CardSuits.Spade);
            ClubsDistincted = SeparateCardTypes(Clubs);
            DiamondsDistincted = SeparateCardTypes(Diamonds);
            HeartsDistincted = SeparateCardTypes(Hearts);
            SpadesDistincted = SeparateCardTypes(Spades);
            CombinedArrays = new[] {ClubsDistincted, DiamondsDistincted, HeartsDistincted, SpadesDistincted};

            bool handContainsAce =
                !(hand[user.RightCard]/4 != (int) Cards.CardTypes.Ace &&
                  hand[user.LeftCard]/4 != (int) Cards.CardTypes.Ace);

            bool rightCardIsAce = hand[user.RightCard]/4 == (int) Cards.CardTypes.Ace;
            bool leftCardIsAce = hand[user.LeftCard] / 4 == (int)Cards.CardTypes.Ace;

            Kicker = !handContainsAce
                ? (hand[user.RightCard]/4 > hand[user.LeftCard]/4 ? hand[user.RightCard]/4 : hand[user.LeftCard]/4)
                : 13;
            RightCard = rightCardIsAce ? 13 : hand[user.RightCard]/4;
            LeftCard = leftCardIsAce ? 13 : hand[user.LeftCard]/4;
            SumOfHands = RightCard + LeftCard;

        }
    }
}
