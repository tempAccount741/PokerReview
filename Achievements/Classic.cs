using System;
using System.Drawing;

namespace Poker.Achievements
{
    public class Classic : AchievementRequirements
    {
        public Classic()
        {
            EnumCasted = (int)Get.Classic;
            PackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Cards\Pack_Classic", this);
            BackInfo = new Tuple<string, AchievementRequirements>(@"Assets\Back\Back_Classic\Back_Classic.png", this);
            PackPreview = new Bitmap(@"Assets\All_Cards\All_Classic\All_Classic.jpg");
        }
    }
}