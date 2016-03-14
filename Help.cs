using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Poker.Achievements;

namespace Poker
{
    public partial class Help : Form
    {
        #region Variables

        private readonly CreatePanels _createAchivementPanels = new CreatePanels();

        private readonly List<Tuple<string, AchievementRequirements>> _packNames = new List<Tuple<string, AchievementRequirements>>();
        private readonly List<Tuple<string, AchievementRequirements>> _backNames = new List<Tuple<string, AchievementRequirements>>();
        private readonly List<Bitmap> _rotateBacks = new List<Bitmap>();
        private readonly List<Bitmap> _rotatePacks = new List<Bitmap>();

        public string NewPack { get; set; }
        public string NewBack { get; set; }

        public static AchievementRequirements AchievementNumber;

        private bool _showCardBacks,
                     _showCardPacks = true;
        private readonly List<string> _pressedButtons = new List<string>();
        private readonly List<string> _buttonNames = new List<string> { "HowButtons", "CombButtons", "HotButtons", "AButtons", "SButtons", "AchiButtons" };
        private readonly List<Panel> _panels = new List<Panel>();
        private Button[] _howButtons = new Button[3];
        private Button[] _combButtons = new Button[1];
        private Button[] _hotButtons = new Button[1];
        private Button[] _aButtons = new Button[3];
        private Button[] _sButtons = new Button[1];
        private Button[] _achiButtons = new Button[1];
        #endregion

        public Help()
        {
            InitializeComponent();
        }
        private readonly MainPoker _mainForm;

        public Help(Form callingForm)
        {
            _mainForm = callingForm as MainPoker;
            InitializeComponent();
        }

        private void bHow_Click(object sender, EventArgs e)
        {
            var buttonNames = new List<string> { "Dealing the Cards", "Blinds", "Rotating and Betting" };
            var labelTexts = new List<string>
            {
                @"Assets\Help\How To Play\EHtexts\EHtext1.txt",
                @"Assets\Help\How To Play\EHtexts\EHtext2.txt",
                @"Assets\Help\How To Play\EHtexts\EHtext3.txt"
            };
            CheckHs("HowButtons", buttonNames, ref _howButtons, 3);
            pHot.Visible = false;
            pCombinations.Visible = false;
            pSettings.Visible = false;
            pAchievementsCards.Visible = false;
            DisplayText(ref _howButtons, labelTexts, tbH1);
        }
        private void bCombinations_Click(object sender, EventArgs e)
        {
            List<string> buttonNames = new List<string> { "Combinations" };
            CheckHs("CombButtons", buttonNames, ref _combButtons, 1);
            HidePanels(pCombinations);
        }
        private void bHotkeys_Click(object sender, EventArgs e)
        {
            List<string> buttonNames = new List<string> { "HotKeys" };
            CheckHs("HotButtons", buttonNames, ref _hotButtons, 1);
            HidePanels(pHot);
        }
        private void bAbout_Click(object sender, EventArgs e)
        {
            List<string> buttonNames = new List<string> { "Credits", "Contacts", "Suggestions" };
            CheckHs("AButtons", buttonNames, ref _aButtons, 3);
        }
        private void bSettings_Click(object sender, EventArgs e)
        {
            List<string> buttonNames = new List<string> { "Settings" };
            CheckHs("SButtons", buttonNames, ref _sButtons, 1);
            HidePanels(pSettings);
        }
        private void bAchivements_Click(object sender, EventArgs e)
        {
            List<string> buttonNames = new List<string> { "Combinations" };
            List<Panel> achiPanels = new List<Panel> { pAchievementsCards };
            CheckHs("AchiButtons", buttonNames, ref _achiButtons, 1);
            DisplayText(ref _achiButtons, achiPanels);
            HidePanels(pAchievementsCards);
        }

        private void HidePanels(IDisposable currentPanel)
        {
            tbH1.Visible = false;
            int visiblePanel = 0;
            for (int i = 0; i < _panels.Count; i++)
            {
                if (Equals(currentPanel, _panels[i]))
                    visiblePanel = i;
            }
            foreach (var panel in _panels)
            {
                panel.Visible = false;
            }
            _panels[visiblePanel].Location = new Point(lbTopLine.Location.X, lbTopLine.Location.Y + 5);
            _panels[visiblePanel].Visible = !_panels[visiblePanel].Visible;
        }

