using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        

        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
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

        #endregion

        #region Initialize

        public ChessBoardManager(Panel chessBoard, TextBox playerName,PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            Player = new List<Player>() 
            { 
                new Player("Bi9Chuot",Image.FromFile("D:\\Laptrinhmang\\Caro\\Caro\\Resources\\o.png")),
                new Player("Cuong7Nui",Image.FromFile("D:\\Laptrinhmang\\Caro\\Caro\\Resources\\x.png")),
                
            };
            
        }

        #endregion

        #region Methods

        public void MarkRemote(int x, int y)
        {
            Button btn = Matrix[y][x];

            if (btn.BackgroundImage != null)
                return;

            btn.BackgroundImage = Player[CurrentPlayer].Mark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();
        }
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();
            CurrentPlayer = 0;
            ChangePlayer();
            Matrix = new List<List<Button>>();
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
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
            Button btn = sender as Button;

            if (btn.BackgroundImage != null) 
                return;


            Mark(btn);
            ChangePlayer();



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

        private bool isEndGame(Button btn)
        {

            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }

        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal,vertical);

            return point;
        }

        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            for (int i = point.X; i >=0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else 
                    break;

            }


            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;

            }   

            return countLeft + countRight >= 5;
        }

        private bool isEndVertical(Button btn)
        {

            Point point = GetChessPoint(btn);
            int countUp = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countUp++;
                }
                else
                    break;

            }


            int countDown = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countDown++;
                }
                else
                    break;

            }

            return countUp + countDown >= 5;
        }

        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countUpLeft = 0;
            // Lên - Trái (X--, Y--)
            for (int x = point.X, y = point.Y; x >= 0 && y >= 0; x--, y--)
            {
                if (Matrix[y][x].BackgroundImage == btn.BackgroundImage)
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
                if (Matrix[y][x].BackgroundImage == btn.BackgroundImage)
                    countDownRight++;
                else
                    break;
            }

            return countUpLeft + countDownRight >= 5;
        }

        private bool isEndSub(Button btn)
        {

            Point point = GetChessPoint(btn);

            int countUpRight = 0;
            // Lên - Phải (X++, Y--)
            for (int x = point.X, y = point.Y;
                 x < Cons.CHESS_BOARD_WIDTH && y >= 0;
                 x++, y--)
            {
                if (Matrix[y][x].BackgroundImage == btn.BackgroundImage)
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
                if (Matrix[y][x].BackgroundImage == btn.BackgroundImage)
                    countDownLeft++;
                else
                    break;
            }

            return countUpRight + countDownLeft >= 5;
        }


        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;
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
