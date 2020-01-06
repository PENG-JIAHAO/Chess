using CHESS_NEW;
using System;
using System.Collections.Generic;
using System.Text;

//棋盘类
namespace Chess
{
    public class ChessBoard
    {
        public static ChessPiece[,] chesses = new ChessPiece[9, 10];
        private ChessPiece currentChess;
        private bool enableMove = false;
        public bool turn = false;//false=red & true=black
        public ChessPiece this[ChessPoint p]
        {
            get
            {
                return chesses[p.X, p.Y];
            }
            set
            {
                chesses[p.X, p.Y] = value;
            }
        }
        public ChessPiece this[int x, int y]
        {
            get
            {
                return chesses[x, y];
            }
            set
            {
                chesses[x, y] = value;
            }
        }

        // 当前棋子
        public ChessPiece CurrentChess
        {
            get { return currentChess; }
            set { currentChess = value; }
        }



        //是否允许移动棋子
        public bool EnableMove {
            get {
                return enableMove;
            } 
            set { 
                enableMove = value; 
            } 
        }


        // 棋盘构造函数
        public ChessBoard()
        {

        }

        // 画棋盘
        public void Reset()
        {

            #region 黑棋
            chesses[0, 0] = new Che(COLOUR.BLACK, new ChessPoint(0, 0), this);//车
            chesses[1, 0] = new Ma(COLOUR.BLACK, new ChessPoint(1, 0), this);//马
            chesses[2, 0] = new Xiang(COLOUR.BLACK, new ChessPoint(2, 0), this);//象
            chesses[3, 0] = new Shi(COLOUR.BLACK, new ChessPoint(3, 0), this);//士
            chesses[4, 0] = new Jiang(COLOUR.BLACK, new ChessPoint(4, 0), this);//将/帅
            chesses[5, 0] = new Shi(COLOUR.BLACK, new ChessPoint(5, 0), this);//士
            chesses[6, 0] = new Xiang(COLOUR.BLACK, new ChessPoint(6, 0), this);//象
            chesses[7, 0] = new Ma(COLOUR.BLACK, new ChessPoint(7, 0), this);//马
            chesses[8, 0] = new Che(COLOUR.BLACK, new ChessPoint(8, 0), this);//车
            chesses[1, 2] = new Pao(COLOUR.BLACK, new ChessPoint(1, 2), this);//炮
            chesses[7, 2] = new Pao(COLOUR.BLACK, new ChessPoint(7, 2), this);//炮
            chesses[0, 3] = new Bing(COLOUR.BLACK, new ChessPoint(0, 3), this);//兵
            chesses[2, 3] = new Bing(COLOUR.BLACK, new ChessPoint(2, 3), this);//兵
            chesses[4, 3] = new Bing(COLOUR.BLACK, new ChessPoint(4, 3), this);//兵
            chesses[6, 3] = new Bing(COLOUR.BLACK, new ChessPoint(6, 3), this);//兵
            chesses[8, 3] = new Bing(COLOUR.BLACK, new ChessPoint(8, 3), this);//兵
            #endregion

            #region 红棋
            chesses[0, 9] = new Che(COLOUR.RED, new ChessPoint(0, 9), this);
            chesses[1, 9] = new Ma(COLOUR.RED, new ChessPoint(1, 9), this);
            chesses[2, 9] = new Xiang(COLOUR.RED, new ChessPoint(2, 9), this);
            chesses[3, 9] = new Shi(COLOUR.RED, new ChessPoint(3, 9), this);
            chesses[4, 9] = new Jiang(COLOUR.RED, new ChessPoint(4, 9), this);
            chesses[5, 9] = new Shi(COLOUR.RED, new ChessPoint(5, 9), this);
            chesses[6, 9] = new Xiang(COLOUR.RED, new ChessPoint(6, 9), this);
            chesses[7, 9] = new Ma(COLOUR.RED, new ChessPoint(7, 9), this);
            chesses[8, 9] = new Che(COLOUR.RED, new ChessPoint(8, 9), this);
            chesses[1, 7] = new Pao(COLOUR.RED, new ChessPoint(1, 7), this);
            chesses[7, 7] = new Pao(COLOUR.RED, new ChessPoint(7, 7), this);
            chesses[0, 6] = new Bing(COLOUR.RED, new ChessPoint(0, 6), this);
            chesses[2, 6] = new Bing(COLOUR.RED, new ChessPoint(2, 6), this);
            chesses[4, 6] = new Bing(COLOUR.RED, new ChessPoint(4, 6), this);
            chesses[6, 6] = new Bing(COLOUR.RED, new ChessPoint(6, 6), this);
            chesses[8, 6] = new Bing(COLOUR.RED, new ChessPoint(8, 6), this);
            #endregion
     
            this.DrawBoard();
        }

