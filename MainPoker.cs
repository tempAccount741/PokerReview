using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Achievements;
using Poker.Combinations;
using Poker.Users;

namespace Poker
{
    public partial class MainPoker : Form
    {
        public enum TableCards
        {
            FirstCard = 12,
            SecondCard = 13,
            ThirdCard = 14,
            FourthCard = 15,
            FifthCard = 16
        }

        private static Player Player = new Player(10000, new Point(560, 470));

        private Bot Bot1 = new Bot(10000, AnchorStyles.Left, "Bot 1", 2, (int)UsersProperties.CUser.Bot1,
            new Point(15, 420), false, new Tuple<int?, int>(Player.Chips, 6));

        private Bot Bot2 = new Bot(10000, AnchorStyles.Left, "Bot 2", 4, (int)UsersProperties.CUser.Bot2,
            new Point(75, 65), true, new Tuple<int?, int>(Player.Chips, 6));

        private Bot Bot3 = new Bot(10000, AnchorStyles.Left, "Bot 3", 6, (int)UsersProperties.CUser.Bot3,
            new Point(590, 25), true, new Tuple<int?, int>(Player.Chips, 6));

        private Bot Bot4 = new Bot(10000, AnchorStyles.Left, "Bot 4", 8, (int)UsersProperties.CUser.Bot4,
            new Point(1115, 65), true, new Tuple<int?, int>(Player.Chips, 6));

        private Bot Bot5 = new Bot(10000, AnchorStyles.Left, "Bot 5", 10, (int)UsersProperties.CUser.Bot5,
            new Point(1160, 420), false, new Tuple<int?, int>(Player.Chips, 6));

        private Hand _sorted;
        private readonly Help _help = new Help();

        public static int ThinkTime { get; set; } = Properties.Settings.Default.ThinkingTime;

        public static int[] AllAchievements { get; set; } = {
            Properties.Settings.Default.GetStraight,
            Properties.Settings.Default.GetFlush,
            Properties.Settings.Default.GetFullHouse,
            Properties.Settings.Default.GetFourOfAKind,
            Properties.Settings.Default.GetStraightFlush,
            Properties.Settings.Default.GetRoyalFlush,
            Properties.Settings.Default.GetMoneyF,
            Properties.Settings.Default.GetMoneyS,
            Properties.Settings.Default.GetPlayedHands,
        };
        public static bool Raising { get; set; }
        public static int AchivementMoney { get; set; }
        public static int AchivementHands { get; set; }
        public static int Bb { get; set; } = 500;
        public static int Sb { get; set; } = 250;
        public static int Call { get; set; } = 500;
        public static int Raise { get; set; }
        public static int Rounds { get; set; }
        public static int TempCall { get; set; }
        public int Folds { get; set; }
        public int WonHands { get; set; }
        public int LostHands { get; set; }
        public int PlayedHands1 { get; set; }

        public static string[] StatusLabels { get; } = new string[6];
        public static string[] ChipsTextBoxes { get; } = new string[6];
        public static string[] UsernameLabels { get; } = new string[6];

        public static bool[] AllAchievementsBools { get; set; } = {
            Properties.Settings.Default.GetStraight >= Achievements.Achievements.Straight.Requirement,
            Properties.Settings.Default.GetFlush >= Achievements.Achievements.Flush.Requirement,
            Properties.Settings.Default.GetFullHouse >= Achievements.Achievements.FullHouse.Requirement,
            Properties.Settings.Default.GetFourOfAKind >= Achievements.Achievements.FourOfAKind.Requirement,
            Properties.Settings.Default.GetStraightFlush >= Achievements.Achievements.StraightFlush.Requirement,
            Properties.Settings.Default.GetRoyalFlush >=Achievements.Achievements. RoyalFlush.Requirement,
            Properties.Settings.Default.GetMoneyF >=Achievements.Achievements. MoneyFirst.Requirement,
            Properties.Settings.Default.GetMoneyS >= Achievements.Achievements.MoneySecond.Requirement,
            Properties.Settings.Default.GetPlayedHands >= Achievements.Achievements.PlayedHands.Requirement,
        };

        public static List<Hand> Win { get; } = new List<Hand>();
        public static string GetCards { get; set; } = @"Assets\Cards\Pack_Classic";
        public static string GetBack { get; set; } = @"Assets\Back\Back_Classic\Back_Classic.png";

        public static Timer Timer { get; set; } = new Timer();
        public static Timer Updates { get; set; } = new Timer();

        private int _up = int.MaxValue,
            _i,
            _t = 30,
            _turnCount,
            _foldedPlayers = 5,
            _tableNumber = 12,
            startingBot,
            tempStartingBot;

        private const int Flop = 1,
            Turn = 2,
            River = 3,
            End = 4;

        private static int _horizontal,
            _vertical,
            _correct,
            _newTurn,
            _winners;

        private static bool _restart;
        private static bool _addingChips;
        private bool _ifFormLoaded;
        private static bool dontRepeat;

        private static readonly string[] CombinationNames =
        {
            " High Card ",
            " Pair ",
            " Two Pair ",
            " Three of a Kind ",
            " Straight ",
            " Flush ",
            " Full House ",
            " Four of a Kind ",
            " Straight Flush ",
            " Royal Flush ! "
        };

        private List<bool> _turns = new List<bool>();
        private readonly List<UsersProperties> _users = new List<UsersProperties>();
        private readonly List<UserControls> _userControls = new List<UserControls>(); 
        private readonly List<string> _addWinners = new List<string>();
        private static readonly int[] _reserve = new int[17];
        private static readonly Image[] Deck = new Image[52];
        private static readonly PictureBox[] Holder = new PictureBox[17];

        private static string[] _imgLocation = Directory.GetFiles(GetCards, "*.png", SearchOption.TopDirectoryOnly);
        private static readonly List<string> NewImgLocation = new List<string>();

//                private static string[] _imgLocation ={
//                    @"Assets\Cards\Pack_Classic\51.png",@"Assets\Cards\Pack_Classic\52.png",
//                    @"Assets\Cards\Pack_Classic\4.png",@"Assets\Cards\Pack_Classic\20.png",
//                    @"Assets\Cards\Pack_Classic\1.png",@"Assets\Cards\Pack_Classic\20.png",
//                    @"Assets\Cards\Pack_Classic\1.png",@"Assets\Cards\Pack_Classic\20.png",
//                    @"Assets\Cards\Pack_Classic\1.png",@"Assets\Cards\Pack_Classic\20.png",
//                    @"Assets\Cards\Pack_Classic\1.png",@"Assets\Cards\Pack_Classic\20.png",
//                
//                    @"Assets\Cards\Pack_Classic\1.png",
//                    @"Assets\Cards\Pack_Classic\18.png",@"Assets\Cards\Pack_Classic\32.png",
//                    @"Assets\Cards\Pack_Classic\10.png",@"Assets\Cards\Pack_Classic\23.png"};

        public MainPoker()
        {
            if (Player.Chips != null) AchivementMoney = (int)Player.Chips;
            AchivementHands = PlayedHands1;
            TempCall = Call;
            _users.Add(Player);
            _users.Add(Bot1);
            _users.Add(Bot2);
            _users.Add(Bot3);
            _users.Add(Bot4);
            _users.Add(Bot5);
            _userControls.Add(Player);
            _userControls.Add(Bot1);
            _userControls.Add(Bot2);
            _userControls.Add(Bot3);
            _userControls.Add(Bot4);
            _userControls.Add(Bot5);

            KeyPress +=
                Form1_KeyPress;
            Call = Bb;
            MaximizeBox = false;
            MinimizeBox = false;
            Updates.Start();
            InitializeComponent();
            PickNextBlind();
            Timer.Interval = (1000);
            Timer.Tick += timer_Tick;
            Updates.Interval = (100);
            Updates.Tick += Update_Tick;
            tbRaise.Text = (Bb * 2).ToString();
        }

