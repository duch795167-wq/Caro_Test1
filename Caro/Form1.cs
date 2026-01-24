using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Caro
{
    
    public partial class Form1 : Form
    {
        #region Properties 

        ChessBoardManager  ChessBoard;
        SocketManager socket = new SocketManager();
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        bool myTurn = false;


        #endregion
        public Form1()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(pnl_chessBoard,txt_PlayerName,img_Player);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            prcb_CoolDown.Step = Cons.COOL_DOWN_STEP;
            prcb_CoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcb_CoolDown.Value = 0;
            tm_CountDown.Interval = Cons.COOL_DOWN_INTERVAL;


            
            NewGame();
            
        }


        #region Methods
        void EndGame()
        {
            tm_CountDown.Stop();
            pnl_chessBoard.Enabled = false;
            MessageBox.Show("Ket thuc");

        }

        void NewGame()
        {
            prcb_CoolDown.Value = 0;
            tm_CountDown.Stop();
            ChessBoard.DrawChessBoard();

            
        }

        void QuitGame()
        {
            if(MessageBox.Show("Ban co chac muon thoat","Thong bao", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
               Application.Exit();
            }
        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tm_CountDown.Start();
            prcb_CoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void tm_CountDown_Tick(object sender, EventArgs e)
        {
            prcb_CoolDown.PerformStep();
            if(prcb_CoolDown.Value >= prcb_CoolDown.Maximum)
            {
                
                EndGame();
                
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co chac muon thoat", "Thong bao", MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }


        #endregion
        
        private void btnLAN_Click(object sender, EventArgs e)
        {
            string ip = string.IsNullOrEmpty(txtIP.Text) ? "127.0.0.1" : txtIP.Text.Trim();
            try
            {


                client = new TcpClient(ip, 9999);
                stream = client.GetStream();

                txtStatus.Text = "Đã kết nối server!\n";
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch
            {
                MessageBox.Show("Khong ket noi duoc server");
            }
        }


        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    this.Invoke((MethodInvoker)(() =>
                    {
                        // 1️⃣ Chờ đối thủ
                        if (message == "WAIT")
                        {
                            txtStatus.Text = "Đang chờ đối thủ...";
                            pnl_chessBoard.Enabled = false;
                        }

                        // 2️⃣ Bắt đầu game
                        else if (message.StartsWith("START"))
                        {
                            string[] parts = message.Split('|');
                            string role = parts[1]; // X hoặc O

                            txtStatus.Text = $"Bắt đầu game - Bạn là {role}";
                            pnl_chessBoard.Enabled = (role == "X");
                            myTurn = (role == "X"); // X đi trước
                        }

                        // 3️⃣ Nhận nước đi
                        else if (message.StartsWith("MOVE"))
                        {
                            string[] parts = message.Split('|');
                            int x = int.Parse(parts[1]);
                            int y = int.Parse(parts[2]);

                            ChessBoard.MarkRemote(x, y);
                            myTurn = true;
                            pnl_chessBoard.Enabled = true;
                        }
                    }));
                }
            }
            catch
            {
                MessageBox.Show("Mất kết nối server");
            }
        }


    }
}