        private Button[] CreatingButtons(int n, IReadOnlyList<string> names)
        {
            Button[] buttons = new Button[n];
            const int height = 33;
            int width = lbTopLine.Width / buttons.Length;
            int horizontal = lbTopLine.Location.X;
            int vertical = lbTopLine.Location.Y - height;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button
                {
                    Height = height,
                    Width = width
                };
                Controls.Add(buttons[i]);
                buttons[i].Text = names[i];
                buttons[i].TextAlign = ContentAlignment.MiddleCenter;
                buttons[i].Location = new Point(horizontal, vertical);
                horizontal += buttons[i].Width;
            }
            return buttons;
        }
        private void CheckHs(string current, IReadOnlyList<string> currentButtonNames, ref Button[] buttonArray, int n)
        {
            if (!_pressedButtons.Contains(current))
            {
                _pressedButtons.Add(current);
                buttonArray = CreatingButtons(n, currentButtonNames);
            }
            else
            {
                foreach (Button t in buttonArray)
                {
                    t.Visible = false;
                    //add about info
                }
                _pressedButtons.Clear();
            }
            if (_pressedButtons.ToArray().Length > 1)
            {
                _pressedButtons.Remove(current);
                for (int i = 0; i < _buttonNames.ToArray().Length; i++)
                {
                    if (_pressedButtons[0] != _buttonNames[i]) continue;
                    HideB(0, i);
                    HideB(1, i);
                    HideB(2, i);
                    HideB(3, i);
                    HideB(4, i);
                    HideB(5, i);
                    break;
                }
                _pressedButtons.Clear();
                _pressedButtons.Add(current);
            }
        }
        private void HideB(int x, int i)
        {
            var hideButtons = new Button[1];
            if (x == 0)
            {
                hideButtons = _howButtons;
            }
            if (x == 1)
            {
                hideButtons = _combButtons;
            }
            if (x == 2)
            {
                hideButtons = _hotButtons;
            }
            if (x == 3)
            {
                hideButtons = _aButtons;
            }
            if (x == 4)
            {
                hideButtons = _sButtons;
            }
            if (x == 5)
            {
                hideButtons = _achiButtons;
            }
            if (i == x)
            {
                foreach (Button t in hideButtons)
                {
                    t.Visible = false;
                    //add about info
                }
            }
        }

        private static void DisplayText(ref Button[] arrayB, IReadOnlyList<string> paths, TextBox display)
        {
            for (int i = 0; i < arrayB.Length; i++)
            {
                int j = i;
                arrayB[j].Click += (o, k) =>
                {
                    using (var streamReader = new StreamReader(paths[j], Encoding.UTF8))
                    {
                        display.Visible = true;
                        display.Text = streamReader.ReadToEnd();
                    }
                };
            }
        }
        private static void DisplayText(ref Button[] arrayB, IReadOnlyList<Panel> panels)
        {
            if (arrayB.Length > 1)
            {
                for (int i = 0; i < arrayB.Length; i++)
                {
                    int j = i;
                    arrayB[j].Click += (o, k) =>
                    {
                        panels[j].Visible = true;
                        try
                        {
                            panels[j - 1].Visible = false;
                        }
                        catch (Exception)
                        {
                            panels[j + 1].Visible = false;
                        }
                    };
                }
            }
            else
            {
                arrayB[0].Click += (o, k) =>
                {
                    panels[0].Visible = true;
                };
            }
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            HotFold.Text = @"F";
            HotCheck.Text = @"H";
            HotCall.Text = @"C";
            HotRaise.Text = @"R";
            Properties.Settings.Default.FoldHotkey = "F";
            Properties.Settings.Default.CheckHotkey = "H";
            Properties.Settings.Default.CallHotkey = "C";
            Properties.Settings.Default.RaiseHotkey = "R";
            Properties.Settings.Default.Save();
            MessageBox.Show(@"Hotkeys were returned to they're original values.");
        }
        private void bApply_Click(object sender, EventArgs e)
        {
            bool finish = false;
            string[] duplicates = { HotFold.Text, HotCheck.Text, HotCall.Text, HotRaise.Text };
            for (int i = 0; i < duplicates.Length; i++)
            {
                for (int j = i + 1; j < duplicates.Length; j++)
                {
                    if (duplicates[i] != duplicates[j] && duplicates[i] != duplicates[j].ToUpper() &&
                        duplicates[i].ToUpper() != duplicates[j]) continue;
                    if (finish) continue;
                    MessageBox.Show(@"You cant assign two or more hotkeys to one key !");
                    bReset_Click(sender, e);
                    finish = true;
                }
            }
            if (finish) return;
            if (HotFold.Text.Length > 1 || HotCheck.Text.Length > 1 ||
                HotCall.Text.Length > 1 || HotRaise.Text.Length > 1)
            {
                MessageBox.Show(@"You cant assign a hotkey to a combination of keys !");
                bReset_Click(sender, e);
            }
            else
            {
                Properties.Settings.Default.FoldHotkey = HotFold.Text;
                Properties.Settings.Default.CheckHotkey = HotCheck.Text;
                Properties.Settings.Default.CallHotkey = HotCall.Text;
                Properties.Settings.Default.RaiseHotkey = HotRaise.Text;
                Properties.Settings.Default.Save();
                AutoCloseMsb.Show("Your changes have been saved !", "Hotkeys", 2000);
            }
        }

