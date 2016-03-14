using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Poker.Properties;
using Poker.Users;

namespace Poker
{
    partial class MainPoker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bFold = new Button();
            this.bCheck = new Button();
            this.bCall = new Button();
            this.bRaise = new Button();
            this.pbTimer = new ProgressBar();
            this.tbChips = new TextBox();
            this.bAdd = new Button();
            this.tbAdd = new TextBox();
            this.tbBotChips5 = new TextBox();
            this.tbBotChips4 = new TextBox();
            this.tbBotChips3 = new TextBox();
            this.tbBotChips2 = new TextBox();
            this.tbBotChips1 = new TextBox();
            this.tbPot = new TextBox();
            this.bBB = new Button();
            this.tbSB = new TextBox();
            this.bSB = new Button();
            this.tbBB = new TextBox();
            this.b5Status = new Label();
            this.b4Status = new Label();
            this.b3Status = new Label();
            this.b1Status = new Label();
            this.pStatus = new Label();
            this.b2Status = new Label();
            this.label1 = new Label();
            this.tbRaise = new TextBox();
            this.pChipsTop = new Label();
            this.listStatistics = new ListView();
            this.menuStrip1 = new MenuStrip();
            this.settingsToolStripMenuItem = new ToolStripMenuItem();
            this.settingsHelpToolStripMenuItem = new ToolStripMenuItem();
            this.editBlindsToolStripMenuItem = new ToolStripMenuItem();
            this.ProfileToolStripMenuItem = new ToolStripMenuItem();
            this.playerName = new Label();
            this.bot1Name = new Label();
            this.bot2Name = new Label();
            this.bot3Name = new Label();
            this.bot4Name = new Label();
            this.bot5Name = new Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bFold
            // 
            this.bFold.Anchor = AnchorStyles.Bottom;
            this.bFold.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.bFold.Location = new Point(364, 643);
            this.bFold.Name = "bFold";
            this.bFold.Size = new Size(130, 53);
            this.bFold.TabIndex = 0;
            this.bFold.Text = "Fold";
            this.bFold.UseVisualStyleBackColor = true;
            this.bFold.Click += new EventHandler(this.bFold_Click);
            // 
            // bCheck
            // 
            this.bCheck.Anchor = AnchorStyles.Bottom;
            this.bCheck.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.bCheck.Location = new Point(524, 643);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new Size(130, 53);
            this.bCheck.TabIndex = 2;
            this.bCheck.Text = "Check";
            this.bCheck.UseVisualStyleBackColor = true;
            this.bCheck.Click += new EventHandler(this.bCheck_Click);
            // 
            // bCall
            // 
            this.bCall.Anchor = AnchorStyles.Bottom;
            this.bCall.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.bCall.Location = new Point(684, 643);
            this.bCall.Name = "bCall";
            this.bCall.Size = new Size(130, 53);
            this.bCall.TabIndex = 3;
            this.bCall.Text = "Call";
            this.bCall.UseVisualStyleBackColor = true;
            this.bCall.Click += new EventHandler(this.bCall_Click);
            // 
            // bRaise
            // 
            this.bRaise.Anchor = AnchorStyles.Bottom;
            this.bRaise.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.bRaise.Location = new Point(844, 643);
            this.bRaise.Name = "bRaise";
            this.bRaise.Size = new Size(130, 53);
            this.bRaise.TabIndex = 4;
            this.bRaise.Text = "Raise";
            this.bRaise.UseVisualStyleBackColor = true;
            this.bRaise.Click += new EventHandler(this.bRaise_Click);
            // 
            // pbTimer
            // 
            this.pbTimer.Anchor = AnchorStyles.Bottom;
            this.pbTimer.BackColor = SystemColors.Control;
            this.pbTimer.Location = new Point(364, 702);
            this.pbTimer.Maximum = 1000;
            this.pbTimer.Name = "pbTimer";
            this.pbTimer.Size = new Size(610, 22);
            this.pbTimer.TabIndex = 5;
            this.pbTimer.Value = 1000;
            // 
            // tbChips
            // 
            this.tbChips.Anchor = AnchorStyles.Bottom;
            this.tbChips.Enabled = false;
            this.tbChips.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbChips.Location = new Point(755, 550);
            this.tbChips.Multiline = true;
            this.tbChips.Name = "tbChips";
            this.tbChips.Size = new Size(125, 20);
            this.tbChips.TabIndex = 6;
            this.tbChips.Text = "Chips : 0";
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.bAdd.Location = new Point(12, 697);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new Size(75, 25);
            this.bAdd.TabIndex = 7;
            this.bAdd.Text = "AddChips";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new EventHandler(this.bAdd_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.tbAdd.Location = new Point(93, 700);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new Size(125, 20);
            this.tbAdd.TabIndex = 8;
            // 
            // tbBotChips5
            // 
            this.tbBotChips5.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.tbBotChips5.Enabled = false;
            this.tbBotChips5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips5.Location = new Point(998, 550);
            this.tbBotChips5.Multiline = true;
            this.tbBotChips5.Name = "tbBotChips5";
            this.tbBotChips5.Size = new Size(125, 20);
            this.tbBotChips5.TabIndex = 9;
            this.tbBotChips5.Text = "Chips : 0";
            // 
            // tbBotChips4
            // 
            this.tbBotChips4.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.tbBotChips4.Enabled = false;
            this.tbBotChips4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips4.Location = new Point(963, 81);
            this.tbBotChips4.Multiline = true;
            this.tbBotChips4.Name = "tbBotChips4";
            this.tbBotChips4.Size = new Size(125, 20);
            this.tbBotChips4.TabIndex = 10;
            this.tbBotChips4.Text = "Chips : 0";
            // 
            // tbBotChips3
            // 
            this.tbBotChips3.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.tbBotChips3.Enabled = false;
            this.tbBotChips3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips3.Location = new Point(771, 81);
            this.tbBotChips3.Multiline = true;
            this.tbBotChips3.Name = "tbBotChips3";
            this.tbBotChips3.Size = new Size(125, 20);
            this.tbBotChips3.TabIndex = 11;
            this.tbBotChips3.Text = "Chips : 0";
            // 
            // tbBotChips2
            // 
            this.tbBotChips2.Enabled = false;
            this.tbBotChips2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips2.Location = new Point(276, 81);
            this.tbBotChips2.Multiline = true;
            this.tbBotChips2.Name = "tbBotChips2";
            this.tbBotChips2.Size = new Size(125, 20);
            this.tbBotChips2.TabIndex = 12;
            this.tbBotChips2.Text = "Chips : 0";
            // 
            // tbBotChips1
            // 
            this.tbBotChips1.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.tbBotChips1.Enabled = false;
            this.tbBotChips1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbBotChips1.Location = new Point(214, 553);
            this.tbBotChips1.Multiline = true;
            this.tbBotChips1.Name = "tbBotChips1";
            this.tbBotChips1.Size = new Size(125, 20);
            this.tbBotChips1.TabIndex = 13;
            this.tbBotChips1.Text = "Chips : 0";
            // 
            // tbPot
            // 
            this.tbPot.Anchor = AnchorStyles.None;
            this.tbPot.Enabled = false;
            this.tbPot.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.tbPot.Location = new Point(606, 212);
            this.tbPot.Name = "tbPot";
            this.tbPot.Size = new Size(125, 23);
            this.tbPot.TabIndex = 14;
            this.tbPot.Text = "0";
            // 
            // bBB
            // 
            this.bBB.Location = new Point(12, 254);
            this.bBB.Name = "bBB";
            this.bBB.Size = new Size(75, 23);
            this.bBB.TabIndex = 16;
            this.bBB.Text = "Big Blind";
            this.bBB.UseVisualStyleBackColor = true;
            this.bBB.Visible = false;
            this.bBB.Click += new EventHandler(this.bBB_Click);
            // 
            // tbSB
            // 
            this.tbSB.Location = new Point(12, 228);
            this.tbSB.Name = "tbSB";
            this.tbSB.Size = new Size(75, 20);
            this.tbSB.TabIndex = 17;
            this.tbSB.Text = "250";
            this.tbSB.Visible = false;
            // 
            // bSB
            // 
            this.bSB.Location = new Point(12, 199);
            this.bSB.Name = "bSB";
            this.bSB.Size = new Size(75, 23);
            this.bSB.TabIndex = 18;
            this.bSB.Text = "Small Blind";
            this.bSB.UseVisualStyleBackColor = true;
            this.bSB.Visible = false;
            this.bSB.Click += new EventHandler(this.bSB_Click);
            // 
            // tbBB
            // 
            this.tbBB.Location = new Point(12, 283);
            this.tbBB.Name = "tbBB";
            this.tbBB.Size = new Size(75, 20);
            this.tbBB.TabIndex = 19;
            this.tbBB.Text = "500";
            this.tbBB.Visible = false;
            // 
            // b5Status
            // 
            this.b5Status.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.b5Status.Location = new Point(998, 573);
            this.b5Status.Name = "b5Status";
            this.b5Status.Size = new Size(125, 30);
            this.b5Status.TabIndex = 26;
            // 
            // b4Status
            // 
            this.b4Status.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.b4Status.Location = new Point(963, 107);
            this.b4Status.Name = "b4Status";
            this.b4Status.Size = new Size(125, 30);
            this.b4Status.TabIndex = 27;
            // 
            // b3Status
            // 
            this.b3Status.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.b3Status.Location = new Point(771, 107);
            this.b3Status.Name = "b3Status";
            this.b3Status.Size = new Size(125, 30);
            this.b3Status.TabIndex = 28;
            // 
            // b1Status
            // 
            this.b1Status.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            this.b1Status.Location = new Point(214, 576);
            this.b1Status.Name = "b1Status";
            this.b1Status.Size = new Size(125, 30);
            this.b1Status.TabIndex = 29;
            // 
            // pStatus
            // 
            this.pStatus.Anchor = AnchorStyles.Bottom;
            this.pStatus.Location = new Point(755, 573);
            this.pStatus.Name = "pStatus";
            this.pStatus.Size = new Size(125, 30);
            this.pStatus.TabIndex = 30;
            // 
            // b2Status
            // 
            this.b2Status.Location = new Point(276, 107);
            this.b2Status.Name = "b2Status";
            this.b2Status.Size = new Size(125, 30);
            this.b2Status.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = AnchorStyles.None;
            this.label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new Point(654, 188);
            this.label1.Name = "label1";
            this.label1.Size = new Size(31, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pot";
            // 
            // tbRaise
            // 
            this.tbRaise.Anchor = AnchorStyles.Bottom;
            this.tbRaise.Location = new Point(980, 676);
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new Size(108, 20);
            this.tbRaise.TabIndex = 0;
            // 
            // pChipsTop
            // 
            this.pChipsTop.Dock = DockStyle.Bottom;
            this.pChipsTop.Enabled = false;
            this.pChipsTop.Location = new Point(0, 716);
            this.pChipsTop.Name = "pChipsTop";
            this.pChipsTop.Size = new Size(1350, 13);
            this.pChipsTop.TabIndex = 33;
            this.pChipsTop.Text = "label2";
            this.pChipsTop.Visible = false;
            // 
            // listStatistics
            // 
            this.listStatistics.Location = new Point(1095, 626);
            this.listStatistics.Name = "listStatistics";
            this.listStatistics.Size = new Size(243, 97);
            this.listStatistics.TabIndex = 34;
            this.listStatistics.UseCompatibleStateImageBehavior = false;
            this.listStatistics.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1350, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.settingsHelpToolStripMenuItem,
            this.editBlindsToolStripMenuItem,
            this.ProfileToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // settingsHelpToolStripMenuItem
            // 
            this.settingsHelpToolStripMenuItem.Name = "settingsHelpToolStripMenuItem";
            this.settingsHelpToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.S)));
            this.settingsHelpToolStripMenuItem.Size = new Size(186, 22);
            this.settingsHelpToolStripMenuItem.Text = "Settings/Help";
            this.settingsHelpToolStripMenuItem.Click += new EventHandler(this.settingsHelpToolStripMenuItem_Click);
            // 
            // editBlindsToolStripMenuItem
            // 
            this.editBlindsToolStripMenuItem.Name = "editBlindsToolStripMenuItem";
            this.editBlindsToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.B)));
            this.editBlindsToolStripMenuItem.Size = new Size(186, 22);
            this.editBlindsToolStripMenuItem.Text = "Edit Blinds";
            this.editBlindsToolStripMenuItem.Click += new EventHandler(this.editBlindsToolStripMenuItem_Click);
            // 
            // ProfileToolStripMenuItem
            // 
            this.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            this.ProfileToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.P)));
            this.ProfileToolStripMenuItem.Size = new Size(186, 22);
            this.ProfileToolStripMenuItem.Text = "Profile";
            this.ProfileToolStripMenuItem.Click += new EventHandler(this.ProfileToolStripMenuItem_Click);
            // 
            // playerName
            // 
            this.playerName.BackColor = SystemColors.ActiveCaptionText;
            this.playerName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.playerName.ForeColor = SystemColors.ControlLightLight;
            this.playerName.Location = new Point(1155, 229);
            this.playerName.Name = "playerName";
            this.playerName.Size = new Size(100, 20);
            this.playerName.TabIndex = 36;
            this.playerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bot1Name
            // 
            this.bot1Name.BackColor = SystemColors.ActiveCaptionText;
            this.bot1Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.bot1Name.ForeColor = SystemColors.ControlLightLight;
            this.bot1Name.Location = new Point(1155, 261);
            this.bot1Name.Name = "bot1Name";
            this.bot1Name.Size = new Size(100, 20);
            this.bot1Name.TabIndex = 37;
            this.bot1Name.TextAlign = ContentAlignment.MiddleCenter;
            this.bot1Name.Visible = false;
            // 
            // bot2Name
            // 
            this.bot2Name.BackColor = SystemColors.ActiveCaptionText;
            this.bot2Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.bot2Name.ForeColor = SystemColors.ControlLightLight;
            this.bot2Name.Location = new Point(1155, 298);
            this.bot2Name.Name = "bot2Name";
            this.bot2Name.Size = new Size(100, 20);
            this.bot2Name.TabIndex = 38;
            this.bot2Name.TextAlign = ContentAlignment.MiddleCenter;
            this.bot2Name.Visible = false;
            // 
            // bot3Name
            // 
            this.bot3Name.BackColor = SystemColors.ActiveCaptionText;
            this.bot3Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.bot3Name.ForeColor = SystemColors.ControlLightLight;
            this.bot3Name.Location = new Point(1155, 330);
            this.bot3Name.Name = "bot3Name";
            this.bot3Name.Size = new Size(100, 20);
            this.bot3Name.TabIndex = 39;
            this.bot3Name.TextAlign = ContentAlignment.MiddleCenter;
            this.bot3Name.Visible = false;
            // 
            // bot4Name
            // 
            this.bot4Name.BackColor = SystemColors.ActiveCaptionText;
            this.bot4Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.bot4Name.ForeColor = SystemColors.ControlLightLight;
            this.bot4Name.Location = new Point(1155, 360);
            this.bot4Name.Name = "bot4Name";
            this.bot4Name.Size = new Size(100, 20);
            this.bot4Name.TabIndex = 40;
            this.bot4Name.TextAlign = ContentAlignment.MiddleCenter;
            this.bot4Name.Visible = false;
            // 
            // bot5Name
            // 
            this.bot5Name.BackColor = SystemColors.ActiveCaptionText;
            this.bot5Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.bot5Name.ForeColor = SystemColors.ControlLightLight;
            this.bot5Name.Location = new Point(1155, 391);
            this.bot5Name.Name = "bot5Name";
            this.bot5Name.Size = new Size(100, 20);
            this.bot5Name.TabIndex = 41;
            this.bot5Name.TextAlign = ContentAlignment.MiddleCenter;
            this.bot5Name.Visible = false;
            // 
            // MainPoker
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Resources.poker_table___Copy;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new Size(1350, 729);
            this.Controls.Add(this.bot5Name);
            this.Controls.Add(this.bot4Name);
            this.Controls.Add(this.bot3Name);
            this.Controls.Add(this.bot2Name);
            this.Controls.Add(this.bot1Name);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.listStatistics);
            this.Controls.Add(this.pChipsTop);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b2Status);
            this.Controls.Add(this.pStatus);
            this.Controls.Add(this.b1Status);
            this.Controls.Add(this.b3Status);
            this.Controls.Add(this.b4Status);
            this.Controls.Add(this.b5Status);
            this.Controls.Add(this.tbBB);
            this.Controls.Add(this.bSB);
            this.Controls.Add(this.tbSB);
            this.Controls.Add(this.bBB);
            this.Controls.Add(this.tbPot);
            this.Controls.Add(this.tbBotChips1);
            this.Controls.Add(this.tbBotChips2);
            this.Controls.Add(this.tbBotChips3);
            this.Controls.Add(this.tbBotChips4);
            this.Controls.Add(this.tbBotChips5);
            this.Controls.Add(this.tbAdd);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbChips);
            this.Controls.Add(this.pbTimer);
            this.Controls.Add(this.bRaise);
            this.Controls.Add(this.bCall);
            this.Controls.Add(this.bCheck);
            this.Controls.Add(this.bFold);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainPoker";
            this.Text = "GLS Texas Poker";
            this.Load += new EventHandler(this.MainPoker_Load);
            this.Resize += new EventHandler(this.Form_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bFold;
        private Button bCheck;
        private Button bRaise;
        private ProgressBar pbTimer;
        private Button bAdd;
        private TextBox tbAdd;
        private TextBox tbBotChips5;
        private TextBox tbBotChips4;
        private TextBox tbBotChips3;
        private TextBox tbBotChips2;
        private TextBox tbBotChips1;
        private Button bBB;
        private TextBox tbSB;
        private Button bSB;
        private TextBox tbBB;
        private Label b5Status;
        private Label b4Status;
        private Label b3Status;
        private Label b1Status;
        private Label pStatus;
        private Label b2Status;
        private Label label1;
        private TextBox tbRaise;
        private Label pChipsTop;
        public Button bCall;
        public ListView listStatistics;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem settingsHelpToolStripMenuItem;
        private ToolStripMenuItem editBlindsToolStripMenuItem;
        public TextBox tbChips;
        public TextBox tbPot;
        private ToolStripMenuItem ProfileToolStripMenuItem;
        private Label playerName;
        private Label bot1Name;
        private Label bot2Name;
        private Label bot3Name;
        private Label bot4Name;
        private Label bot5Name;
    }
}

