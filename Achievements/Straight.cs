using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class Straight : AchievementRequirements
    {
        public Straight(int requirement, Tuple<string, int?> rewards)
        {
            Name = "Straight";
            EnumCasted = (int)Get.Straight;
            Requirement = requirement;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Straight.png", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Get Straight";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}