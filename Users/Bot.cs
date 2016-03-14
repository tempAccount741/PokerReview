using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Users
{
    public class Bot : UsersProperties
    {
        public int[] MaxRaise { get; } = new int[2];
        public static int PotText { get; set; } = MainPoker.Sb + MainPoker.Bb;
        public RngCrypto Random { get; } = new RngCrypto();

        public Bot(AnchorStyles style, string name, int rightCard, int enumCasted, Point cardsLocation, bool down, Tuple<int, int> maxRaise)
        {
            RightCard = rightCard;
            LeftCard = RightCard + 1;
            Name = name;
            Chips = 10000;
            Type = -1;
            Power = 0;
            Turn = false;
            FoldTurn = false;
            CardsAnchor = style;
            PreviousCall = 0;
            EnumCasted = enumCasted;
            CardsLocation = cardsLocation;
            UsernameLabelLocation = down ? new Point(CardsLocation.X, CardsLocation.Y - 20) : new Point(CardsLocation.X, CardsLocation.Y + Settings.Height);
            PanelLocation = new Point(CardsLocation.X - IndentationPanelXy, CardsLocation.Y - IndentationPanelXy);
            MaxRaise[0] = RoundN(maxRaise.Item1, maxRaise.Item2, 1000);
            MaxRaise[1] = RoundN(Chips, maxRaise.Item2, 1000);
        }
        public Bot(int? chips, AnchorStyles style, string name, int rightCard, int enumCasted, Point cardsLocation, bool down, Tuple<int?, int> maxRaise)
        {
            RightCard = rightCard;
            LeftCard = RightCard + 1;
            Name = name;
            Chips = chips;
            Type = -1;
            Power = 0;
            Turn = false;
            FoldTurn = false;
            CardsAnchor = style;
            PreviousCall = 0;
            EnumCasted = enumCasted;
            CardsLocation = cardsLocation;
            UsernameLabelLocation = down ? new Point(CardsLocation.X, CardsLocation.Y - 20) : new Point(CardsLocation.X, CardsLocation.Y + Settings.Height);
            PanelLocation = new Point(CardsLocation.X - IndentationPanelXy, CardsLocation.Y - IndentationPanelXy);
            MaxRaise[0] = RoundN(maxRaise.Item1, maxRaise.Item2, 1000);
            MaxRaise[1] = RoundN(Chips, maxRaise.Item2, 1000);
        }

        private static int RoundN(int? sChips, int n, double roundUpTo)
        {
            double a = Math.Round((double)sChips / n / roundUpTo, 0) * roundUpTo;
            return (int)a;
        }

        public Bot HighCard(Bot user, ref int previous)
        {
            user = Hp(user, 20, 25, ref previous);
            return user;
        }
        public Bot PairHand(Bot user, ref int previous)
        {
            int rCall = Random.Next(13, 19);
            if (user.Power <= 199 && user.Power >= 140)
            {
                user = Ph(user, rCall, 6, ref previous);
            }
            if (user.Power <= 139 && user.Power >= 128)
            {
                user = Ph(user, rCall, 7, ref previous);
            }
            if (user.Power < 128 && user.Power >= 100)
            {
                user = Ph(user, rCall, 9, ref previous);
            }
            return user;
        }
        public Bot TwoPair(Bot user, ref int previous)
        {
            int rCallandRaise = Random.Next(8, 13);
            if (user.Power <= 299 && user.Power >= 246)
            {
                user = Ph(user, rCallandRaise, 4, ref previous);
            }
            if (user.Power <= 244 && user.Power >= 201)
            {
                user = Ph(user, rCallandRaise, 5, ref previous);
            }
            return user;
        }
        public Bot ThreeOfAKind(Bot user, ref int previous)
        {
            int tCall = Random.Next(4, 11);
            user = Smooth(user, tCall, ref previous);
            return user;
        }
        public Bot Straight(Bot user, ref int previous)
        {
            int sCall = Random.Next(3, 8);
            user = Smooth(user, sCall, ref previous);
            return user;
        }
        public Bot Flush(Bot user, ref int previous)
        {
            int fCall = Random.Next(2, 6);
            user = Smooth(user, fCall, ref previous);
            return user;
        }
        public Bot FullHouse(Bot user, ref int previous)
        {
            int fhCall = Random.Next(1, 5);
            user = Smooth(user, fhCall, ref previous);
            return user;
        }
        public Bot FourOfAKind(Bot user, ref int previous)
        {
            int fkCall = Random.Next(1, 4);
            user = Smooth(user, fkCall, ref previous);
            return user;
        }
        public Bot StraightFlush(Bot user, ref int previous)
        {
            int sfCall = Random.Next(1, 3);
            user = Smooth(user, sfCall, ref previous);
            return user;
        }

        public Bot Fold(Bot user)
        {
            MainPoker.Raising = false;
            user.StatusLabel.Text = @"Fold";
            user.ChipsTextBox.Text = @"Chips : " + user.Chips;
            user.Turn = false;
            user.FoldTurn = true;
            user = (Bot)MainPoker.GetStatus(user);
            return user;
        }
        public Bot Check(Bot user, out int previous)
        {
            user.StatusLabel.Text = @"Check";
            user.ChipsTextBox.Text = @"Chips : " + user.Chips;
            user.Turn = false;
            MainPoker.Raising = false;
            previous = 0;
            user = (Bot)MainPoker.GetStatus(user);
            return user;
        }
        public Bot Call(Bot user, ref int previous)
        {
            if (user.Chips > MainPoker.Call)
            {
                MainPoker.Raising = false;
                user.Turn = false;
                user.Chips -= MainPoker.Call;
                user.ChipsTextBox.Text = @"Chips : " + user.Chips;
                user.StatusLabel.Text = @"Call " + (MainPoker.Call + previous);
                PotText = PotText + MainPoker.Call;
                previous = int.Parse(user.StatusLabel.Text.Substring(5));
                user = (Bot)MainPoker.GetStatus(user);
                return user;
            }

            MainPoker.Raising = false;
            user.Turn = false;
            user.StatusLabel.Text = @"Call " + user.Chips;
            if (user.Chips != null) PotText = PotText + (int)user.Chips;
            else
            {
                MessageBox.Show(@"Unexpected error has occured !");
                Application.Exit();
            }
            user.Chips = 0;
            previous = int.Parse(user.StatusLabel.Text.Substring(5));
            user = (Bot)MainPoker.GetStatus(user);
            return user;
        }
        public Bot Raised(Bot user, ref int previous)
        {
            user.Chips -= Convert.ToInt32(MainPoker.Raise - previous);
            user.StatusLabel.Text = @"Raise " + MainPoker.Raise;
            user.ChipsTextBox.Text = @"Chips : " + user.Chips;
            PotText = PotText + Convert.ToInt32(MainPoker.Raise);
            MainPoker.Call = Convert.ToInt32(MainPoker.Raise);
            MainPoker.TempCall = MainPoker.Call;
            MainPoker.Raising = true;
            user.Turn = false;
            previous = int.Parse(user.StatusLabel.Text.Substring(6));
            user = (Bot)MainPoker.GetStatus(user);
            return user;
        }

        public Bot Raise(Bot user, int min, ref int previous)
        {
            int countPassable = 0;
            foreach (var t in MaxRaise)
            {
                if ((MainPoker.Call + previous) * 2 <= t) countPassable++;
            }
            if (countPassable == MaxRaise.Length)
            {
                if ((MainPoker.Call + previous) * 2 == 0)
                {
                    int randomBigBlindRaise = Random.Next(1, 3);
                    if (MainPoker.Bb * randomBigBlindRaise <= user.Chips)
                    {
                        MainPoker.Raise = MainPoker.Bb * randomBigBlindRaise;
                    }
                    else
                    {
                        user = Check(user, out previous);
                    }
                }
                else
                {
                    MainPoker.Raise = (MainPoker.Call + previous) * 2;
                }
                user = Raised(user, ref previous);
            }
            else
            {
                user = Call(user, ref previous);
            }
            return user;
        }

        public Bot Hp(Bot user, int n, int n1, ref int previous)
        {
            int rnd = Random.Next(1, 3);
            int min = RoundN(user.Chips, n, 100);
            int max = RoundN(user.Chips, n1, 100);
            if (MainPoker.Call <= 0)
            {
                user = Check(user, out previous);
            }
            if (MainPoker.Call > 0)
            {
                if (rnd == 1)
                {
                    user = MainPoker.Call <= min ? Call(user, ref previous) : Fold(user);
                }
                else
                {
                    user = MainPoker.Call <= max ? Call(user, ref previous) : Fold(user);
                }
            }
            if (user.Chips <= 0)
            {
                user.FoldTurn = true;
            }
            return user;
        }

        public Bot Ph(Bot user, int min, int max, ref int previous)
        {
            int rnd = Random.Next(1, 3);
            int _min = RoundN(user.Chips, min, 100);
            int _max = RoundN(user.Chips, max, 100);
            int _min1 = RoundN(user.Chips, min - rnd, 100);
            int _max1 = RoundN(user.Chips, max - rnd, 100);
            if (MainPoker.Rounds < 2)
            {
                user = MainPoker.Call <= 0 ? Check(user, out previous) : Ph_1(user, _min, _max, ref previous);
            }
            else
            {
                user = MainPoker.Call <= 0 ? Raise(user, _min1, ref previous) : Ph_1(user, _min1, _max1, ref previous);
            }
            if (user.Chips <= 0)
            {
                user.FoldTurn = true;
            }
            return user;
        }
        public Bot Ph_1(Bot user, int minimum, int maximum, ref int previous)
        {
            if (MainPoker.Call >= maximum)
            {
                user = Fold(user);
            }
            else
            {
                if (MainPoker.Call >= minimum && MainPoker.Call <= maximum ||
                    MainPoker.Call <= minimum && MainPoker.Call >= minimum / 2)
                {
                    user = Call(user, ref previous);
                }
                else if (MainPoker.Call <= 0)
                {
                    user = Check(user, out previous);
                }
                else
                {
                    user = Call(user, ref previous);
                }
            }
            return user;
        }

        public Bot Smooth(Bot user, int n, ref int previous)
        {
            int rnd = Random.Next(1, 3);
            int min = RoundN(user.Chips, n, 100);
            if (MainPoker.Call <= 0)
            {
                if (rnd == 1)
                {
                    user = Check(user, out previous);
                }
                else
                {
                    Raise(user, min, ref previous);
                }
            }
            else
            {
                if (MainPoker.Call >= min)
                {
                    user = Call(user, ref previous);
                }
                else
                {
                    Raise(user, MainPoker.Call * 2, ref previous);
                }
            }
            if (user.Chips <= 0)
            {
                user.FoldTurn = true;
            }
            return user;
        }
    }
}