        private async void MainPoker_Load(object sender, EventArgs e)
        {
            Player = (Player)SetControls(Player, pStatus, playerName, tbChips);
            Bot1 = (Bot)SetControls(Bot1, b1Status, bot1Name, tbBotChips1);
            Bot2 = (Bot)SetControls(Bot2, b2Status, bot2Name, tbBotChips2);
            Bot3 = (Bot)SetControls(Bot3, b3Status, bot3Name, tbBotChips3);
            Bot4 = (Bot)SetControls(Bot4, b4Status, bot4Name, tbBotChips4);
            Bot5 = (Bot)SetControls(Bot5, b5Status, bot5Name, tbBotChips5);

            for (int j = 0; j < 6; j++)
            {
                UsernameLabels[j] = _users[j].Name;
                _turns.Add(_users[j].FoldTurn);
                ChipsTextBoxes[j] = _userControls[j].ChipsTextBox.Text;
                StatusLabels[j] = _userControls[j].StatusLabel.Text;
            }

            Player = (Player)SetStatus(Player);
            Bot1 = (Bot)SetStatus(Bot1);
            Bot2 = (Bot)SetStatus(Bot2);
            Bot3 = (Bot)SetStatus(Bot3);
            Bot4 = (Bot)SetStatus(Bot4);
            Bot5 = (Bot)SetStatus(Bot5);

            _ifFormLoaded = true;

            await Shuffle();
            UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);

        }

        private string[] ShuffleArray(string[] input)
        {
            var random = new RngCrypto();
            for (_i = input.Length; _i > 0; _i--)
            {
                int j = random.Next(_i);
                string k = input[j];
                input[j] = input[_i - 1];
                input[_i - 1] = k;
            }
            return input;
        }
        private static string[] RemoveStrings(string[] input, IEnumerable<string> charsToRemove, int i)
        {
            foreach (string c in charsToRemove.Where(c => input != null))
            {
                input[i] = input[i].Replace(c, string.Empty);
            }
            return input;
        }

        private async Task Shuffle()
        {
            var refreshBackImage = new Bitmap(GetBack);
            SetPlayerStuff(false);
            MaximizeBox = false;
            MinimizeBox = false;
            bool check = false;
            _horizontal = Player.CardsLocation.X;
            _vertical = Player.CardsLocation.Y;
            _imgLocation = ShuffleArray(_imgLocation);
            string[] charsToRemove = { GetCards, ".png", @"\" };
            for (_i = 0; _i < 17; _i++)
            {
                if (dontRepeat) continue;
                if (Deck != null) Deck[_i] = Image.FromFile(_imgLocation[_i]);
                _imgLocation = RemoveStrings(_imgLocation, charsToRemove, _i);
                if (_reserve != null) _reserve[_i] = int.Parse(_imgLocation[_i]) - 1;
                if (Holder != null)
                {
                    Holder[_i] = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Height = Settings.Height,
                        Width = Settings.Width,
                        Name = "pb" + _i
                    };
                    Controls.Add(Holder[_i]);
                }
                await Task.Delay(150);
                SetPlayers(Player, _i, ref check, refreshBackImage);
                SetPlayers(Bot1, _i, ref check, refreshBackImage);
                SetPlayers(Bot2, _i, ref check, refreshBackImage);
                SetPlayers(Bot3, _i, ref check, refreshBackImage);
                SetPlayers(Bot4, _i, ref check, refreshBackImage);
                SetPlayers(Bot5, _i, ref check, refreshBackImage);
                SetTable(_i, ref check, refreshBackImage);

                Bot1 = FoldedPlayer(Bot1);
                Bot2 = FoldedPlayer(Bot2);
                Bot3 = FoldedPlayer(Bot3);
                Bot4 = FoldedPlayer(Bot4);
                Bot5 = FoldedPlayer(Bot5);
                if (_i != (int)TableCards.FifthCard) continue;
                Ending();
                if (!_restart)
                {
                    MaximizeBox = true;
                    MinimizeBox = true;
                    _restart = true;
                }
                tempStartingBot = startingBot;
                await Turns();
                dontRepeat = true;
                break;
            }
        }
        private void Ending()
        {
            if (_foldedPlayers == 5)
            {
                var dialogResult = MessageBox.Show(@"Would You Like To Play Again ?",
                    @"You Won , Congratulations ! ", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        Application.Restart();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                }
            }
            else
            {
                _foldedPlayers = 5;
            }
        }
        private Bot FoldedPlayer(Bot user)
        {
            if (user.Chips <= 0)
            {
                user.FoldTurn = true;
                if (Holder != null)
                {
                    Holder[user.RightCard].Visible = false;
                    Holder[user.LeftCard].Visible = false;
                }
                user.UsernameLabel.Visible = false;
            }
            else
            {
                user.FoldTurn = false;
                if (_i != user.LeftCard) return user;
                if (Holder[user.LeftCard] == null) return user;
                Holder[user.RightCard].Visible = true;
                Holder[user.LeftCard].Visible = true;
            }
            return user;
        }
        
        private void SetPlayers(UsersProperties user, int turn, ref bool check, Image refreshbackImage)
        {
            if (user.Chips <= 0) return;
            _foldedPlayers--;
            if (turn < user.RightCard || turn > user.LeftCard) return;
            if (Holder[user.RightCard].Tag != null)
            {
                Holder[user.LeftCard].Tag = _reserve[user.LeftCard];
            }
            Holder[user.RightCard].Tag = _reserve[user.RightCard];
            if (!check)
            {
                _horizontal = user.CardsLocation.X;
                _vertical = user.CardsLocation.Y;
            }
            check = true;
            Holder[turn].Anchor = user.CardsAnchor;
            Holder[turn].Image = refreshbackImage;
            if (turn < Bot1.RightCard)
            {
                Holder[turn].Image = Deck[_i];
            }
            Holder[turn].Location = new Point(_horizontal, _vertical);
            _horizontal += Holder[turn].Width;
            Holder[turn].Visible = true;
            Controls.Add(user.Panel);
            user.Panel.Location = user.PanelLocation;
            user.Panel.BackColor = Color.DarkBlue;
            user.Panel.Size = user.PanelSize;
            user.Panel.Visible = false;
            if (_i != user.LeftCard) return;
            check = false;
        }
        private void SetTable(int turn, ref bool check, Image refreshBackImage)
        {
            if (turn < _tableNumber) return;
            switch (_tableNumber)
            {
                case (int)TableCards.FirstCard:
                    Holder[_tableNumber].Tag = _reserve[_tableNumber];
                    break;
                default:
                    if (turn > _tableNumber) Holder[turn].Tag = _reserve[turn];
                    _tableNumber++;
                    break;
            }
            if (!check)
            {
                _horizontal = 410;
                _vertical = 265;
            }
            check = true;
            if (Holder[turn] == null) return;
            Holder[turn].Anchor = AnchorStyles.None;
            Holder[turn].Image = refreshBackImage;
            //Holder[i].Image = Deck[i];
            Holder[turn].Location = new Point(_horizontal, _vertical);
            _horizontal += Holder[turn].Width + 20;
        }
        private static UsersProperties SetControls(UsersProperties user, Label status, Label username, TextBox chips)
        {
            if (chips != null)
            {
                chips.Text = RepetitiveVariables.Chips + user.Chips;
                status.Text = StatusLabels[user.EnumCasted];

                user.StatusLabel = status;
                user.ChipsTextBox = chips;
            }

            if (username == null) return user;
            username.Location = user.UsernameLabelLocation;
            username.Size = user.UsernameLabelSize;
            username.Text = user.Name;
            username.Visible = true;
            user.UsernameLabel = username;

            return user;
        }

