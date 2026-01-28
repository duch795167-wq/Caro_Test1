using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Guna.UI2;
using System.Windows.Forms;

namespace Caro
{
    
    public partial class Form1 : Form
    {
        #region Properties 

        ChessBoardManager  ChessBoard;
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;
        bool myTurn = false;
        bool isO = false;
        int newgame = 0;

        #endregion
        public Form1()
        {
            InitializeComponent();
            
            ChessBoard = new ChessBoardManager(pnl_chessBoard,txt_PlayerName,img_Player);
            
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;
            ChessBoard.PlayerMoved += ChessBoard_PlayerMoved;

            prcb_CoolDown.Step = Cons.COOL_DOWN_STEP;
            prcb_CoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcb_CoolDown.Value = 0;
            tm_CountDown.Interval = Cons.COOL_DOWN_INTERVAL;
            newgame = 1;
            


            NewGame(newgame);
            
        }


        #region Methods
       

        void NewGame(int newgame)
        {
            if (newgame == 1)
            {
                
                prcb_CoolDown.Value = 0;
                tm_CountDown.Stop();
                ChessBoard.DrawChessBoard();
                pnl_chessBoard.Enabled = false;
                mnNewGame.Enabled = false;
                
            }
            else
            {
                prcb_CoolDown.Value = 0;
                tm_CountDown.Stop();
                ChessBoard.DrawChessBoard();
                mnNewGame.Enabled = false;
                pnl_chessBoard.Enabled = (isO);
                myTurn = (isO); // O đi trước
                prcb_CoolDown.Value = 0;
                txtStatus.Text = "Bắt đầu chơi lại";
                
            }
        }

        void EndGame(string typeEnd)
        {
            tm_CountDown.Stop();
            pnl_chessBoard.Enabled = false;

            if (typeEnd == "TIMEOUT")
            {
                MessageBox.Show("Đã hết giờ");
                SendTimeOut();

            }
            else if (typeEnd == "WIN")
            {
                SendEnd();
                MessageBox.Show("Đã có người thắng");
                
                
            }


        }

        void QuitGame()
        {
            try
            {
                if (client != null && client.Connected)
                {
                    // Gửi thông báo cho server
                    SendOut();
                    stream?.Close();
                    client?.Close();
                }
            }
            catch { }


        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát game?",
        "Thoát", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                QuitGame();
                
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            if(myTurn)
                tm_CountDown.Start();
            else
                tm_CountDown.Stop();
            prcb_CoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame("WIN");
        }

        private void tm_CountDown_Tick(object sender, EventArgs e)
        {
            
            if(prcb_CoolDown.Value >= prcb_CoolDown.Maximum)
            {
                string typeEnd = "TIMEOUT";
                EndGame(typeEnd);
                
            }
            prcb_CoolDown.PerformStep();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NewGame(newgame);
            
        }

        


        #endregion

