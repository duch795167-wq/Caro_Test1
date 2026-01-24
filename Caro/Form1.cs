using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Caro
{
    
    public partial class Form1 : Form
    {
        #region Properties 

        ChessBoardManager  ChessBoard;
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
    }
}
