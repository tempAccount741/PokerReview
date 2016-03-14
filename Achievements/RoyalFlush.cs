using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class RoyalFlush : AchievementRequirements
    {
        public RoyalFlush(int requirement, Tuple<string, int?> rewards)
        {
            Name = "RoyalFlush";
            EnumCasted = (int)Get.RoyalFlush;
            Requirement = requirement;
            PackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Cards\Pack_Royal\", this);
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Back_Royal\Back_Royal.png", this);
            PackPreview = new Bitmap(@"Assets\All_Cards\All_Royal\All_Royal.png");
            PictureBoxImageLayout = ImageLayout.Stretch;
            TitleText = @"Get Royal Flush";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}