        private void btnLAN_Click(object sender, EventArgs e)
        {
            string ip ="127.0.0.1";
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
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    this.Invoke((MethodInvoker)(() =>
                    {

                        if (message.StartsWith("OUT"))
                        {

                            string[] parts = message.Split('|');
                            string outplayer = parts[1];
                            txtStatus.AppendText(Environment.NewLine + outplayer);
                            ChessBoard.DrawChessBoard();
                            pnl_chessBoard.Enabled = false;
                            tm_CountDown.Stop();
                            prcb_CoolDown.Enabled = false;
                            prcb_CoolDown.Value = 0;
                            txtRoomName.Text = "";
                            btnLAN.Enabled = true;
                        }

                        // 1️⃣ Chờ đối thủ
                        if (message.StartsWith("WAIT"))
                        {
                            txtStatus.Text = "Đang chờ đối thủ...";
                            btnLAN.Enabled = false;
                            pnl_chessBoard.Enabled = false;
                        }

                        // 2️⃣ Bắt đầu game
                        else if (message.StartsWith("START"))
                        {
                            btnLAN.Enabled = false;
                            string[] parts = message.Split('|');
                            string role = parts[1]; // X hoặc O
                            string roomname = parts[2];
                            txtRoomName.Text = roomname;
                            if (role == "O")
                            {
                                txtStatus.Text = "Bắt đầu game - Bạn là O";
                                txtStatus.AppendText(Environment.NewLine + "Bạn là Player 1" 
                                    + Environment.NewLine+ "Bạn được đánh đầu tiên");
                                isO = true;
                            }
                            else
                            {
                                txtStatus.Text = "Bắt đầu game - Bạn là X";
                                txtStatus.AppendText(Environment.NewLine + "Bạn là Player 2" 
                                    + Environment.NewLine + "Đợi O đánh");
                                isO = false;
                            }

                            pnl_chessBoard.Enabled = (role == "O");
                            myTurn = (role == "O"); // O đi trước
                            prcb_CoolDown.Value = 0;

                        }

                        // 3️⃣ Nhận nước đi
                        else if (message.StartsWith("MOVE"))
                        {
                            string[] parts = message.Split('|');
                            int x = int.Parse(parts[1]);
                            int y = int.Parse(parts[2]);
                            this.Invoke((MethodInvoker)(() =>
                            {

                                ChessBoard.MarkRemote(x, y);
                                myTurn = true;
                                pnl_chessBoard.Enabled = true;
                                prcb_CoolDown.Value = 0;
                                tm_CountDown.Start(); // ❗ tới lượt mình → chạy timer
                            }));


                        }

                        else if (message.StartsWith("TIMEOUT"))
                        {
                            string[] parts = message.Split('|');
                            string winner = parts[1] == "P1" ? "Player2" : "Player1";
                            this.Invoke((MethodInvoker)(() =>
                            {

                                txtStatus.AppendText(Environment.NewLine + $"Người thắng: {winner}");

                            }));
                        }
                        else if (message.StartsWith("WIN"))
                        {
                            string[] parts = message.Split('|');
                            string winner = parts[1] == "P1" ? "Player1" : "Player2";
                            this.Invoke((MethodInvoker)(() =>
                            {

                                txtStatus.AppendText(Environment.NewLine + $"Người thắng: {winner}");
                                pnl_chessBoard.Enabled = false;
                                tm_CountDown.Stop();
                                prcb_CoolDown.Enabled = false;
                                prcb_CoolDown.Value = 0;
                                mnNewGame.Enabled = true;
                                newgame++;
                            }));
                        }

                    }));
                }
            }
            catch
            {
                MessageBox.Show("Mất kết nối server");
            }
        }
        void ChessBoard_PlayerMoved(int x, int y)
        {
            if (!myTurn) return;   // không phải lượt mình → bỏ

            SendMove(x, y);

            myTurn = false;
            
            
            prcb_CoolDown.Enabled = false;
            prcb_CoolDown.Value = 0;
        }


        #region SendMethod
        
        void SendMove(int x, int y)
        {
            try
            {
                string msg = $"MOVE|{x}|{y}\n";
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);

                myTurn = false;
                tm_CountDown.Stop();
                pnl_chessBoard.Enabled = false;
                prcb_CoolDown.Enabled = false;
                prcb_CoolDown.Value = 0;
                
            
            }
            catch
            {
                MessageBox.Show("Lỗi gửi nước đi");
            }
        }

        void SendTimeOut()
        {
            try
            {
                string msg = "TIMEOUT\n";
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);


            }
            catch
            {
                MessageBox.Show("Lỗi end game");
            }
        }
        void SendEnd()
        {
            try
            {
                string msg = "ENDGAME\n";
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);

            }
            catch
            {
                MessageBox.Show("Lỗi end game");
            }
        }
        void SendOut()
        {
            try
            {
                string msg = "OUT\n";
                if (stream == null) return;

                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
            catch { }
        }




        #endregion

      
    }
}
