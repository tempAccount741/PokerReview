using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class StraightFlush : AchievementRequirements
    {
        public StraightFlush(int requirement, Tuple<string, int?> rewards)
        {
            Name = "StraightFlush";
            EnumCasted = (int)Get.StraightFlush;
            Requirement = requirement;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\StraightFlush.png", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Get Straight Flush";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}