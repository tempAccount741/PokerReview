using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class FourOfAKind : AchievementRequirements
    {
        public FourOfAKind(int requirement, Tuple<string, int?> rewards)
        {
            Name = "FourOfAKind";
            EnumCasted = (int)Get.FourOfAKind;
            Requirement = requirement;
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\FourOfAKind.png", this);
            PackPreview = new Bitmap(BackInfo.Item1);
            PictureBoxImageLayout = ImageLayout.Zoom;
            TitleText = @"Get Four Of A Kind";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}