        public static void ReplacePacks()
        {
            NewImgLocation.Clear();
            var previousBack = new Bitmap(GetBack);
            string helpPack = Properties.Settings.Default.CardPack;
            string helpBack = Properties.Settings.Default.CardBack;
            GetBack = helpBack;
            GetCards = helpPack;
            if (helpPack == null || helpBack == null)
            {
                return;
            }
            if (helpPack == "") return;
            string[] tempImgLocation = Directory.GetFiles(helpPack, "*.png", SearchOption.TopDirectoryOnly);
            for (int j = 0; j < 17; j++)
            {
                for (int k = 0; k < tempImgLocation.Length; k++)
                {
                    string[] charsToRemove = { helpPack, ".png", @"\" };
                    tempImgLocation = RemoveStrings(tempImgLocation, charsToRemove, k);
                    if (_imgLocation[j] == tempImgLocation[k])
                    {
                        int tempInt = int.Parse(tempImgLocation[k]);
                        NewImgLocation.Add($@"{helpPack}\{tempInt}.png");
                        if (Help.AreEqual((Bitmap)Holder[j].Image, previousBack))
                        {
                            Holder[j].Image = new Bitmap(helpBack);
                            GetBack = Properties.Settings.Default.CardBack;
                        }
                        else
                        {
                            try
                            {
                                Holder[j].Image = new Bitmap(NewImgLocation[j]);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(@"An unexpected error has occured !" + ex.Message);
                                Application.Exit();
                            }
                        }
                        if (Deck != null) Deck[j] = new Bitmap(NewImgLocation[j]);
                    }
                }
            }
        }
        public static void ReplaceBacks()
        {
            var previousBack = new Bitmap(GetBack);
            string helpBack = Properties.Settings.Default.CardBack;
            GetBack = helpBack;
            if (string.IsNullOrEmpty(helpBack)) return;
            for (int j = 0; j < 17; j++)
            {
                if (!Help.AreEqual((Bitmap)Holder[j].Image, previousBack)) continue;
                Holder[j].Image = new Bitmap(helpBack);
                GetBack = Properties.Settings.Default.CardBack;
            }
        }

        private List<bool> ReturnTurns()
        {
            return new List<bool>
            {
                Player.FoldTurn,
                Bot1.FoldTurn,
                Bot2.FoldTurn,
                Bot3.FoldTurn,
                Bot4.FoldTurn,
                Bot5.FoldTurn
            };
        }
        private void SetPlayerStuff(bool enableOrDisable)
        {
            if (enableOrDisable)
            {
                pbTimer.Value = 1000;
                _t = 30;
                Timer.Enabled = true;
            }
            else Timer.Enabled = false;

            pbTimer.Visible = enableOrDisable;
            bRaise.Enabled = enableOrDisable;
            bCall.Enabled = enableOrDisable;
            bRaise.Enabled = enableOrDisable;
            bRaise.Enabled = enableOrDisable;
            bFold.Enabled = enableOrDisable;
        }

        private async Task Turns()
        {
            while (true)
            {
                _turns = ReturnTurns();
                GC.KeepAlive(Updates);
                if (!Player.FoldTurn && Player.Chips > 0)
                {
                    if (Player.Turn)
                    {
                        Call = TempCall;
                        SetPlayerStuff(true);
                        Call -= Player.PreviousCall;
                        Bot1.Turn = true;
                        _up = int.MaxValue;
                        _turnCount++;
                        _restart = true;
                    }
                }
                if (!Player.Turn)
                {
                    await Flip(Player.EnumCasted);
                }
                if (Player.FoldTurn || !Player.Turn || Player.Chips <= 0)
                {
                    Call = TempCall;
                    if (StatusLabels[Player.EnumCasted].Contains(RepetitiveVariables.Fold))
                    {
                        Bot1.Turn = true;
                    }
                    SetPlayerStuff(false);
                    for (int j = tempStartingBot; j < _users.Count; j++)
                    {
                        _users[j] = await RotateTurns((Bot)_users[j]);
                    }
                    tempStartingBot = 1;
                    _restart = false;
                }
                if (!_restart)
                {
                    continue;
                }
                break;
            }
        }
        private async Task<Bot> RotateTurns(Bot user)
        {
            UsersProperties[] users = { Player, Bot1, Bot2, Bot3, Bot4, Bot5 };
            UsersProperties userNext = new UsersProperties();
            for (int j = 0; j < users.Length; j++)
            {
                if (user == users[j])
                {
                    userNext = j + 1 < users.Length ? users[j + 1] : users[0];
                    break;
                }
            }
            if (!user.FoldTurn && user.Turn)
            {
                int previous = user.PreviousCall;
                Call -= user.PreviousCall;
                if (Properties.Settings.Default.ThinkCheck)
                {
                    AutoCloseMsb.Show(user.Name + " Turn", "Turns", ThinkTime);
                }
                Combinations(user);
                user = Ai(user, ref previous);
                await CheckTextBoxes();
                user.Turn = false;
                _turnCount++;
                userNext.Turn = true;
                CheckIfBlind(user, previous);
                Call = TempCall;
            }
            if (user.FoldTurn)
            {
                _turns = ReturnTurns();
                userNext.Turn = true;
            }
            await Flip(user.EnumCasted);
            return user;
        }
        private static void CheckIfBlind(UsersProperties user, int previousCall)
        {
            if (user.StatusLabel.Text.Contains(RepetitiveVariables.BigBlind))
            {
                user.PreviousCall = previousCall + Bb;
            }
            if (user.StatusLabel.Text.Contains(RepetitiveVariables.SmallBlind))
            {
                user.PreviousCall = previousCall + Sb;
            }
            if (!user.StatusLabel.Text.Contains(RepetitiveVariables.BigBlind) &&
                !user.StatusLabel.Text.Contains(RepetitiveVariables.SmallBlind))
            {
                user.PreviousCall = previousCall;
            }
        }
        private static UsersProperties PickNextBlindProperties(UsersProperties user, UsersProperties nextUser, int correctPass, string option)
        {
            if (nextUser != null) nextUser.Turn = true;
            user.Turn = false;
            if (option == RepetitiveVariables.BigBlind)
            {
                if (StatusLabels != null) StatusLabels[user.EnumCasted] = RepetitiveVariables.BigBlind + Bb;
                user.StatusLabel.Text = RepetitiveVariables.BigBlind + Bb;
                user.Chips -= Bb;
                user.PreviousCall = Bb;
            }
            else
            {
                if (StatusLabels != null) StatusLabels[user.EnumCasted] = RepetitiveVariables.SmallBlind + Sb;
                user.StatusLabel.Text = RepetitiveVariables.SmallBlind + Sb;
                user.Chips -= Sb;
                user.PreviousCall = Sb;
                _correct = correctPass;
            }
            _correct = correctPass;
            user = GetStatus(user);
            return user;
        }
        private void PickNextBlind()
        {
            switch (_newTurn)
            {
                case 0:
                    Bot5 = (Bot)PickNextBlindProperties(Bot5, Player, Bot5.EnumCasted, RepetitiveVariables.BigBlind);
                    Bot4 = (Bot)PickNextBlindProperties(Bot4, Player, Bot5.EnumCasted, RepetitiveVariables.SmallBlind);
                    startingBot = 1;
                    Bot1.Turn = true;
                    break;

                case 1:
                    Player =
                        (Player)PickNextBlindProperties(Player, Bot1, Player.EnumCasted, RepetitiveVariables.BigBlind);
                    Bot5 = (Bot)PickNextBlindProperties(Bot5, Bot1, Player.EnumCasted, RepetitiveVariables.SmallBlind);
                    Bot2.Turn = true;
                    startingBot = 1;
                    break;

                case 2:
                    Bot1 = (Bot)PickNextBlindProperties(Bot1, Bot2, Bot1.EnumCasted, RepetitiveVariables.BigBlind);
                    Player = (Player)PickNextBlindProperties(Player, Bot2, Bot1.EnumCasted, RepetitiveVariables.SmallBlind);
                    Bot3.Turn = true;
                    startingBot = 2;
                    break;

                case 3:
                    Bot2 = (Bot)PickNextBlindProperties(Bot2, Bot3, Bot2.EnumCasted, RepetitiveVariables.BigBlind);
                    Bot1 = (Bot)PickNextBlindProperties(Bot1, Bot3, Bot2.EnumCasted, RepetitiveVariables.SmallBlind);
                    Bot4.Turn = true;
                    startingBot = 3;
                    break;

                case 4:
                    Bot3 = (Bot)PickNextBlindProperties(Bot3, Bot4, Bot3.EnumCasted, RepetitiveVariables.BigBlind);
                    Bot2 = (Bot)PickNextBlindProperties(Bot2, Bot4, Bot3.EnumCasted, RepetitiveVariables.SmallBlind);
                    Bot5.Turn = true;
                    startingBot = 4;
                    break;

                case 5:
                    Bot4 = (Bot)PickNextBlindProperties(Bot4, Bot5, Bot4.EnumCasted, RepetitiveVariables.BigBlind);
                    Bot3 = (Bot)PickNextBlindProperties(Bot3, Bot5, Bot4.EnumCasted, RepetitiveVariables.SmallBlind);
                    startingBot = 5;
                    break;
            }
            tbPot.Text = (Sb + Bb).ToString();
        }

        private void Combinations(UsersProperties user)
        {
            if (user.StatusLabel.Text.Contains(RepetitiveVariables.Fold)) return;

            for (_i = 0; _i < 16; _i++)
                if (_reserve[_i] == int.Parse(Holder[user.RightCard].Tag.ToString()) &&
                    _reserve[_i + 1] == int.Parse(Holder[user.LeftCard].Tag.ToString()))
                {
                    var combinationAnalyzers = new List<BaseCombinationAnalyzer>
                    {
                        new HighCard(user, _reserve),
                        new PairFromTable(user, _reserve),
                        new PairInHand(user, _reserve),
                        new PairHandTable(user, _reserve),
                        new TwoPairFromTable(user, _reserve),
                        new TwoPairHandPairTablePair(user, _reserve),
                        new TwoPairHandTable(user, _reserve),
                        new TwoPairTwoDifferent(user, _reserve),
                        new ThreeOfAKind(user, _reserve),
                        new Combinations.Straight(user, _reserve),
                        new Combinations.Flush(user, _reserve),
                        new Combinations.FullHouse(user, _reserve),
                        new Combinations.FourOfAKind(user, _reserve),
                        new Combinations.StraightFlush(user, _reserve),
                        new Combinations.RoyalFlush(user, _reserve)
                    };
                    foreach (var combination in combinationAnalyzers)
                    {
                        combination.Check(_reserve,user);
                    }
                    break;
                }
            if (Win.Count > 0)
                _sorted =
                    Win.OrderByDescending(op => op.Current)
                        .ThenByDescending(op => op.Power)
                        .First();
        }

        private void Picking(int turn, int start, int segashenHod)
        {
            if (segashenHod != turn) return;
            for (int k = start; k >= 0; k--)
            {
                if (_turns[k])
                {
                    _correct = Array.LastIndexOf(_turns.ToArray(), false);
                }
                else
                {
                    _correct = k;
                    break;
                }
            }
        }
        private void Show(int start, int end)
        {
            for (int j = start; j <= end; j++)
            {
                if (Holder[j].Image == Deck[j]) continue;
                Holder[j].Image = Deck[j];
                Player.PreviousCall = 0;
                Bot1.PreviousCall = 0;
                Bot2.PreviousCall = 0;
                Bot3.PreviousCall = 0;
                Bot4.PreviousCall = 0;
                Bot5.PreviousCall = 0;
            }
        }

        private async Task Restart()
        {
            PlayedHands1++;
            UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);
            _winners = 0;
            Call = Bb;
            TempCall = Call;
            Raise = 0;
            Rounds = 0;
            ResetProperties(Player);
            ResetProperties(Bot1);
            ResetProperties(Bot2);
            ResetProperties(Bot3);
            ResetProperties(Bot4);
            ResetProperties(Bot5);
            _restart = false;
            Raising = false;
            _addingChips = false;
            Win.Clear();
            _addWinners.Clear();
            _sorted.Current = (int)Hand.Combinations.Default;
            _sorted.Power = 0d;
            tbPot.Text = @"0";
            _t = 30;
            _up = int.MaxValue;
            _turnCount = 0;
            Bot.PotText = Bb + Sb;
            if (_newTurn < 5)
            {
                _newTurn++;
            }
            else
            {
                _newTurn = 0;
            }
            PickNextBlind();
            RefillChips();
            _imgLocation = Directory.GetFiles(GetCards, "*.png", SearchOption.TopDirectoryOnly);
            for (int os = 0; os < 17; os++)
            {
                Holder[os].Image = null;
                Holder[os].Invalidate();
                Holder[os].Visible = false;
            }
            dontRepeat = false;
            await Shuffle();
        }
        private static void ResetProperties(UsersProperties user)
        {
            user.Type = (int)Hand.Combinations.Default;
            user.Power = 0;
            user.FoldTurn = false;
            user.Panel.Visible = false;
            user.PreviousCall = 0;
            user.StatusLabel.Text = "";
            GetStatus(user);
        }
        private void RefillChips()
        {
            if (Player.Chips > 0) return;
            var f2 = new AddChips();
            f2.ShowDialog();
            if (f2.A == 0) return;
            Player.Chips = f2.A;
            Bot1.Chips += f2.A / 2;
            Bot2.Chips += f2.A / 2;
            Bot3.Chips += f2.A / 2;
            Bot4.Chips += f2.A / 2;
            Bot5.Chips += f2.A / 2;
            Bb = (int)Player.Chips / 30;
            Sb = Bb / 2;
            Player.FoldTurn = false;
            Player.Turn = true;
            bRaise.Enabled = true;
            bFold.Enabled = true;
            bCheck.Enabled = true;
            bRaise.Text = RepetitiveVariables.Raise;
        }

