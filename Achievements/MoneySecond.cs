using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class MoneySecond : AchievementRequirements
    {
        public MoneySecond(int requirement, Tuple<string, int?> rewards)
        {
            Name = "MoneySecond";
            Requirement = requirement;
            EnumCasted = (int)Get.MoneyS;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Money2.jpg", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Total Chips : " + Help.ConvertString(Requirement);
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}