        public static string ConvertString(int? number)
        {
            string newNumber = number + "";
            if (number < 1000 && number > 0)
            {
                newNumber = number + "";
            }
            if (number > 999) //ima samo k poneje ako ima M i imash mnogo malko pari shte izgl mnogo grozno 0.001M; 
            {
                newNumber = number / 1000 + "k";
            }
            return newNumber;
        }

        private void Help_Load(object sender, EventArgs e)
        {
            _panels.Add(pCombinations);
            _panels.Add(pSettings);
            _panels.Add(pAchievementsCards);
            _panels.Add(pHot);

            UpdateAchievementsList();
            _backNames.Add(Achievements.Achievements.Classic.BackInfo);
            _rotateBacks.Add(new Bitmap(Achievements.Achievements.Classic.BackInfo.Item1));
            _packNames.Add(Achievements.Achievements.Classic.PackInfo);
            _rotatePacks.Add(new Bitmap(Achievements.Achievements.Classic.PackPreview));
            foreach (var achi in AchievementRequirements.AchivementList)
            {
                if (!Equals(achi, Achievements.Achievements.Classic))
                    _createAchivementPanels.PanelForAchievements(this, pAchievementsCards, achi);
                _backNames.Add(achi.BackInfo);
                _rotateBacks.Add(new Bitmap(achi.BackInfo.Item1));

                if (achi.PackInfo == null) continue;
                _packNames.Add(achi.PackInfo);
                _rotatePacks.Add(new Bitmap(achi.PackPreview));
            }
            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender1, e1) => { pAchievementsCards.VerticalScroll.Value = vScrollBar1.Value; };
            pAchievementsCards.Controls.Add(vScrollBar1);
            for (int i = 0; i < _packNames.Count; i++)
            {
                if (Properties.Settings.Default.CardPack == _packNames[i].Item1)
                {
                    pickCards.Image = _rotatePacks[i];
                }
            }

