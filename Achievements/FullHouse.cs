using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class FullHouse : AchievementRequirements
    {
        public FullHouse(int requirement, Tuple<string, int?> rewards)
        {
            Name = "FullHouse";
            EnumCasted = (int)Get.FullHouse;
            Requirement = requirement;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\FullHouse.jpg", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Get Full House";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}