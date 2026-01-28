using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2;
using Guna.UI2.WinForms;
namespace Caro
{
    public class ChessBoardManager
    {


        #region Properties
        private Panel chessBoard;

        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        

        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; } 
        }
        private int currentPlayer;
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        private TextBox playerName;
        public TextBox PlayerName
        {
            get { return playerName; }
            set {  playerName = value; }
        }
        private PictureBox playerMark;
        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }

        
        // Tu
        private List<List<Guna2Button>> matrix;
        public List<List<Guna2Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        public event Action<int, int> PlayerMoved;

        #endregion

        //Nhi


        #region Initialize

        public ChessBoardManager(Panel chessBoard, TextBox playerName,PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            Player = new List<Player>() 
            { 
                new Player("Player1",Image.FromFile("D:\\Laptrinhmang\\Caro\\Caro\\Resources\\o.png")),
                new Player("Player2",Image.FromFile("D:\\Laptrinhmang\\Caro\\Caro\\Resources\\x.png")),

                
            };
            
        }

        #endregion

        
        #region Methods

        public void MarkRemote(int x, int y)
        {
            Guna2Button btn = Matrix[y][x];

            if (btn.Image != null)
                return;

            btn.Image = Player[CurrentPlayer].Mark;
            Mark(btn);
            ChangePlayer();
        }
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();
            CurrentPlayer = 0;
            ChangePlayer();
            Matrix = new List<List<Guna2Button>>();
            Guna2Button oldButton = new Guna2Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Guna2Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Guna2Button btn = new Guna2Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        FillColor = Color.White,
                        BorderRadius = 2,
                        BorderThickness = 2,
                        BorderColor = Color.Black,
                        Tag = i.ToString()
                    };
                    btn.Click += btn_Click; 
                    ChessBoard.Controls.Add(btn);

                    Matrix[i].Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;

            if (btn.Image != null) 
                return;


            Mark(btn);

            Point p = GetChessPoint(btn);
            PlayerMoved?.Invoke(p.X, p.Y);

            ChangePlayer();

            playerMarked?.Invoke(this, EventArgs.Empty);

            if (playerMarked != null)
            {
                playerMarked(this, new EventArgs());
            }

            if (isEndGame(btn))
            {
                EndGame();
            }
                
        }

        public void EndGame()
        {
            if(endedGame != null)
            {
                endedGame(this,new EventArgs());
            }
        }

        //Ny
        private bool isEndGame(Guna2Button btn)
        {

            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }

        private Point GetChessPoint(Guna2Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal,vertical);

            return point;
        }

        private bool isEndHorizontal(Guna2Button btn)
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            for (int i = point.X; i >=0; i--)
            {
                if (Matrix[point.Y][i].Image == btn.Image)
                {
                    countLeft++;
                }
                else 
                    break;

            }


            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].Image == btn.Image)
                {
                    countRight++;
                }
                else
                    break;

            }   

            return countLeft + countRight >= 5;
        }

        private bool isEndVertical(Guna2Button btn)
        {

            Point point = GetChessPoint(btn);
            int countUp = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].Image == btn.Image)
                {
                    countUp++;
                }
                else
                    break;

            }


            int countDown = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].Image == btn.Image)
                {
                    countDown++;
                }
                else
                    break;

            }

            return countUp + countDown >= 5;
        }

        private bool isEndPrimary(Guna2Button btn)
        {
            Point point = GetChessPoint(btn);

            int countUpLeft = 0;
            // Lên - Trái (X--, Y--)
            for (int x = point.X, y = point.Y; x >= 0 && y >= 0; x--, y--)
            {
                if (Matrix[y][x].Image == btn.Image)
                    countUpLeft++;
                else
                    break;
            }
            int countDownRight = 0;
            // Xuống - Phải (X++, Y++)
            for (int x = point.X + 1, y = point.Y + 1;
                 x < Cons.CHESS_BOARD_WIDTH && y < Cons.CHESS_BOARD_HEIGHT;
                 x++, y++)
            {
                if (Matrix[y][x].Image == btn.Image)
                    countDownRight++;
                else
                    break;
            }

            return countUpLeft + countDownRight >= 5;
        }

        private bool isEndSub(Guna2Button btn)
        {

            Point point = GetChessPoint(btn);

            int countUpRight = 0;
            // Lên - Phải (X++, Y--)
            for (int x = point.X, y = point.Y;
                 x < Cons.CHESS_BOARD_WIDTH && y >= 0;
                 x++, y--)
            {
                if (Matrix[y][x].Image == btn.Image)
                    countUpRight++;
                else
                    break;
            }

            int countDownLeft = 0;
            // Xuống - Trái (X--, Y++)
            for (int x = point.X - 1, y = point.Y + 1;
                 x >= 0 && y < Cons.CHESS_BOARD_HEIGHT;
                 x--, y++)
            {
                if (Matrix[y][x].Image == btn.Image)
                    countDownLeft++;
                else
                    break;
            }

            return countUpRight + countDownLeft >= 5;
        }


        private void Mark(Guna2Button btn)
        {
            btn.Image = Player[CurrentPlayer].Mark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }


        #endregion

    }
}
