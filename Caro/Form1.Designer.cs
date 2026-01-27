namespace Caro
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_chessBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLAN = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.img_Player = new System.Windows.Forms.PictureBox();
            this.prcb_CoolDown = new System.Windows.Forms.ProgressBar();
            this.txt_PlayerName = new System.Windows.Forms.TextBox();
            this.tm_CountDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Player)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_chessBoard
            // 
            this.pnl_chessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_chessBoard.Location = new System.Drawing.Point(12, 43);
            this.pnl_chessBoard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_chessBoard.Name = "pnl_chessBoard";
            this.pnl_chessBoard.Size = new System.Drawing.Size(712, 742);
            this.pnl_chessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(731, 43);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 270);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = global::Caro.Properties.Resources.back_caro;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnLAN);
            this.panel3.Controls.Add(this.txtIP);
            this.panel3.Controls.Add(this.img_Player);
            this.panel3.Controls.Add(this.prcb_CoolDown);
            this.panel3.Controls.Add(this.txt_PlayerName);
            this.panel3.Location = new System.Drawing.Point(731, 318);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 244);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(185, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kí hiệu ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lượt đang đánh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 in line to win";
            // 
            // btnLAN
            // 
            this.btnLAN.Location = new System.Drawing.Point(4, 169);
            this.btnLAN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(140, 23);
            this.btnLAN.TabIndex = 4;
            this.btnLAN.Text = "Ket noi";
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(4, 143);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(140, 22);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "127.0.0.1";
            // 
            // img_Player
            // 
            this.img_Player.BackColor = System.Drawing.SystemColors.Control;
            this.img_Player.Location = new System.Drawing.Point(150, 48);
            this.img_Player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.img_Player.Name = "img_Player";
            this.img_Player.Size = new System.Drawing.Size(116, 144);
            this.img_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Player.TabIndex = 2;
            this.img_Player.TabStop = false;
            // 
            // prcb_CoolDown
            // 
            this.prcb_CoolDown.Location = new System.Drawing.Point(3, 83);
            this.prcb_CoolDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prcb_CoolDown.Name = "prcb_CoolDown";
            this.prcb_CoolDown.Size = new System.Drawing.Size(140, 44);
            this.prcb_CoolDown.TabIndex = 1;
            // 
            // txt_PlayerName
            // 
            this.txt_PlayerName.Location = new System.Drawing.Point(4, 48);
            this.txt_PlayerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_PlayerName.Name = "txt_PlayerName";
            this.txt_PlayerName.ReadOnly = true;
            this.txt_PlayerName.Size = new System.Drawing.Size(140, 22);
            this.txt_PlayerName.TabIndex = 0;
            this.txt_PlayerName.Text = "Player";
            // 
            // tm_CountDown
            // 
            this.tm_CountDown.Tick += new System.EventHandler(this.tm_CountDown_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1005, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnMenu
            // 
            this.mnMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNewGame,
            this.mnQuit});
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Size = new System.Drawing.Size(60, 24);
            this.mnMenu.Text = "Menu";
            // 
            // mnNewGame
            // 
            this.mnNewGame.Name = "mnNewGame";
            this.mnNewGame.Size = new System.Drawing.Size(224, 26);
            this.mnNewGame.Text = "New Game";
            this.mnNewGame.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // mnQuit
            // 
            this.mnQuit.Name = "mnQuit";
            this.mnQuit.Size = new System.Drawing.Size(224, 26);
            this.mnQuit.Text = "Quit";
            this.mnQuit.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(748, 609);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(239, 162);
            this.txtStatus.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(825, 587);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Trạng thái ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 796);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_chessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Caro_game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Player)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_chessBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.PictureBox img_Player;
        private System.Windows.Forms.ProgressBar prcb_CoolDown;
        private System.Windows.Forms.TextBox txt_PlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tm_CountDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnMenu;
        private System.Windows.Forms.ToolStripMenuItem mnNewGame;
        private System.Windows.Forms.ToolStripMenuItem mnQuit;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