        //绘制棋盘
        public  void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  " + " 0 " + " 1 " + " 2 " + " 3 " + " 4 " + " 5 " + " 6 " + " 7 " + " 8 ");
            for (int j = 0; j < 10; j++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{j} ");
                Console.ResetColor();
                for (int i = 0; i < 9; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;

                    //棋子不为空
                    if (chesses[i, j] != null)
                    {
                        //红旗输出
                        if (chesses[i, j].Color == COLOUR.RED)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" { ChessBoard.chesses[i, j].ChessName}");
                            Console.ResetColor();
                        }
                        //黑棋输出
                        if (ChessBoard.chesses[i, j].Color == COLOUR.BLACK)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" { ChessBoard.chesses[i, j].ChessName}");
                            Console.ResetColor();
                        }
                        //推荐走位输出
                        if (ChessBoard.chesses[i, j].Color == COLOUR.Recommend)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($" { ChessBoard.chesses[i, j].ChessName}");
                            Console.ResetColor();
                        }



                    }
                    //棋子为空
                    else 
                    {
                        /*if (chesses[i, j].Color == COLOUR.Recommend)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" ╋ "); Console.ResetColor();
                        }*/
                        Console.Write(" ╋ ");
                        Console.ResetColor();
                        
                    }


                    if (i == 8)
                    {

                        Console.Write("\n");

                    }

                }


            }


        }

        //红方 选中棋子
        public void SeclectRedChess(ChessPoint point)
        {
                this.CurrentChess = this[point];
                //当前棋子为空
                if (this.CurrentChess== null)
                {
                    this.DrawBoard();
                    Console.WriteLine("\nNo chess pieces selected.");
                    turn = false;
                }
                //当前棋子为黑色（选错棋子）
                if (this.CurrentChess.Color == COLOUR.BLACK)
                {
                    this.DrawBoard();
                    Console.WriteLine("\nPlease select the Red Pieces!");
                    turn = false;
                }
                //当前棋子为红色（选对棋子）
                if (this.CurrentChess.Color == COLOUR.RED)
                {                    
                    //CurrentChess.Recommend();
                    EnableMove = true;
                }
            
        }

        // 红棋移动棋子
        public void MoveRedChess(ChessPoint point)
        {
            try
            {
                ChessPiece chess = this[point];
                //当前棋子为红色（选对棋子）
                if (this.CurrentChess.Color == COLOUR.RED)
                {
                    //目标棋子不是红色(空或者黑）
                    if (chess == null || chess.Color != this.CurrentChess.Color)
                    {
                        ChessPoint currPoint = this.CurrentChess.CurrentPoint;//保存变量

                        this.CurrentChess.MoveTo(point);//移动棋子
                        EnableMove = true;

                        //如果移动失败
                        if (!this.CurrentChess.CurrentPoint.Equals(point))
                        {
                            EnableMove = false;
                            return;
                        }
                        turn = true;
                        this.DrawBoard();
                    }

                    //目标棋子是红色
                    if (chess.Color == COLOUR.RED)
                    {
                        this.DrawBoard();
                        Console.WriteLine("Please select a Black Pieces!");
                        turn = false;
                        return;
                    }

                    //移动棋子完成，重画棋盘
                    this.DrawBoard();
                }
            }
            catch
            {

            }
        }

        //黑方 选中棋子
        public void SeclectBlackChess(ChessPoint point)
        {
            try
            {
                this.CurrentChess = this[point];
                //当前棋子为空
                if (this.CurrentChess == null)
                {
                    this.DrawBoard();
                    Console.WriteLine("\nNo chess pieces selected.");
                    turn = true;
                }
                //当前棋子为红色（选错棋子）
                if (this.CurrentChess.Color == COLOUR.RED)
                {
                    this.DrawBoard();
                    Console.WriteLine("\nPlease select the Red Pieces!");
                    turn = true;
                }
                //当前棋子为黑色（选对棋子）
                if (this.CurrentChess.Color == COLOUR.BLACK)
                {
                    //currentChess.Recommend();
                    EnableMove =true;
                }
            }
            catch { }

        }

        // 黑棋移动棋子
        public void MoveBlackChess(ChessPoint point)
        {
            try
            {
                ChessPiece chess = this[point];
                //当前棋子为黑色（选对棋子）
                if (this.CurrentChess.Color == COLOUR.BLACK)
                {
                    //目标棋子不是黑色(空或者红）
                    if (chess == null || chess.Color != this.CurrentChess.Color)
                    {
                        ChessPoint currPoint = this.CurrentChess.CurrentPoint;//保存变量

                        this.CurrentChess.MoveTo(point);//移动棋子
                        EnableMove = true;

                        //如果移动失败
                        if (!this.CurrentChess.CurrentPoint.Equals(point))
                        {
                            EnableMove = false;
                            return;
                        }

                        turn = false;
                        this.DrawBoard();
                    }

                    //目标棋子是黑色
                    if (chess.Color == COLOUR.BLACK)
                    {
                        this.DrawBoard();
                        Console.WriteLine("Please select a Red Pieces!");
                        turn = false;
                        return;
                    }

                    //移动棋子完成，重画棋盘
                    this.DrawBoard();
                }
            }
            catch(Exception ex)
            {
                
            }
        }



        /*// 黑棋移动棋子
        public void MoveBlackChess(ChessPoint point)
        {
            try
            {
                ChessPiece chess = this[point];
                //当前棋子为空
                if (this.CurrentChess == null)
                {
                    View.DrawBoard();
                    Console.WriteLine("\nNo chess pieces selected.");
                    //目标棋子情况
                    if (chess == null) return;
                    if (chess.Color != COLOUR.BLACK) return;
                    if (chess.Color == COLOUR.BLACK) return;

                    turn = true;
                }
                //当前棋子为红色（选错棋子）
                if (this.CurrentChess.Color == COLOUR.RED)
                {
                    View.DrawBoard();
                    Console.WriteLine("\nPlease select the Black Pieces!");
                    //目标棋子情况
                    if (chess == null) return;
                    if (chess.Color != COLOUR.BLACK) return;
                    if (chess.Color == COLOUR.BLACK) return;

                    turn = true;
                }
                //当前棋子为黑色（选对棋子）
                if (this.CurrentChess.Color == COLOUR.BLACK)
                {
                    //目标棋子不是黑色(空或者红色）
                    if (chess == null || chess.Color != this.CurrentChess.Color)
                    {
                        ChessPoint currPoint = this.CurrentChess.CurrentPoint;//保存变量

                        this.CurrentChess.MoveTo(point);//移动棋子
                        EnableMove = true;

                        //如果移动失败
                        if (!this.CurrentChess.CurrentPoint.Equals(point))
                        {
                            EnableMove = false;
                            return;
                        }
                        this.CurrentChess = null;
                        turn = false;
                        View.DrawBoard();
                    }

                    //目标棋子是黑色
                    if (chess.Color == COLOUR.BLACK)
                    {
                        View.DrawBoard();
                        Console.WriteLine("Please select a Red Pieces!");
                        turn = true;
                        return;
                    }

                    //移动棋子完成，重画棋盘
                    View.DrawBoard();
                }
            }
            catch
            {

            }
        }*/

    }
    public class Player
    {
        public String name;
        public COLOUR color;

        public Player(string name, COLOUR color)
        {
            this.name = name;
            this.color = color;

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public COLOUR PlayerColor
        {
            get { return color; }
            set { color = value; }
        }
    }



}
