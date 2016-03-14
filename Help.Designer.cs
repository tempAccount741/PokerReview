using System.ComponentModel;
using System.Windows.Forms;

namespace Poker
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.lbLeftLine = new System.Windows.Forms.Label();
            this.lbTopLine = new System.Windows.Forms.Label();
            this.bHow = new System.Windows.Forms.Button();
            this.bHotkeys = new System.Windows.Forms.Button();
            this.bCombinations = new System.Windows.Forms.Button();
            this.bAbout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pCombinations = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pHot = new System.Windows.Forms.Panel();
            this.bReset = new System.Windows.Forms.Button();
            this.bApply = new System.Windows.Forms.Button();
            this.HotFold = new System.Windows.Forms.TextBox();
            this.HotCheck = new System.Windows.Forms.TextBox();
            this.HotCall = new System.Windows.Forms.TextBox();
            this.HotRaise = new System.Windows.Forms.TextBox();
            this.LRaise = new System.Windows.Forms.Label();
            this.LCall = new System.Windows.Forms.Label();
            this.LCheck = new System.Windows.Forms.Label();
            this.Lintro = new System.Windows.Forms.Label();
            this.LFold = new System.Windows.Forms.Label();
            this.bSettings = new System.Windows.Forms.Button();
            this.pSettings = new System.Windows.Forms.Panel();
            this.CardBacks = new System.Windows.Forms.Button();
            this.CardPacks = new System.Windows.Forms.Button();
            this.bPrevious = new System.Windows.Forms.Button();
            this.bNext = new System.Windows.Forms.Button();
            this.bPickCard = new System.Windows.Forms.Button();
            this.pickCards = new System.Windows.Forms.PictureBox();
            this.pThink = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tbThink = new System.Windows.Forms.TextBox();
            this.bThinkTime = new System.Windows.Forms.Button();
            this.cbSkipThinkTime = new System.Windows.Forms.CheckBox();
            this.cbThinkTime = new System.Windows.Forms.CheckBox();
            this.bClearStatistics = new System.Windows.Forms.Button();
            this.cbStatistics = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pAchievementsCards = new System.Windows.Forms.FlowLayoutPanel();
            this.bAchivements = new System.Windows.Forms.Button();
            this.tbH1 = new System.Windows.Forms.TextBox();
            this.pCombinations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.pHot.SuspendLayout();
            this.pSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickCards)).BeginInit();
            this.pThink.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLeftLine
            // 
            this.lbLeftLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLeftLine.Location = new System.Drawing.Point(170, 10);
            this.lbLeftLine.Name = "lbLeftLine";
            this.lbLeftLine.Size = new System.Drawing.Size(2, 320);
            this.lbLeftLine.TabIndex = 0;
            // 
            // lbTopLine
            // 
            this.lbTopLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTopLine.Location = new System.Drawing.Point(180, 40);
            this.lbTopLine.Name = "lbTopLine";
            this.lbTopLine.Size = new System.Drawing.Size(385, 2);
            this.lbTopLine.TabIndex = 1;
            // 
            // bHow
            // 
            this.bHow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bHow.Location = new System.Drawing.Point(12, 48);
            this.bHow.Name = "bHow";
            this.bHow.Size = new System.Drawing.Size(152, 33);
            this.bHow.TabIndex = 2;
            this.bHow.Text = "How to play";
            this.bHow.UseVisualStyleBackColor = true;
            this.bHow.Click += new System.EventHandler(this.bHow_Click);
            // 
            // bHotkeys
            // 
            this.bHotkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bHotkeys.Location = new System.Drawing.Point(12, 147);
            this.bHotkeys.Name = "bHotkeys";
            this.bHotkeys.Size = new System.Drawing.Size(152, 33);
            this.bHotkeys.TabIndex = 3;
            this.bHotkeys.Text = "Hotkeys";
            this.bHotkeys.UseVisualStyleBackColor = true;
            this.bHotkeys.Click += new System.EventHandler(this.bHotkeys_Click);
            // 
            // bCombinations
            // 
            this.bCombinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCombinations.Location = new System.Drawing.Point(12, 96);
            this.bCombinations.Name = "bCombinations";
            this.bCombinations.Size = new System.Drawing.Size(152, 33);
            this.bCombinations.TabIndex = 4;
            this.bCombinations.Text = "Poker Hands";
            this.bCombinations.UseVisualStyleBackColor = true;
            this.bCombinations.Click += new System.EventHandler(this.bCombinations_Click);
            // 
            // bAbout
            // 
            this.bAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAbout.Location = new System.Drawing.Point(12, 287);
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(152, 33);
            this.bAbout.TabIndex = 5;
            this.bAbout.Text = "About";
            this.bAbout.UseVisualStyleBackColor = true;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Poker Texas Hold\'em Helper";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pCombinations
            // 
            this.pCombinations.AutoScroll = true;
            this.pCombinations.Controls.Add(this.textBox1);
            this.pCombinations.Controls.Add(this.pictureBox1);
            this.pCombinations.Controls.Add(this.textBox2);
            this.pCombinations.Controls.Add(this.pictureBox2);
            this.pCombinations.Controls.Add(this.textBox3);
            this.pCombinations.Controls.Add(this.pictureBox3);
            this.pCombinations.Controls.Add(this.textBox4);
            this.pCombinations.Controls.Add(this.pictureBox4);
            this.pCombinations.Controls.Add(this.textBox5);
            this.pCombinations.Controls.Add(this.pictureBox5);
            this.pCombinations.Controls.Add(this.textBox6);
            this.pCombinations.Controls.Add(this.pictureBox6);
            this.pCombinations.Controls.Add(this.textBox7);
            this.pCombinations.Controls.Add(this.pictureBox7);
            this.pCombinations.Controls.Add(this.textBox8);
            this.pCombinations.Controls.Add(this.pictureBox8);
            this.pCombinations.Controls.Add(this.textBox9);
            this.pCombinations.Controls.Add(this.pictureBox9);
            this.pCombinations.Location = new System.Drawing.Point(803, 9);
            this.pCombinations.Name = "pCombinations";
            this.pCombinations.Size = new System.Drawing.Size(385, 275);
            this.pCombinations.TabIndex = 12;
            this.pCombinations.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(165, 103);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Royal Flush : The most famous poker hand.This is unbeatable hand.It consist\'s Ace" +
    ", King , Queen, Jack and a 10 all from one painting.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(174, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(3, 112);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(165, 103);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Straight Flush : Five consecutive in case 2 players have this hand the highest st" +
    "raight flush wins";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(174, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(3, 221);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(165, 103);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Four of a Kind : Four cards of the same kind. In case 2 players have this hand th" +
    "e higher Four of a Kind wins";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(174, 221);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(163, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(3, 330);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(165, 103);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "Full House : Three of the same kind and a pair.In case 2 players have this hand t" +
    "he one with higher three of the same kind wins";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(174, 330);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(163, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(3, 439);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(165, 103);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "Flush : Five non-consecutive card from the same painting.In case 2 players have t" +
    "his hand the one with the highest card of the painting wins";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(174, 439);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(163, 103);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(3, 548);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(165, 103);
            this.textBox6.TabIndex = 11;
            this.textBox6.Text = "Straight : Five consecutive cards from a different painting .In case 2 players ha" +
    "ve this hand the one with the highest card wins";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(174, 548);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(163, 103);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(3, 657);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(165, 103);
            this.textBox7.TabIndex = 13;
            this.textBox7.Text = resources.GetString("textBox7.Text");
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(174, 657);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(163, 103);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 14;
            this.pictureBox7.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox8.Location = new System.Drawing.Point(3, 766);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(165, 103);
            this.textBox8.TabIndex = 15;
            this.textBox8.Text = "Two Pair : Two different Pairs and 1 additonal called kicker.In case 2 players ha" +
    "ve exactly the same Pairs the one with the higher kicker wins.";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(174, 766);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(163, 103);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox9.Location = new System.Drawing.Point(3, 875);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(165, 103);
            this.textBox9.TabIndex = 17;
            this.textBox9.Text = "Pair : Two of the same kind cards.In case 2 players have the same Pair the one wi" +
    "th the highest out of his rest 3 cards wins";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(174, 875);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(163, 103);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox9.TabIndex = 18;
            this.pictureBox9.TabStop = false;
            // 
            // pHot
            // 
            this.pHot.Controls.Add(this.bReset);
            this.pHot.Controls.Add(this.bApply);
            this.pHot.Controls.Add(this.HotFold);
            this.pHot.Controls.Add(this.HotCheck);
            this.pHot.Controls.Add(this.HotCall);
            this.pHot.Controls.Add(this.HotRaise);
            this.pHot.Controls.Add(this.LRaise);
            this.pHot.Controls.Add(this.LCall);
            this.pHot.Controls.Add(this.LCheck);
            this.pHot.Controls.Add(this.Lintro);
            this.pHot.Controls.Add(this.LFold);
            this.pHot.Location = new System.Drawing.Point(43, 400);
            this.pHot.Name = "pHot";
            this.pHot.Size = new System.Drawing.Size(385, 275);
            this.pHot.TabIndex = 13;
            this.pHot.Visible = false;
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bReset.Location = new System.Drawing.Point(99, 229);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 13;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bApply
            // 
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bApply.Location = new System.Drawing.Point(18, 229);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(75, 23);
            this.bApply.TabIndex = 12;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // HotFold
            // 
            this.HotFold.Location = new System.Drawing.Point(61, 69);
            this.HotFold.Name = "HotFold";
            this.HotFold.Size = new System.Drawing.Size(100, 20);
            this.HotFold.TabIndex = 11;
            // 
            // HotCheck
            // 
            this.HotCheck.Location = new System.Drawing.Point(61, 99);
            this.HotCheck.Name = "HotCheck";
            this.HotCheck.Size = new System.Drawing.Size(100, 20);
            this.HotCheck.TabIndex = 10;
            // 
            // HotCall
            // 
            this.HotCall.Location = new System.Drawing.Point(61, 132);
            this.HotCall.Name = "HotCall";
            this.HotCall.Size = new System.Drawing.Size(100, 20);
            this.HotCall.TabIndex = 9;
            // 
            // HotRaise
            // 
            this.HotRaise.Location = new System.Drawing.Point(61, 167);
            this.HotRaise.Name = "HotRaise";
            this.HotRaise.Size = new System.Drawing.Size(100, 20);
            this.HotRaise.TabIndex = 8;
            // 
            // LRaise
            // 
            this.LRaise.AutoSize = true;
            this.LRaise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LRaise.Location = new System.Drawing.Point(15, 167);
            this.LRaise.Name = "LRaise";
            this.LRaise.Size = new System.Drawing.Size(39, 15);
            this.LRaise.TabIndex = 7;
            this.LRaise.Text = "Raise";
            // 
            // LCall
            // 
            this.LCall.AutoSize = true;
            this.LCall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LCall.Location = new System.Drawing.Point(15, 133);
            this.LCall.Name = "LCall";
            this.LCall.Size = new System.Drawing.Size(28, 15);
            this.LCall.TabIndex = 6;
            this.LCall.Text = "Call";
            // 
            // LCheck
            // 
            this.LCheck.AutoSize = true;
            this.LCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LCheck.Location = new System.Drawing.Point(15, 100);
            this.LCheck.Name = "LCheck";
            this.LCheck.Size = new System.Drawing.Size(41, 15);
            this.LCheck.TabIndex = 5;
            this.LCheck.Text = "Check";
            // 
            // Lintro
            // 
            this.Lintro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lintro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lintro.Location = new System.Drawing.Point(18, 11);
            this.Lintro.Name = "Lintro";
            this.Lintro.Size = new System.Drawing.Size(319, 23);
            this.Lintro.TabIndex = 1;
            this.Lintro.Text = "Here, You can assign the hotkeys to any button You like.";
            // 
            // LFold
            // 
            this.LFold.AutoSize = true;
            this.LFold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LFold.Location = new System.Drawing.Point(15, 70);
            this.LFold.Name = "LFold";
            this.LFold.Size = new System.Drawing.Size(31, 15);
            this.LFold.TabIndex = 0;
            this.LFold.Text = "Fold";
            // 
            // bSettings
            // 
            this.bSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSettings.Location = new System.Drawing.Point(12, 195);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(152, 33);
            this.bSettings.TabIndex = 14;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // pSettings
            // 
            this.pSettings.Controls.Add(this.CardBacks);
            this.pSettings.Controls.Add(this.CardPacks);
            this.pSettings.Controls.Add(this.bPrevious);
            this.pSettings.Controls.Add(this.bNext);
            this.pSettings.Controls.Add(this.bPickCard);
            this.pSettings.Controls.Add(this.pickCards);
            this.pSettings.Controls.Add(this.pThink);
            this.pSettings.Controls.Add(this.cbSkipThinkTime);
            this.pSettings.Controls.Add(this.cbThinkTime);
            this.pSettings.Controls.Add(this.bClearStatistics);
            this.pSettings.Controls.Add(this.cbStatistics);
            this.pSettings.Controls.Add(this.label5);
            this.pSettings.Location = new System.Drawing.Point(617, 352);
            this.pSettings.Name = "pSettings";
            this.pSettings.Size = new System.Drawing.Size(385, 275);
            this.pSettings.TabIndex = 14;
            this.pSettings.Visible = false;
            // 
            // CardBacks
            // 
            this.CardBacks.Location = new System.Drawing.Point(150, 122);
            this.CardBacks.Name = "CardBacks";
            this.CardBacks.Size = new System.Drawing.Size(90, 20);
            this.CardBacks.TabIndex = 27;
            this.CardBacks.Text = "Card Backs";
            this.CardBacks.UseVisualStyleBackColor = true;
            this.CardBacks.Click += new System.EventHandler(this.CardBacks_Click);
            // 
            // CardPacks
            // 
            this.CardPacks.Location = new System.Drawing.Point(261, 122);
            this.CardPacks.Name = "CardPacks";
            this.CardPacks.Size = new System.Drawing.Size(90, 20);
            this.CardPacks.TabIndex = 26;
            this.CardPacks.Text = "Card Packs";
            this.CardPacks.UseVisualStyleBackColor = true;
            this.CardPacks.Click += new System.EventHandler(this.CardPacks_Click);
            // 
            // bPrevious
            // 
            this.bPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPrevious.Location = new System.Drawing.Point(127, 148);
            this.bPrevious.Name = "bPrevious";
            this.bPrevious.Size = new System.Drawing.Size(17, 100);
            this.bPrevious.TabIndex = 23;
            this.bPrevious.UseVisualStyleBackColor = true;
            this.bPrevious.Click += new System.EventHandler(this.bPrevious_Click);
            // 
            // bNext
            // 
            this.bNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bNext.Location = new System.Drawing.Point(355, 148);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(17, 100);
            this.bNext.TabIndex = 22;
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bPickCard
            // 
            this.bPickCard.Location = new System.Drawing.Point(140, 254);
            this.bPickCard.Name = "bPickCard";
            this.bPickCard.Size = new System.Drawing.Size(220, 23);
            this.bPickCard.TabIndex = 18;
            this.bPickCard.Text = "Pick card pack";
            this.bPickCard.UseVisualStyleBackColor = true;
            this.bPickCard.Click += new System.EventHandler(this.bPickCard_Click);
            // 
            // pickCards
            // 
            this.pickCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pickCards.Location = new System.Drawing.Point(150, 148);
            this.pickCards.Name = "pickCards";
            this.pickCards.Size = new System.Drawing.Size(200, 103);
            this.pickCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pickCards.TabIndex = 21;
            this.pickCards.TabStop = false;
            // 
            // pThink
            // 
            this.pThink.Controls.Add(this.label4);
            this.pThink.Controls.Add(this.tbThink);
            this.pThink.Controls.Add(this.bThinkTime);
            this.pThink.Location = new System.Drawing.Point(129, 55);
            this.pThink.Name = "pThink";
            this.pThink.Size = new System.Drawing.Size(216, 38);
            this.pThink.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Bot Think Time";
            // 
            // tbThink
            // 
            this.tbThink.Location = new System.Drawing.Point(96, 13);
            this.tbThink.Name = "tbThink";
            this.tbThink.Size = new System.Drawing.Size(30, 20);
            this.tbThink.TabIndex = 14;
            this.tbThink.Text = "3";
            // 
            // bThinkTime
            // 
            this.bThinkTime.Location = new System.Drawing.Point(132, 12);
            this.bThinkTime.Name = "bThinkTime";
            this.bThinkTime.Size = new System.Drawing.Size(75, 23);
            this.bThinkTime.TabIndex = 17;
            this.bThinkTime.Text = "Apply";
            this.bThinkTime.UseVisualStyleBackColor = true;
            this.bThinkTime.Click += new System.EventHandler(this.bThinkTime_Click);
            // 
            // cbSkipThinkTime
            // 
            this.cbSkipThinkTime.AutoSize = true;
            this.cbSkipThinkTime.Location = new System.Drawing.Point(15, 50);
            this.cbSkipThinkTime.Name = "cbSkipThinkTime";
            this.cbSkipThinkTime.Size = new System.Drawing.Size(96, 17);
            this.cbSkipThinkTime.TabIndex = 19;
            this.cbSkipThinkTime.Text = "Skip Bot Turns";
            this.cbSkipThinkTime.UseVisualStyleBackColor = true;
            this.cbSkipThinkTime.CheckedChanged += new System.EventHandler(this.cbSkipThinkTime_CheckedChanged);
            // 
            // cbThinkTime
            // 
            this.cbThinkTime.AutoSize = true;
            this.cbThinkTime.Location = new System.Drawing.Point(15, 71);
            this.cbThinkTime.Name = "cbThinkTime";
            this.cbThinkTime.Size = new System.Drawing.Size(108, 17);
            this.cbThinkTime.TabIndex = 18;
            this.cbThinkTime.Text = "Enable Bot Turns";
            this.cbThinkTime.UseVisualStyleBackColor = true;
            this.cbThinkTime.CheckedChanged += new System.EventHandler(this.cbThinkTime_CheckedChanged);
            // 
            // bClearStatistics
            // 
            this.bClearStatistics.Location = new System.Drawing.Point(15, 256);
            this.bClearStatistics.Name = "bClearStatistics";
            this.bClearStatistics.Size = new System.Drawing.Size(104, 21);
            this.bClearStatistics.TabIndex = 16;
            this.bClearStatistics.Text = "Clear Statistics";
            this.bClearStatistics.UseVisualStyleBackColor = true;
            this.bClearStatistics.Click += new System.EventHandler(this.bClearStatistics_Click);
            // 
            // cbStatistics
            // 
            this.cbStatistics.AutoSize = true;
            this.cbStatistics.Location = new System.Drawing.Point(15, 229);
            this.cbStatistics.Name = "cbStatistics";
            this.cbStatistics.Size = new System.Drawing.Size(104, 17);
            this.cbStatistics.TabIndex = 15;
            this.cbStatistics.Text = "Enable Statistics";
            this.cbStatistics.UseVisualStyleBackColor = true;
            this.cbStatistics.CheckedChanged += new System.EventHandler(this.cbStatistics_CheckedChanged);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(319, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Here, You can adjust most parts of the UI as you like";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pAchievementsCards
            // 
            this.pAchievementsCards.AutoScroll = true;
            this.pAchievementsCards.Location = new System.Drawing.Point(1085, 324);
            this.pAchievementsCards.Name = "pAchievementsCards";
            this.pAchievementsCards.Size = new System.Drawing.Size(383, 276);
            this.pAchievementsCards.TabIndex = 24;
            // 
            // bAchivements
            // 
            this.bAchivements.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAchivements.Location = new System.Drawing.Point(12, 242);
            this.bAchivements.Name = "bAchivements";
            this.bAchivements.Size = new System.Drawing.Size(152, 33);
            this.bAchivements.TabIndex = 15;
            this.bAchivements.Text = "Achievements";
            this.bAchivements.UseVisualStyleBackColor = true;
            this.bAchivements.Click += new System.EventHandler(this.bAchivements_Click);
            // 
            // tbH1
            // 
            this.tbH1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbH1.Location = new System.Drawing.Point(180, 45);
            this.tbH1.Multiline = true;
            this.tbH1.Name = "tbH1";
            this.tbH1.ReadOnly = true;
            this.tbH1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbH1.Size = new System.Drawing.Size(385, 275);
            this.tbH1.TabIndex = 0;
            this.tbH1.Visible = false;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 341);
            this.Controls.Add(this.pCombinations);
            this.Controls.Add(this.bAchivements);
            this.Controls.Add(this.pSettings);
            this.Controls.Add(this.pAchievementsCards);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.pHot);
            this.Controls.Add(this.tbH1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bAbout);
            this.Controls.Add(this.bCombinations);
            this.Controls.Add(this.bHotkeys);
            this.Controls.Add(this.bHow);
            this.Controls.Add(this.lbTopLine);
            this.Controls.Add(this.lbLeftLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Help";
            this.Text = "Help";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Help_Load);
            this.pCombinations.ResumeLayout(false);
            this.pCombinations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.pHot.ResumeLayout(false);
            this.pHot.PerformLayout();
            this.pSettings.ResumeLayout(false);
            this.pSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pickCards)).EndInit();
            this.pThink.ResumeLayout(false);
            this.pThink.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbLeftLine;
        private Label lbTopLine;
        private Button bHow;
        private Button bHotkeys;
        private Button bCombinations;
        private Button bAbout;
        private Label label3;
        private FlowLayoutPanel pCombinations;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private TextBox textBox2;
        private PictureBox pictureBox2;
        private TextBox textBox3;
        private PictureBox pictureBox3;
        private TextBox textBox4;
        private PictureBox pictureBox4;
        private TextBox textBox5;
        private PictureBox pictureBox5;
        private TextBox textBox6;
        private PictureBox pictureBox6;
        private TextBox textBox7;
        private PictureBox pictureBox7;
        private TextBox textBox8;
        private PictureBox pictureBox8;
        private TextBox textBox9;
        private PictureBox pictureBox9;
        private Panel pHot;
        private TextBox HotFold;
        private TextBox HotCheck;
        private TextBox HotCall;
        private TextBox HotRaise;
        private Label LRaise;
        private Label LCall;
        private Label LCheck;
        private Label Lintro;
        private Label LFold;
        private Button bReset;
        private Button bApply;
        private Button bSettings;
        private Panel pSettings;
        private Label label4;
        private Label label5;
        private TextBox tbThink;
        private CheckBox cbStatistics;
        private Button bClearStatistics;
        private Button bThinkTime;
        private Panel pThink;
        private CheckBox cbSkipThinkTime;
        private CheckBox cbThinkTime;
        private Button bPickCard;
        private PictureBox pickCards;
        private Button bAchivements;
        private Button bPrevious;
        private Button bNext;
        private Button CardBacks;
        private Button CardPacks;
        private TextBox tbH1;
        private FlowLayoutPanel pAchievementsCards;
    }
}