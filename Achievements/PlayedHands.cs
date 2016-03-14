using System;
using System.Drawing;
using System.Windows.Forms;

namespace Poker.Achievements
{
    public class PlayedHands : AchievementRequirements
    {
        public PlayedHands(int requirement, Tuple<string, int?> rewards)
        {
            Name = "PlayedHands";
            Requirement = requirement;
            EnumCasted = (int)Get.PlayedHands;
            PackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Cards\Pack_Blue", this);
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Back_Blue\Back_Blue.png", this);
            PackPreview = new Bitmap(@"Assets\All_Cards\All_Blue\All_Blue.png");
            PictureBoxImageLayout = ImageLayout.Stretch;
            TitleText = @"Play " + Help.ConvertString(Requirement) + @" Hands";
            RewardLabelText = UpdateRewardLabel(rewards, RewardLabelText);
            Rewards = rewards;
        }
    }
}