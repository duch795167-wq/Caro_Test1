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
            this.img_Player = new System.Windows.Forms.PictureBox();
            this.prcb_CoolDown = new System.Windows.Forms.ProgressBar();
            this.txt_PlayerName = new System.Windows.Forms.TextBox();
            this.tm_CountDown = new System.Windows.Forms.Timer(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.btnLAN = new Guna.UI2.WinForms.Guna2Button();
            this.txtRoomName = new Guna.UI2.WinForms.Guna2TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.btnSendChat = new Guna.UI2.WinForms.Guna2Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Player)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_chessBoard
            // 
            this.pnl_chessBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnl_chessBoard.Location = new System.Drawing.Point(11, 93);
            this.pnl_chessBoard.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_chessBoard.Name = "pnl_chessBoard";
            this.pnl_chessBoard.Size = new System.Drawing.Size(480, 510);
            this.pnl_chessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(777, 60);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 219);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.BackgroundImage = global::Caro.Properties.Resources.back_caro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.img_Player);
            this.panel3.Controls.Add(this.prcb_CoolDown);
            this.panel3.Controls.Add(this.txt_PlayerName);
            this.panel3.Location = new System.Drawing.Point(777, 298);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 261);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(79, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kí hiệu ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(42, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lượt đang đánh";
            // 
            // img_Player
            // 
            this.img_Player.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.img_Player.Location = new System.Drawing.Point(55, 134);
            this.img_Player.Margin = new System.Windows.Forms.Padding(2);
            this.img_Player.Name = "img_Player";
            this.img_Player.Size = new System.Drawing.Size(100, 100);
            this.img_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Player.TabIndex = 2;
            this.img_Player.TabStop = false;
            // 
            // prcb_CoolDown
            // 
            this.prcb_CoolDown.Location = new System.Drawing.Point(2, 74);
            this.prcb_CoolDown.Margin = new System.Windows.Forms.Padding(2);
            this.prcb_CoolDown.Name = "prcb_CoolDown";
            this.prcb_CoolDown.Size = new System.Drawing.Size(195, 36);
            this.prcb_CoolDown.TabIndex = 1;
            // 
            // txt_PlayerName
            // 
            this.txt_PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txt_PlayerName.Location = new System.Drawing.Point(62, 30);
            this.txt_PlayerName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_PlayerName.Name = "txt_PlayerName";
            this.txt_PlayerName.ReadOnly = true;
            this.txt_PlayerName.Size = new System.Drawing.Size(80, 29);
            this.txt_PlayerName.TabIndex = 0;
            this.txt_PlayerName.Text = "Player";
            this.txt_PlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tm_CountDown
            // 
            this.tm_CountDown.Tick += new System.EventHandler(this.tm_CountDown_Tick);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(542, 63);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(194, 216);
            this.txtStatus.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(579, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Thông báo";
            // 
            // lblRoomName
            // 
            this.lblRoomName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblRoomName.Location = new System.Drawing.Point(204, 24);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(107, 25);
            this.lblRoomName.TabIndex = 6;
            this.lblRoomName.Text = "Tên phòng";
            this.lblRoomName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLAN
            // 
            this.btnLAN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLAN.BorderRadius = 10;
            this.btnLAN.BorderThickness = 1;
            this.btnLAN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLAN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLAN.DisabledState.FillColor = System.Drawing.Color.DarkGray;
            this.btnLAN.DisabledState.ForeColor = System.Drawing.Color.Black;
            this.btnLAN.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLAN.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLAN.Location = new System.Drawing.Point(569, 284);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(143, 44);
            this.btnLAN.TabIndex = 9;
            this.btnLAN.Text = "Tạo phòng";
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.BorderRadius = 10;
            this.txtRoomName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomName.DefaultText = "";
            this.txtRoomName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoomName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomName.Location = new System.Drawing.Point(154, 52);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.PlaceholderText = "";
            this.txtRoomName.SelectedText = "";
            this.txtRoomName.Size = new System.Drawing.Size(200, 36);
            this.txtRoomName.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.BackgroundImage = global::Caro.Properties.Resources.background_san_go11;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnMenu
            // 
            this.mnMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNewGame,
            this.mnQuit});
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Size = new System.Drawing.Size(50, 20);
            this.mnMenu.Text = "Menu";
            // 
            // mnNewGame
            // 
            this.mnNewGame.Name = "mnNewGame";
            this.mnNewGame.Size = new System.Drawing.Size(180, 22);
            this.mnNewGame.Text = "New Game";
            this.mnNewGame.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // mnQuit
            // 
            this.mnQuit.Name = "mnQuit";
            this.mnQuit.Size = new System.Drawing.Size(180, 22);
            this.mnQuit.Text = "Quit";
            this.mnQuit.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtChat.Location = new System.Drawing.Point(542, 334);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(194, 211);
            this.txtChat.TabIndex = 11;
            // 
            // txtChatInput
            // 
            this.txtChatInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtChatInput.Location = new System.Drawing.Point(542, 566);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(144, 30);
            this.txtChatInput.TabIndex = 12;
            // 
            // btnSendChat
            // 
            this.btnSendChat.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnSendChat.BorderRadius = 10;
            this.btnSendChat.BorderThickness = 1;
            this.btnSendChat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendChat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendChat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendChat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendChat.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendChat.ForeColor = System.Drawing.Color.White;
            this.btnSendChat.Location = new System.Drawing.Point(692, 566);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(69, 30);
            this.btnSendChat.TabIndex = 13;
            this.btnSendChat.Text = "Gửi";
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(230)))), ((int)(((byte)(216)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 670);
            this.Controls.Add(this.btnSendChat);
            this.Controls.Add(this.txtChatInput);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.btnLAN);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_chessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.PictureBox img_Player;
        private System.Windows.Forms.ProgressBar prcb_CoolDown;
        private System.Windows.Forms.TextBox txt_PlayerName;
        private System.Windows.Forms.Timer tm_CountDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnMenu;
        private System.Windows.Forms.ToolStripMenuItem mnNewGame;
        private System.Windows.Forms.ToolStripMenuItem mnQuit;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRoomName;
        private Guna.UI2.WinForms.Guna2Button btnLAN;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtChatInput;
        private Guna.UI2.WinForms.Guna2Button btnSendChat;
    }
}

