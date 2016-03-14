using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class MoneyFirst : AchievementRequirements
    {
        public MoneyFirst(int requirement, Tuple<string, int?> rewards)
        {
            Name = "MoneyFirst";
            Requirement = requirement;
            EnumCasted = (int)Get.MoneyF;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Money1.png", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Total Chips : " + Help.ConvertString(Requirement);
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}