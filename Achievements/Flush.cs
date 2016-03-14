using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class Flush : AchievementRequirements
    {
        public Flush(int requirement, Tuple<string, int?> rewards)
        {
            Name = "Flush";
            EnumCasted = (int)Get.Flush;
            Requirement = requirement;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Flush.png", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Get Flush";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}