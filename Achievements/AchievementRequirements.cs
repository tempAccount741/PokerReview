using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class AchievementRequirements
    {
        public enum Get
        {
            Classic = -1,
            Straight = 0,
            Flush = 1,
            FullHouse = 2,
            FourOfAKind = 3,
            StraightFlush = 4,
            RoyalFlush = 5,
            MoneyF = 6,
            MoneyS = 7,
            PlayedHands = 8
        }

        public string StartH { get; } = @" Starting hand";
        public string TotalC { get; } = @"Total Chips";
        public string RewardT { get; } = @"Reward : ";

        public string Name { get; set; }
        public string TitleText { get; set; }
        public string RewardLabelText { get; set; }
        public int EnumCasted { get; set; }
        public int Requirement { get; set; }
        public Tuple<string, int?> Rewards { get; set; }
        public Tuple<string, AchievementRequirements> PackInfo { get; set; }
        public Tuple<string, AchievementRequirements> BackInfo { get; set; }
        public Bitmap PackPreview { get; set; }
        public Label Title { get; set; }
        public Label RewardLabel { get; set; }
        public CheckBox Unlocked { get; set; }
        public PictureBox Preview { get; set; }
        public ImageLayout PictureBoxImageLayout { get; set; }

        public static List<AchievementRequirements> AchivementList { get; } = new List<AchievementRequirements>();

        public void IsUnlocked(int currentProgress, int requirement, CheckBox unlock)
        {
            if (currentProgress >= requirement)
            {
                unlock.Checked = true;
                unlock.Text = Help.ConvertString(requirement) + @" / " + Help.ConvertString(requirement);
            }
            else
            {
                unlock.Checked = false;
                unlock.Text = Help.ConvertString(currentProgress) + @" / " + Help.ConvertString(requirement);
            }
        }
        public bool IsUnlocked(int currentProgress, int requirement)
        {
            return currentProgress >= requirement;
        }

        public string UpdateRewardLabel(Tuple<string, int?> inputRewards, string inputString)
        {
            if (inputRewards.Item1 != null && inputRewards.Item2 != null)
            {
                inputString = RewardT + inputRewards.Item1 + Environment.NewLine + Help.ConvertString(inputRewards.Item2) + StartH;
            }
            else if (inputRewards.Item2 == null)
            {
                inputString = RewardT + inputRewards.Item1;
            }
            else if (inputRewards.Item1 == null)
            {
                inputString = RewardT + Help.ConvertString(inputRewards.Item2) + StartH;
            }
            return inputString;
        }
    }
}