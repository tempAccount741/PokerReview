using System.Drawing;
using System.Windows.Forms;
using Poker.Achievements;

namespace Poker
{
    public class CreatePanels
    {
        public enum PanelAchievementEnum
        {
            FlowLayoutPanel = 0,
            Panel = 1,
            LabelCondition = 2,
            LabelReward = 3,
            CheckBox = 4,
            PictureBox = 5,
        }
        public static Panel TempPanel = new Panel();
        public void PanelForAchievements(Form currentForm, FlowLayoutPanel flp, AchievementRequirements achievement)
        {
            FlowLayoutPanel retFlp = flp;
            string pGetAchivementName = @"pGet" + achievement.Name;
            string lbAchivementName = @"lb" + achievement.Name;
            string lbAchivementRewardName = @"lb" + achievement.Name + @"Reward";
            string cbGetAchivementName = @"cbGet" + achievement.Name;
            string pbAchivementName = @"pb" + achievement.Name;
            var pGetAchivement = new Panel
            {
                Name = pGetAchivementName,
                Size = new Size(350, 100),
                BorderStyle = BorderStyle.FixedSingle,
            };
            currentForm.Controls.Add(pGetAchivement);

            var lbAchivement = new Label
            {
                Name = lbAchivementName,
                Location = new Point(pGetAchivement.Location.X + 5, pGetAchivement.Location.Y + 5),
                Size = new Size(135, 30),
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, (byte)0),
                Text = achievement.TitleText,
            };

            var lbAchivementReward = new Label
            {
                Name = lbAchivementRewardName,
                AutoSize = true,
                Top = (pGetAchivement.Height - pGetAchivement.Height) / 2,
                Text = achievement.RewardLabelText,
                TabIndex = 2,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(lbAchivement.Location.X, lbAchivement.Location.Y + lbAchivement.Height + 5)
            };

            var cbGetAchivement = new CheckBox
            {
                Name = cbGetAchivementName,
                AutoCheck = false,
                AutoSize = true,
                Location = new Point(lbAchivement.Location.X + lbAchivement.Width + 10, lbAchivement.Location.Y + 5),
                TabIndex = 1,
                UseVisualStyleBackColor = true
            };
            achievement.IsUnlocked(MainPoker.AllAchievements[achievement.EnumCasted], achievement.Requirement,
                cbGetAchivement);

            var pbAchivement = new PictureBox
            {
                Name = pbAchivementName,
                BackgroundImage = achievement.PackPreview,
                BackgroundImageLayout = achievement.PictureBoxImageLayout,
                Size = new Size(140, pGetAchivement.Height - 10),
                TabIndex = 9,
                TabStop = false,
            };
            pbAchivement.Location = new Point(pGetAchivement.Location.X + pGetAchivement.Width - pbAchivement.Width - 5,
                pGetAchivement.Location.Y + 3);

            pGetAchivement.Controls.Add(lbAchivement);
            pGetAchivement.Controls.Add(lbAchivementReward);
            pGetAchivement.Controls.Add(cbGetAchivement);
            pGetAchivement.Controls.Add(pbAchivement);

            retFlp.Controls.Add(pGetAchivement);

            achievement.Title = lbAchivement;
            achievement.RewardLabel = lbAchivementReward;
            achievement.Unlocked = cbGetAchivement;
            achievement.Preview = pbAchivement;
        }

        public void UnlockNewAchivementBorder_Paint(object sender, PaintEventArgs e)
        {
            if (TempPanel.BorderStyle != BorderStyle.FixedSingle) return;
            const int thickness = 3;
            const int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.FromArgb(37, 107, 187), thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                    halfThickness,
                    TempPanel.ClientSize.Width - thickness,
                    TempPanel.ClientSize.Height - thickness));
            }
        }
    }
}