            Bitmap narrow = new Bitmap(@"Assets\Help\Arrows\NextArrow.png");
            Bitmap parrow = new Bitmap(@"Assets\Help\Arrows\NextArrow.png");
            parrow.RotateFlip(RotateFlipType.Rotate180FlipY);
            bNext.BackgroundImage = narrow;
            bPrevious.BackgroundImage = parrow;
            tbThink.Text = (Properties.Settings.Default.ThinkingTime / 1000).ToString();
            HotFold.Text = Properties.Settings.Default.FoldHotkey;
            HotCheck.Text = Properties.Settings.Default.CheckHotkey;
            HotCall.Text = Properties.Settings.Default.CallHotkey;
            HotRaise.Text = Properties.Settings.Default.RaiseHotkey;
            cbStatistics.Checked = Properties.Settings.Default.Statistics;
            if (Properties.Settings.Default.ThinkCheck)
            {
                cbThinkTime.Checked = true;
                cbSkipThinkTime.Checked = false;
                pThink.Visible = true;
            }
            else
            {
                cbThinkTime.Checked = false;
                cbSkipThinkTime.Checked = true;
                pThink.Visible = false;
            }
        }

        public void ShowNewAchievement(AchievementRequirements newAchi)
        {
            HidePanels(pAchievementsCards);
            foreach (var achi in AchievementRequirements.AchivementList)
            {
                if (!Equals(achi, Achievements.Achievements.Classic))
                    _createAchivementPanels.PanelForAchievements(this, pAchievementsCards, achi);
                _backNames.Add(achi.BackInfo);
                _rotateBacks.Add(new Bitmap(achi.BackInfo.Item1));

                if (achi.PackInfo == null) continue;
                _packNames.Add(achi.PackInfo);
                _rotatePacks.Add(new Bitmap(achi.PackPreview));
            }
            foreach (Panel panel in pAchievementsCards.Controls.Cast<Panel>().Where(panel => panel.Name == @"pGet" + newAchi.Name))
            {
                panel.Focus();
                pAchievementsCards.ScrollControlIntoView(panel);
                CreatePanels.TempPanel = panel;
                panel.Paint += new CreatePanels().UnlockNewAchivementBorder_Paint;
                break;
            }
            ShowDialog();
        }
        public static void UpdateAchievementsList()
        {
            AchievementRequirements.AchivementList.Clear();
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.Straight);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.Flush);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.FullHouse);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.FourOfAKind);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.StraightFlush);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.RoyalFlush);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.MoneyFirst);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.MoneySecond);
            AchievementRequirements.AchivementList.Add(Achievements.Achievements.PlayedHands);
        }

        public void cbStatistics_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatistics.Checked)
            {
                _mainForm.listStatistics.Visible = true;
                Properties.Settings.Default.Statistics = true;
            }
            else
            {
                _mainForm.listStatistics.Visible = false;
                Properties.Settings.Default.Statistics = false;
            }
            Properties.Settings.Default.Save();
        }
        private void bClearStatistics_Click(object sender, EventArgs e)
        {
            _mainForm.Folds = 0;
            _mainForm.WonHands = 0;
            _mainForm.LostHands = 0;
            _mainForm.PlayedHands1 = 0;
            _mainForm.UpdateStatistics(_mainForm.Folds, _mainForm.PlayedHands1, _mainForm.LostHands, _mainForm.WonHands);
        }
        private void cbThinkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThinkTime.Checked)
            {
                cbSkipThinkTime.Checked = false;
                pThink.Visible = true;
                Properties.Settings.Default.ThinkCheck = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                cbSkipThinkTime.Checked = true;
                pThink.Visible = false;
                Properties.Settings.Default.ThinkCheck = false;
                Properties.Settings.Default.Save();
            }
        }
        private void cbSkipThinkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSkipThinkTime.Checked)
            {
                cbThinkTime.Checked = false;
                Properties.Settings.Default.ThinkingTime = 3000;
                tbThink.Text = (Properties.Settings.Default.ThinkingTime / 1000).ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                cbThinkTime.Checked = true;
                pThink.Visible = true;
            }
        }
        private void bThinkTime_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(tbThink.Text, out parsedValue))
            {
                MessageBox.Show(@"This is a number only field");
            }
            else
            {
                if (int.Parse(tbThink.Text) <= 0 || int.Parse(tbThink.Text) > 100)
                {
                    MessageBox.Show(@"You cant assign value lower than 0 and value higher than 100.");
                }
                else
                {
                    MainPoker.ThinkTime = int.Parse(tbThink.Text) * 1000;
                    AutoCloseMsb.Show("Your changes have been saved !", "Settings", 2000);
                    Properties.Settings.Default.ThinkingTime = MainPoker.ThinkTime;
                    Properties.Settings.Default.Save();

                }
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            MainPoker.Updates.Start();
            MainPoker.Timer.Start();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            Bitmap currentImage = (Bitmap)pickCards.Image;
            if (_showCardPacks)
            {
                for (int i = 0; i < _rotatePacks.Count; i++)
                {
                    if (!AreEqual(currentImage, _rotatePacks[i])) continue;
                    try
                    {
                        pickCards.Image = _rotatePacks[i + 1];

                        NewPack = _packNames[i + 1].Item1;
                        NewBack = _backNames[i + 1].Item1;

                        AchievementNumber = _packNames[i + 1].Item2;
                    }
                    catch (Exception)
                    {
                        pickCards.Image = _rotatePacks[0];
                        NewPack = _packNames[0].Item1;
                        NewBack = _backNames[0].Item1;

                        AchievementNumber = _packNames[0].Item2;
                    }
                }
            }
            else if (_showCardBacks)
            {
                for (int i = 0; i < _rotateBacks.Count; i++)
                {
                    if (!AreEqual(currentImage, _rotateBacks[i])) continue;
                    try
                    {
                        pickCards.Image = _rotateBacks[i + 1];
                        NewBack = _backNames[i + 1].Item1;

                        AchievementNumber = _backNames[i + 1].Item2;
                    }
                    catch (Exception)
                    {
                        pickCards.Image = _rotateBacks[0];
                        NewBack = _backNames[0].Item1;

                        AchievementNumber = _backNames[0].Item2;
                    }
                }
            }
        }
        private void bPrevious_Click(object sender, EventArgs e)
        {
            Bitmap currentImage = (Bitmap)pickCards.Image;
            if (_showCardPacks)
            {
                for (int i = 0; i < _rotatePacks.Count; i++)
                {
                    if (!AreEqual(currentImage, _rotatePacks[i])) continue;
                    try
                    {
                        pickCards.Image = _rotatePacks[i - 1];

                        NewPack = _packNames[i - 1].Item1;
                        NewBack = _backNames[i - 1].Item1;

                        AchievementNumber = _packNames[i - 1].Item2;
                    }
                    catch (Exception)
                    {
                        pickCards.Image = _rotatePacks[_rotatePacks.Count - 1];
                        NewPack = _packNames[_packNames.Count - 1].Item1;
                        NewBack = _backNames[_backNames.Count - 1].Item1;

                        AchievementNumber = _packNames[_packNames.Count - 1].Item2;
                    }
                }
            }
            else if (_showCardBacks)
            {
                for (int i = 0; i < _rotateBacks.Count; i++)
                {
                    if (!AreEqual(currentImage, _rotateBacks[i])) continue;
                    try
                    {
                        pickCards.Image = _rotateBacks[i - 1];
                        NewBack = _backNames[i - 1].Item1;

                        AchievementNumber = _backNames[i - 1].Item2;
                    }
                    catch (Exception)
                    {
                        pickCards.Image = _rotateBacks[_rotateBacks.Count - 1];
                        NewBack = _backNames[_backNames.Count - 1].Item1;

                        AchievementNumber = _backNames[_backNames.Count - 1].Item2;
                    }
                }
            }
        }
        private void bPickCard_Click(object sender, EventArgs e)
        {
            if (bPickCard.Text == @"Pick card pack" && NewPack != "")
            {
                if (!IsAvailable(AchievementNumber, "Pack")) return;
                Properties.Settings.Default.CardPack = NewPack;
                Properties.Settings.Default.CardBack = NewBack;
                Properties.Settings.Default.Save();
                MainPoker.ReplacePacks();
                MessageBox.Show(@"Your new card pack is now enabled !");
            }
            else if (bPickCard.Text == @"Pick card back" && NewBack != "")
            {
                if (!IsAvailable(AchievementNumber, "Back")) return;
                Properties.Settings.Default.CardBack = NewBack;
                Properties.Settings.Default.Save();
                MainPoker.ReplaceBacks();
                MessageBox.Show(@"Your new card back is now enabled !");
            }
        }

        private static bool IsAvailable(AchievementRequirements achievement, string options)
        {
            if (achievement == Achievements.Achievements.Classic) return true;
            if (achievement != null)
            {
                if (MainPoker.AllAchievements[achievement.EnumCasted] >= achievement.Requirement)
                {
                    return true;
                }
                MessageBox.Show(options == "Pack"
                    ? @"You haven't unlocked this card pack yet !"
                    : @"You haven't unlocked this card back yet !");
            }
            return false;
        }

        private void CardBacks_Click(object sender, EventArgs e)
        {
            pickCards.SizeMode = PictureBoxSizeMode.Zoom;
            _showCardBacks = true;
            _showCardPacks = false;
            pickCards.Image = new Bitmap(Achievements.Achievements.Classic.BackInfo.Item1);
            bPickCard.Text = @"Pick card back";
        }
        private void CardPacks_Click(object sender, EventArgs e)
        {
            pickCards.SizeMode = PictureBoxSizeMode.StretchImage;
            _showCardPacks = true;
            _showCardBacks = false;
            pickCards.Image = _rotatePacks[0];
            bPickCard.Text = @"Pick card pack";
        }

        public static unsafe bool AreEqual(Bitmap b1, Bitmap b2) // copy pasted
        {
            if (b1 == b2)
                return true;
            if (b1.Size != b2.Size || b1.PixelFormat != b2.PixelFormat)
                return false;

            /*if (b1.PixelFormat != PixelFormat.Format32bppArgb)
            {
                return false;
            }*/
            Rectangle rect = new Rectangle(0, 0, b1.Width, b1.Height);
            BitmapData data1
                = b1.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
            BitmapData data2
                = b2.LockBits(rect, ImageLockMode.ReadOnly, b1.PixelFormat);
            int* p1 = (int*)data1.Scan0;
            int* p2 = (int*)data2.Scan0;
            int byteCount = b1.Height * data1.Stride / 4; //only Format32bppArgb 

            bool result = true;
            for (int i = 0; i < byteCount; ++i)
            {
                if (*p1++ == *p2++) continue;
                result = false;
                break;
            }

            b1.UnlockBits(data1);
            b2.UnlockBits(data2);

            return result;
        }
    }
}