        private async Task CheckLabels()
        {
            const string fold = @"Fold";
            bool[] conditions =
            {
                StatusLabels[Player.EnumCasted] == fold,
                StatusLabels[Bot1.EnumCasted] == fold,
                StatusLabels[Bot2.EnumCasted] == fold,
                StatusLabels[Bot3.EnumCasted] == fold,
                StatusLabels[Bot4.EnumCasted] == fold,
                StatusLabels[Bot5.EnumCasted] == fold
            };
            var a = StatusLabels.Count(x => x == fold);
            if (a == 5)
            {
                var lastOne = Array.IndexOf(conditions, false);
                var users = new List<UsersProperties> { Player, Bot1, Bot2, Bot3, Bot4, Bot5 };
                foreach (var t in users.Where(t => lastOne == t.EnumCasted))
                {
                    t.Panel.Visible = true;
                    t.Chips += int.Parse(tbPot.Text);
                    MessageBox.Show(t.Name + @" Wins");
                    if (t == Player)
                    {
                        WonHands++;
                    }
                    else
                    {
                        LostHands++;
                    }
                }
                UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);
                await Restart();
            }
        }
        private async Task CheckTextBoxes()
        {
            const string fold = @"Fold";
            const int zero = 0;
            bool[] conditions =
            {
                Player.Chips != zero && StatusLabels[Player.EnumCasted] != fold,
                Bot1.Chips != zero && StatusLabels[Bot1.EnumCasted] != fold,
                Bot2.Chips != zero && StatusLabels[Bot2.EnumCasted] != fold,
                Bot3.Chips != zero && StatusLabels[Bot3.EnumCasted] != fold,
                Bot4.Chips != zero && StatusLabels[Bot4.EnumCasted] != fold,
                Bot5.Chips != zero && StatusLabels[Bot5.EnumCasted] != fold
            };

            string[] zeroChips =
            {
                ChipsTextBoxes[Player.EnumCasted], ChipsTextBoxes[Bot1.EnumCasted],
                ChipsTextBoxes[Bot2.EnumCasted], ChipsTextBoxes[Bot3.EnumCasted], ChipsTextBoxes[Bot4.EnumCasted],
                ChipsTextBoxes[Bot5.EnumCasted]
            };

            var a = zeroChips.Count(x => x == RepetitiveVariables.ChipsZero);
            var b = StatusLabels.Count(x => x == fold);
            var c = conditions.Count(x => x);
            if (6 - b == a && b != 5 || c == 1 && a > 0)
            {
                _sorted.Current = (int)Hand.Combinations.Default;
                _sorted.Power = 0d;
                Player = (Player)Winner(Player, 1);
                Bot1 = (Bot)Winner(Bot1, 0);
                Bot2 = (Bot)Winner(Bot2, 0);
                Bot3 = (Bot)Winner(Bot3, 0);
                Bot4 = (Bot)Winner(Bot4, 0);
                Bot5 = (Bot)Winner(Bot5, 2);
                await Restart();
            }

        }
        private async Task Flip(int currentTurn)
        {
            bool foldOnFlip = false;
            var a = StatusLabels.Count(x => x == RepetitiveVariables.Fold);
            if (a == 5)
            {
                await CheckLabels();
            }
            else
            {
                int ravno = _turns.Count(c => !c) == 2 ? 0 : 1;
                if (Raising)
                {
                    _turnCount = 0;
                    Raising = false;

                    if (currentTurn == Player.EnumCasted)
                        _correct = Array.LastIndexOf(_turns.ToArray(), false);
                    Picking(Bot1.EnumCasted, Player.EnumCasted, currentTurn);
                    Picking(Bot2.EnumCasted, Bot1.EnumCasted, currentTurn);
                    Picking(Bot3.EnumCasted, Bot2.EnumCasted, currentTurn);
                    Picking(Bot4.EnumCasted, Bot3.EnumCasted, currentTurn);
                    if (currentTurn == Bot5.EnumCasted)
                        _correct = Array.LastIndexOf(_turns.ToArray(), false, 4, _turns.ToArray().Length - 1);
                }
                else
                {
                    if (_turns[_correct])
                        foldOnFlip = true;
                    if (_turns.Count(c => !c) == StatusLabels.Count(c1 => c1 == RepetitiveVariables.Check))
                        foldOnFlip = true;
                }
                if (currentTurn == _correct && _turnCount > ravno || foldOnFlip)
                {
                    Raise = 0;
                    Call = 0;
                    _turnCount = 0;
                    TempCall = 0;
                    Rounds++;
                    _correct = currentTurn;

                    if (!Player.FoldTurn) StatusLabels[Player.EnumCasted] = "";
                    if (!Bot1.FoldTurn) StatusLabels[Bot1.EnumCasted] = "";
                    if (!Bot2.FoldTurn) StatusLabels[Bot2.EnumCasted] = "";
                    if (!Bot3.FoldTurn) StatusLabels[Bot3.EnumCasted] = "";
                    if (!Bot4.FoldTurn) StatusLabels[Bot4.EnumCasted] = "";
                    if (!Bot5.FoldTurn) StatusLabels[Bot5.EnumCasted] = "";
                    SetStatus(Player);
                    SetStatus(Bot1);
                    SetStatus(Bot2);
                    SetStatus(Bot3);
                    SetStatus(Bot4);
                    SetStatus(Bot5);
                    if (Rounds == Flop)
                    {
                        Show((int)TableCards.FirstCard, (int)TableCards.ThirdCard);
                    }
                    if (Rounds == Turn)
                    {
                        Show((int)TableCards.ThirdCard, (int)TableCards.FourthCard);
                    }
                    if (Rounds == River)
                    {
                        Show((int)TableCards.FourthCard, (int)TableCards.FifthCard);
                    }
                    if (Rounds >= End)
                    {
                        Winner(Player, 1);
                        Winner(Bot1, 0);
                        Winner(Bot2, 0);
                        Winner(Bot3, 0);
                        Winner(Bot4, 0);
                        Winner(Bot5, 2);
                        await Restart();
                    }
                }
            }
        }

        private UsersProperties Winner(UsersProperties inputUser, int options)
        {
            var user = inputUser;
            for (int j = 0; j <= 16; j++)
            {
                if (Holder[j].Visible)
                    Holder[j].Image = Deck[j];
            }
            if (options == 1)
            {
                _sorted.Current = (int)Hand.Combinations.Default;
                _sorted.Power = 0d;
                Win.Clear();
                Player = (Player)RemoveFolded(Player);
                Bot1 = (Bot)RemoveFolded(Bot1);
                Bot2 = (Bot)RemoveFolded(Bot2);
                Bot3 = (Bot)RemoveFolded(Bot3);
                Bot4 = (Bot)RemoveFolded(Bot4);
                Bot5 = (Bot)RemoveFolded(Bot5);
            }
            if (user.Type == _sorted.Current && user.Power == _sorted.Power)
            {
                Timer.Enabled = false;
                _winners++;
                user.Panel.Visible = true;
                if (user.Type == (int)Hand.Combinations.HighCard)
                {
                    MessageBox.Show(user.Name + CombinationNames[0]);
                }
                else
                {
                    MessageBox.Show(user.Name + CombinationNames[user.Type]);
                }
                NewCombinationAchievement(user);
                _addWinners.Add(user.Name);
            }
            if (options != 2) return user;
            Player = (Player)WinnersUpdate(Player);
            Bot1 = (Bot)WinnersUpdate(Bot1);
            Bot2 = (Bot)WinnersUpdate(Bot2);
            Bot3 = (Bot)WinnersUpdate(Bot3);
            Bot4 = (Bot)WinnersUpdate(Bot4);
            Bot5 = (Bot)WinnersUpdate(Bot5);
            return user;
        }
        private UsersProperties WinnersUpdate(UsersProperties user)
        {
            if (!_addWinners.Contains(user.Name)) return user;
            if (user.Name == Player.Name)
            {
                WonHands++;
            }
            else
            {
                LostHands++;
            }
            user.Chips += int.Parse(tbPot.Text) / _winners;
            user.ChipsTextBox.Text = user.Chips.ToString();
            user.Panel.Visible = true;
            UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);
            return user;
        }

        public void EditSettings()
        {
            Properties.Settings.Default.GetStraight = AllAchievements[Achievements.Achievements.Straight.EnumCasted];
            Properties.Settings.Default.GetFlush = AllAchievements[Achievements.Achievements.Flush.EnumCasted];
            Properties.Settings.Default.GetFullHouse = AllAchievements[Achievements.Achievements.FullHouse.EnumCasted];
            Properties.Settings.Default.GetFourOfAKind = AllAchievements[Achievements.Achievements.FourOfAKind.EnumCasted];
            Properties.Settings.Default.GetStraightFlush = AllAchievements[Achievements.Achievements.StraightFlush.EnumCasted];
            Properties.Settings.Default.GetRoyalFlush = AllAchievements[Achievements.Achievements.RoyalFlush.EnumCasted];
        }
        private void NewCombinationAchievement(UsersProperties user)
        {
            if (user != Player || user.Type < (int)Hand.Combinations.Straight) return;
            AllAchievements[user.Type - 4]++;
            Help.UpdateAchievementsList();
            EditSettings();

            if (AchievementRequirements.AchivementList[user.Type - 4].IsUnlocked(AllAchievements[user.Type - 4],
                AchievementRequirements.AchivementList[user.Type - 4].Requirement))
            {
                if (AchievementRequirements.AchivementList[user.Type - 4].Rewards.Item2 != null &&
                    AchievementRequirements.AchivementList[user.Type - 4].Rewards.Item2 >
                    Properties.Settings.Default.StartingChips)
                {
                    var item2 = AchievementRequirements.AchivementList[user.Type - 4].Rewards.Item2;
                    if (item2 != null)
                        Properties.Settings.Default.StartingChips =
                            (int)item2;
                    Properties.Settings.Default.Save();
                    UnlockedNewAchievement(user.Type - 4);
                }
                else if (AchievementRequirements.AchivementList[user.Type - 4].Rewards.Item2 == null)
                {
                    Properties.Settings.Default.Save();
                    UnlockedNewAchievement(user.Type - 4);
                }
            }
            Properties.Settings.Default.Save();
        }
        private static void NewMoneyAchievement()
        {
            Help.UpdateAchievementsList();
            Properties.Settings.Default.GetMoneyF = AllAchievements[Achievements.Achievements.MoneyFirst.EnumCasted];
            Properties.Settings.Default.GetMoneyS = AllAchievements[Achievements.Achievements.MoneySecond.EnumCasted];

            //smenqne na granicite na fora pri dobavqne na novi parichni achi

            for (int j = Achievements.Achievements.MoneyFirst.EnumCasted; j <= Achievements.Achievements.MoneySecond.EnumCasted; j++)
            {
                if (Player.Chips >= AchievementRequirements.AchivementList[j].Requirement)
                {
                    if (AchievementRequirements.AchivementList[j].Rewards.Item2 != null &&
                        AchievementRequirements.AchivementList[j].Rewards.Item2 <
                        Properties.Settings.Default.StartingChips)
                    {
                        Properties.Settings.Default.StartingChips =
                            AchievementRequirements.AchivementList[j].Rewards.Item2;
                        Properties.Settings.Default.Save();
                        UnlockedNewAchievement(j);
                    }
                    else if (AchievementRequirements.AchivementList[j].Rewards.Item2 == null)
                    {
                        if (Player.Chips != null)
                        {
                            Properties.Settings.Default.GetMoneyF = (int)Player.Chips;
                            Properties.Settings.Default.GetMoneyS = (int)Player.Chips;
                        }
                        Properties.Settings.Default.Save();
                        UnlockedNewAchievement(j);
                    }
                }
            }
        }
        private static void UnlockedNewAchievement(int achiNumber)
        {
            AllAchievements[Achievements.Achievements.MoneyFirst.EnumCasted] = Properties.Settings.Default.GetMoneyF;
            AllAchievements[Achievements.Achievements.MoneySecond.EnumCasted] = Properties.Settings.Default.GetMoneyS;
            AllAchievements[Achievements.Achievements.PlayedHands.EnumCasted] = Properties.Settings.Default.GetPlayedHands;
            AllAchievements[Achievements.Achievements.Straight.EnumCasted] = Properties.Settings.Default.GetStraight;
            AllAchievements[Achievements.Achievements.Flush.EnumCasted] = Properties.Settings.Default.GetFlush;
            AllAchievements[Achievements.Achievements.FullHouse.EnumCasted] = Properties.Settings.Default.GetFullHouse;
            AllAchievements[Achievements.Achievements.FourOfAKind.EnumCasted] = Properties.Settings.Default.GetFourOfAKind;
            AllAchievements[Achievements.Achievements.StraightFlush.EnumCasted] = Properties.Settings.Default.GetStraightFlush;
            AllAchievements[Achievements.Achievements.RoyalFlush.EnumCasted] = Properties.Settings.Default.GetRoyalFlush;

            if (!AllAchievementsBools[achiNumber])
            {
                AllAchievementsBools[achiNumber] = true;
                Updates.Enabled = false;
                DialogResult dialogResult =
                    MessageBox.Show(
                        @"You have unlocked new achievement !" + Environment.NewLine +
                        @"Would You like to check it out ?", @"Achievement", MessageBoxButtons.YesNo);

                if (dialogResult != DialogResult.Yes) return;
                Timer.Enabled = false;
                Help.UpdateAchievementsList();
                new Help().ShowNewAchievement(AchievementRequirements.AchivementList[achiNumber]);
            }
        }

        private UsersProperties RemoveFolded(UsersProperties user)
        {
            if (user.StatusLabel.Text.Contains(RepetitiveVariables.Fold))
            {
                user.Type = (int)Hand.Combinations.Default;
                user.Power = 0;
            }
            else
            {
                Combinations(user);
            }
            return user;
        }

        private static Bot Ai(Bot user, ref int previous)
        {
            if (!user.FoldTurn)
            {
                if (Rounds == 0)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if ((_reserve[user.RightCard] / 4 != j || _reserve[user.LeftCard] / 4 != k) &&
                                (_reserve[user.RightCard] / 4 != k || _reserve[user.LeftCard] / 4 != j)) continue;
                            if (Call <= 0)
                            {
                                user = user.Check(user, out previous);
                                goto skip;
                            }
                            if (Call <= user.Chips)
                            {
                                user = user.Call(user, ref previous);
                                goto skip;
                            }
                            user = user.Fold(user);
                            goto skip;
                        }
                    }
                }
                if (user.Type == (int)Hand.Combinations.HighCard || user.Type == (int)Hand.Combinations.PairTable)
                {
                    user.HighCard(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.Pair)
                {
                    user.PairHand(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.TwoPair)
                {
                    user.TwoPair(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.ThreeOfAKind)
                {
                    user.ThreeOfAKind(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.Straight)
                {
                    user.Straight(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.Flush)
                {
                    user.Flush(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.FullHouse)
                {
                    user.FullHouse(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.FourOfAKind)
                {
                    user.FourOfAKind(user, ref previous);
                }
                if (user.Type == (int)Hand.Combinations.StraightFlush ||
                    user.Type == (int)Hand.Combinations.RoyalFlush)
                {
                    user.StraightFlush(user, ref previous);
                }
            }
            skip:
            if (user.StatusLabel.Text.Contains(RepetitiveVariables.Fold))
            {
                Holder[user.RightCard].Visible = false;
                Holder[user.LeftCard].Visible = false;
                user.UsernameLabel.Visible = false;
            }
            if (user.Chips <= 0)
            {
                user.FoldTurn = true;
            }
            if (Call < Raise)
            {
                Call = Convert.ToInt32(Raise);
            }
            return user;
        }

        #region User Interface

        private async void timer_Tick(object sender, object e)
        {
            _help.Shown += (o, k) =>
            {
                Timer.Enabled = false;
                Updates.Enabled = false;
            };

            if (pbTimer.Value <= 0)
            {
                Player.FoldTurn = true;
                Player.Turn = false;
                pStatus.Text = RepetitiveVariables.Fold;
                Folds++;
                ThinkTime = 0;
                UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);
                await Turns();
            }
            if (_t > 0)
            {
                _t--;
                pbTimer.Value = _t / 3 * 100;
            }
        }
        private void Update_Tick(object sender, object e)
        {
            AllAchievements[Achievements.Achievements.MoneyFirst.EnumCasted] = Properties.Settings.Default.GetMoneyF;
            AllAchievements[Achievements.Achievements.MoneySecond.EnumCasted] = Properties.Settings.Default.GetMoneyS;
            AllAchievements[Achievements.Achievements.PlayedHands.EnumCasted] = Properties.Settings.Default.GetPlayedHands;
            NewMoneyAchievement();

            _help.Shown += (o, k) =>
            {
                Timer.Enabled = false;
                Updates.Enabled = false;
            };

            if (_ifFormLoaded)
            {
                Player = (Player)SetStatus(Player);
                Bot1 = (Bot)SetStatus(Bot1);
                Bot2 = (Bot)SetStatus(Bot2);
                Bot3 = (Bot)SetStatus(Bot3);
                Bot4 = (Bot)SetStatus(Bot4);
                Bot5 = (Bot)SetStatus(Bot5);
            }
            Updates.Enabled = true;
            tbPot.Text = Bot.PotText.ToString();
            if (Player.Chips <= 0)
            {
                tbChips.Text = RepetitiveVariables.ChipsZero;
            }
            if (Bot1.Chips <= 0)
            {
                tbBotChips1.Text = RepetitiveVariables.ChipsZero;
            }
            if (Bot2.Chips <= 0)
            {
                tbBotChips2.Text = RepetitiveVariables.ChipsZero;
            }
            if (Bot3.Chips <= 0)
            {
                tbBotChips3.Text = RepetitiveVariables.ChipsZero;
            }
            if (Bot4.Chips <= 0)
            {
                tbBotChips4.Text = RepetitiveVariables.ChipsZero;
            }
            if (Bot5.Chips <= 0)
            {
                tbBotChips5.Text = RepetitiveVariables.ChipsZero;
            }
            tbChips.Text = RepetitiveVariables.Chips + Player.Chips;
            tbBotChips1.Text = RepetitiveVariables.Chips + Bot1.Chips;
            tbBotChips2.Text = RepetitiveVariables.Chips + Bot2.Chips;
            tbBotChips3.Text = RepetitiveVariables.Chips + Bot3.Chips;
            tbBotChips4.Text = RepetitiveVariables.Chips + Bot4.Chips;
            tbBotChips5.Text = RepetitiveVariables.Chips + Bot5.Chips;
            ChipsTextBoxes[0] = tbChips.Text;
            ChipsTextBoxes[1] = tbBotChips1.Text;
            ChipsTextBoxes[2] = tbBotChips2.Text;
            ChipsTextBoxes[3] = tbBotChips3.Text;
            ChipsTextBoxes[4] = tbBotChips4.Text;
            ChipsTextBoxes[5] = tbBotChips5.Text;
            if (Player.Chips <= 0)
            {
                Player.Turn = false;
                Player.FoldTurn = true;
                SetPlayerStuff(false);
                _t = 0;
            }
            if (_up > 0)
            {
                _up--;
            }
            else
            {
                _up = int.MaxValue;
            }
            if (Player.Chips >= Call)
            {
                bCall.Text = RepetitiveVariables.Call + Call;
            }
            else
            {
                bCall.Text = RepetitiveVariables.AllIn;
                bRaise.Enabled = false;
            }
            if (Call > 0)
            {
                bCheck.Enabled = false;
            }
            if (Call <= 0 && Player.Chips > 0)
            {
                bCheck.Enabled = true;
                bCall.Text = RepetitiveVariables.Call;
                bCall.Enabled = false;
            }
            if (Player.Chips <= 0)
            {
                bRaise.Enabled = false;
            }

            int parsedValue;
            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                bRaise.Text = Player.Chips <= int.Parse(tbRaise.Text)
                    ? RepetitiveVariables.AllIn
                    : RepetitiveVariables.Raise;
            }
            if (Player.Chips <= Call)
            {
                bRaise.Enabled = false;
            }
        }

        private async void bFold_Click(object sender, EventArgs e)
        {
            pStatus.Text = RepetitiveVariables.Fold;
            Player.Turn = false;
            Player.FoldTurn = true;
            Folds++;
            UpdateStatistics(Folds, PlayedHands1, LostHands, WonHands);
            Player = (Player)GetStatus(Player);
            await Turns();
        }
        private async void bCheck_Click(object sender, EventArgs e)
        {
            if (Call <= 0)
            {
                Player.Turn = false;
                pStatus.Text = RepetitiveVariables.Check;
            }
            else
            {
                bCheck.Enabled = false;
            }
            Player.PreviousCall = 0;
            Player = (Player)GetStatus(Player);
            await Turns();
        }
        private async void bCall_Click(object sender, EventArgs e)
        {
            Combinations(Player);
            if (Player.Chips >= Call)
            {
                Player.Chips -= Call;
                tbChips.Text = RepetitiveVariables.Chips + Player.Chips;
                tbPot.Text = tbPot.Text != ""
                    ? (Bot.PotText = int.Parse(tbPot.Text) + Call).ToString()
                    : Call.ToString();
                Player.Turn = false;
                pStatus.Text = RepetitiveVariables.Call + TempCall;
                Player.PreviousCall = Call;
            }
            else if (Player.Chips <= Call && Call > 0)
            {
                if (Player.Chips != null)
                {
                    Bot.PotText = int.Parse(tbPot.Text) + (int)Player.Chips;
                    pStatus.Text = RepetitiveVariables.AllIn + Player.Chips;
                }
                Player.Chips = 0;
                tbChips.Text = RepetitiveVariables.Chips + Player.Chips;
                Player.Turn = false;
                bFold.Enabled = false;
                Player.PreviousCall = (int)Player.Chips;
            }
            Player = (Player)GetStatus(Player);
            await Turns();
        }
        private async void bRaise_Click(object sender, EventArgs e)
        {
            Combinations(Player);
            int parsedValue;
            if (tbRaise.Text != "" && int.TryParse(tbRaise.Text, out parsedValue))
            {
                if (Player.Chips > Call)
                {
                    if (int.Parse(tbRaise.Text) < Bb * 2)
                    {
                        tbRaise.Text = (Bb * 2).ToString();
                        MessageBox.Show(@"You must raise atleast twice as the current Big Blind !");
                        return;
                    }
                    if (Raise > 0 && Raise * 2 > int.Parse(tbRaise.Text))
                    {
                        tbRaise.Text = (Raise * 2).ToString();
                        MessageBox.Show(@"You must raise atleast twice as the current raise !");
                        return;
                    }
                    if (Player.Chips >= int.Parse(tbRaise.Text))
                    {
                        Call = int.Parse(tbRaise.Text);
                        TempCall = Call;
                        Raise = int.Parse(tbRaise.Text);
                        pStatus.Text = RepetitiveVariables.Raise + TempCall;
                        Bot.PotText = int.Parse(tbPot.Text) + Call;
                        bCall.Text = RepetitiveVariables.Call;
                        Player.Chips -= int.Parse(tbRaise.Text);
                        Raising = true;
                        Player.PreviousCall = Convert.ToInt32(Raise);
                    }
                    else
                    {
                        if (Player.Chips != null)
                        {
                            Call = (int)Player.Chips;
                            TempCall = Call;
                            Raise = (int)Player.Chips;
                            Bot.PotText = int.Parse(tbPot.Text) + (int)Player.Chips;
                            pStatus.Text = RepetitiveVariables.Raise + TempCall;
                        }
                        Player.Chips = 0;
                        Raising = true;
                        Player.PreviousCall = Convert.ToInt32(Raise);
                    }
                }
            }
            else
            {
                MessageBox.Show(RepetitiveVariables.NumberField);
                return;
            }
            Player.Turn = false;
            Player = (Player)GetStatus(Player);
            await Turns();
        }

        private void settingsHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help helpMenu = new Help(this);
            Timer.Stop();
            Updates.Stop();
            helpMenu.ShowDialog();
        }
        private void editBlindsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbBB.Text = Bb.ToString();
            tbSB.Text = Sb.ToString();
            if (tbBB.Visible == false)
            {
                tbBB.Visible = true;
                tbSB.Visible = true;
                bBB.Visible = true;
                bSB.Visible = true;
            }
            else
            {
                tbBB.Visible = false;
                tbSB.Visible = false;
                bBB.Visible = false;
                bSB.Visible = false;
            }
        }
        private void ProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Profile().ShowDialog();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(tbAdd.Text, out parsedValue))
            {
                MessageBox.Show(RepetitiveVariables.NumberField);
                tbAdd.Text = "";
            }
            else
            {
                if (!_addingChips)
                {
                    if (int.Parse(tbAdd.Text) <= Settings.AddChipsMax)
                    {
                        Player.Chips += int.Parse(tbAdd.Text);
                        Bot1.Chips += int.Parse(tbAdd.Text);
                        Bot2.Chips += int.Parse(tbAdd.Text);
                        Bot3.Chips += int.Parse(tbAdd.Text);
                        Bot4.Chips += int.Parse(tbAdd.Text);
                        Bot5.Chips += int.Parse(tbAdd.Text);
                        _addingChips = true;
                    }
                    else
                    {
                        MessageBox.Show(@"Maximum money you can add per turn is " + Settings.AddChipsMax + @" $.");
                        tbAdd.Text = Settings.AddChipsMax.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(@"You can add chips only once per hand.");
                }
            }
        }
        private void bSB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (tbSB.Text.Contains(",") || tbSB.Text.Contains("."))
            {
                MessageBox.Show(@"The Small Blind cant be a float number !");
                tbSB.Text = Sb.ToString();
                return;
            }
            if (!int.TryParse(tbSB.Text, out parsedValue))
            {
                MessageBox.Show(RepetitiveVariables.NumberField);
                tbSB.Text = Sb.ToString();
                return;
            }
            if (int.Parse(tbSB.Text) > Settings.SmallBlindMax)
            {
                MessageBox.Show(@"The maximum of the Small Blind is " + Settings.SmallBlindMax + @" $.");
                tbSB.Text = Sb.ToString();
            }
            if (int.Parse(tbSB.Text) < Settings.SmallBlindMin)
            {
                MessageBox.Show(@"The minimum of the Small Blind is " + Settings.SmallBlindMin + @" $.");
            }
            if (int.Parse(tbSB.Text) >= Settings.SmallBlindMin && int.Parse(tbSB.Text) <= Settings.SmallBlindMax)
            {
                Sb = int.Parse(tbSB.Text);
                Bb = Sb * 2;
                tbBB.Text = Bb.ToString();
                AutoCloseMsb.Show("The changes have been saved ! They will become available the next hand you play. ",
                    "Blinds", 2000);
            }
        }
        private void bBB_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (tbBB.Text.Contains(",") || tbBB.Text.Contains("."))
            {
                MessageBox.Show(@"The Big Blind cant be a float number !");
                tbBB.Text = Bb.ToString();
                return;
            }
            if (!int.TryParse(tbBB.Text, out parsedValue))
            {
                MessageBox.Show(RepetitiveVariables.NumberField);
                tbBB.Text = Bb.ToString();
                return;
            }
            if (int.Parse(tbBB.Text) > Settings.BigBlindMax)
            {
                MessageBox.Show(@"The maximum of the Big Blind is " + Settings.BigBlindMax + @" $.");
                tbBB.Text = Bb.ToString();
            }
            if (int.Parse(tbBB.Text) < Settings.BigBlindMin)
            {
                MessageBox.Show(@"The minimum of the Big Blind is" + Settings.BigBlindMin + @" $.");
            }
            if (int.Parse(tbBB.Text) >= Settings.BigBlindMin && int.Parse(tbBB.Text) <= Settings.BigBlindMax)
            {
                Bb = int.Parse(tbBB.Text);
                Sb = Bb / 2;
                tbSB.Text = Sb.ToString();
                AutoCloseMsb.Show("The changes have been saved ! They will become available the next hand you play. ",
                    "Blinds", 2000);
            }
        }

        private FormWindowState _lastWindowState = FormWindowState.Minimized;

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == _lastWindowState) return;
            _lastWindowState = WindowState;
            if (WindowState == FormWindowState.Maximized)
            {

            }
            if (WindowState == FormWindowState.Normal)
            {

            }
            if (WindowState == FormWindowState.Minimized)
            {

            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Holder[(int)TableCards.FifthCard] == null) return;
            string hotFold = Properties.Settings.Default.FoldHotkey;
            string hotCheck = Properties.Settings.Default.CheckHotkey;
            string hotCall = Properties.Settings.Default.CallHotkey;
            string hotRaise = Properties.Settings.Default.RaiseHotkey;
            Keys hFold;
            Keys hCheck;
            Keys hCall;
            Keys hRaise;
            Enum.TryParse(hotFold.ToUpper(), out hFold);
            Enum.TryParse(hotCheck.ToUpper(), out hCheck);
            Enum.TryParse(hotCall.ToUpper(), out hCall);
            Enum.TryParse(hotRaise.ToUpper(), out hRaise);
            if (char.ToUpper(e.KeyChar) == (char)hFold)
            {
                bFold_Click(sender, e);
                e.Handled = true;
            }
            if (char.ToUpper(e.KeyChar) == (char)hCheck)
            {
                bCheck_Click(sender, e);
                e.Handled = true;
            }
            if (char.ToUpper(e.KeyChar) == (char)hCall)
            {
                bCall_Click(sender, e);
                e.Handled = true;
            }
            if (char.ToUpper(e.KeyChar) == (char)hRaise)
            {
                bRaise_Click(sender, e);
                e.Handled = true;
            }
        }

        public void UpdateStatistics(int fHands, int pHands, int lHands, int wHands)
        {
            listStatistics.Clear();
            listStatistics.Visible = Properties.Settings.Default.Statistics;
            listStatistics.View = View.Details;
            listStatistics.GridLines = true;

            listStatistics.Columns.Add("Properties", -2, HorizontalAlignment.Left);
            listStatistics.Columns.Add("Fold's", -2, HorizontalAlignment.Left);
            listStatistics.Columns.Add("Played Hands", -2, HorizontalAlignment.Left);
            listStatistics.Columns.Add("Lost Hands", -2, HorizontalAlignment.Left);
            listStatistics.Columns.Add("Won Hands", -2, HorizontalAlignment.Left);
            listStatistics.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            var itemsToAdd = ReturnStatistics(fHands, pHands, lHands, wHands);
            listStatistics.Items.AddRange(new[] { itemsToAdd });
        }
        private static ListViewItem ReturnStatistics(int fHands, int pHands, int lHands, int wHands)
        {
            int[] retStat = { fHands, pHands, lHands, wHands };
            var item1 = new ListViewItem("Totals", 0);
            for (int j = 0; j < retStat.Length; j++)
            {
                int k = j;
                item1.SubItems.Add(retStat[k].ToString());
            }
            return item1;
        }

        public static UsersProperties SetStatus(UsersProperties user)
        {
            user.StatusLabel.Text = StatusLabels[user.EnumCasted];
            user.ChipsTextBox.Text = ChipsTextBoxes[user.EnumCasted];
            return user;
        }
        public static UsersProperties GetStatus(UsersProperties user)
        {
            StatusLabels[user.EnumCasted] = user.StatusLabel.Text;
            ChipsTextBoxes[user.EnumCasted] = user.ChipsTextBox.Text;
            return user;
        }

        #endregion
    }
}
