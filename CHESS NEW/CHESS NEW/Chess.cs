using CHESS_NEW;
using System;
using System.Collections.Generic;
using System.Text;

//棋子类
namespace Chess
{    
   
    //颜色枚举
    public enum COLOUR
    {
    RED,BLACK,Recommend,White
    }
    
    
    //棋子坐标结构体
    public struct ChessPoint
    {
        private int x;
        private int y;
        public ChessPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set {x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }


    //棋子父类
    public  abstract class ChessPiece
    {
        protected COLOUR colour;
        protected ChessPoint currentpoint;
        protected ChessBoard chessboard;
        public ChessPiece(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard)
        {
            this.colour = colour;
            this.currentpoint = piecespoint;
            this.chessboard = chessboard;
         
        }
        public COLOUR Color
        {
            get { return colour; }
            set { colour = value; }
        }
        public ChessPoint CurrentPoint
        {
            get { return currentpoint; }
            set { currentpoint = value; }
        }
        public ChessBoard ChessBoard
        {
            get { return chessboard; }
            set { chessboard = value; }
        }
        public  abstract string ChessName{ get;}
        protected abstract bool JudgeMove(ChessPoint p);


        // 移动方法
        public void MoveTo(ChessPoint ToPoint)
        {
            //目标棋子和当前棋子颜色不能一致 
            ChessPiece targetChess = chessboard[ToPoint];
            if (targetChess != null && targetChess.Color == this.Color) return;
            //是否满足规则
            if (!JudgeMove(ToPoint)) {
                Console.WriteLine("The piece can not move there!");
                return; 
            }

            
            //移动
            chessboard[currentpoint] = null;
            chessboard[ToPoint] = this;
            this.currentpoint = ToPoint;

        }

        //推荐步骤
        public void Recommend()
        {
            for(int j = 0; j < 10; j++)
            {
                for(int i = 0; i < 9; i++)
                {
                    ChessPoint point = new ChessPoint(i, j);
                    while (this.JudgeMove(point))
                    {
                        chessboard.CurrentChess.CurrentPoint=point;
                        chessboard[i, j].Color = COLOUR.Recommend;
                        ChessBoard.DrawBoard();
                    }
                }
            }
        }

        //获取两点之前的棋子数
        public int GetChessCount(ChessPoint s,ChessPoint e)
        {
            //如果Y相同
            if (s.Y == e.Y)
            {
                int min = Math.Min(s.X, e.X);
                int max = Math.Max(s.X, e.X);
                int count = 0;
                for(int i = min + 1; i < max; i++)
                {
                    if (chessboard[i, s.Y] != null)
                        count++;
                }
                return count;
            }
            else
            {
                int min = Math.Min(s.Y,e.Y);
                int max = Math.Max(s.Y, e.Y);
                int count = 0;
                for(int i = min + 1; i < max; i++)
                {
                    if (chessboard[s.X, i] != null)
                        count++;
                }
                return count;
            }
        }

    }


    
    //棋子子类
    class Jiang : ChessPiece
    {
        public Jiang(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {

        }
        public override string ChessName {
            get
            {
                if (colour == COLOUR.RED)

                    return "将";

                else 
                    return "帅";
                
            }
        }
        
        
        // 棋子是否能够移动到目标点
        protected override bool JudgeMove(ChessPoint tragPoint)
        { 
            if (!((tragPoint.X >= 3 && tragPoint.X <= 5) && (tragPoint.Y <= 2 || tragPoint.Y >= 7)))//出九宫格
                return false;

            if ((Math.Abs(tragPoint.X - this.currentpoint.X) + Math.Abs(tragPoint.Y - this.currentpoint.Y)) != 1)//
                return false;

            return true;
        }


    }

    class Bing : ChessPiece
    {
        private bool isRiverd = false;
        private int step = 0; 
        public Bing(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {
            if (currentpoint.Y > 4)
                step = -1;
            else
                step = 1;
        }
        public override string ChessName
        {
            get
            {
                if (colour == COLOUR.RED)
                    return "兵";
                else
                    return "卒";
            }
        }
        protected override bool JudgeMove(ChessPoint p)
        {

            if (p.Y - currentpoint.Y == -step)
                return false;

            if (Math.Abs(currentpoint.X - p.X) + Math.Abs(currentpoint.Y - p.Y) != 1)
                return false;

            if (!isRiverd)
            {
                if (currentpoint.Y == 4 && p.Y == 5) isRiverd = true;
                if (currentpoint.Y == 5 && p.Y == 4) isRiverd = true;
            }

            if (!isRiverd)
            {
                if (p.Y - currentpoint.Y != step)
                    return false;
            }

            return true;
        }

    }

    class Ma : ChessPiece
    {
        public Ma(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {
            
        }
        public override string ChessName
        {
            get
            {
                    return "马";
            }
        }
        protected override bool JudgeMove(ChessPoint p)
        {
 
            if (Math.Abs(currentpoint.X - p.X) == 2 && Math.Abs(currentpoint.Y - p.Y) == 1)
            {
                if (chessboard[(currentpoint.X + p.X) / 2, currentpoint.Y] == null)
                    return true;
            }
            if (Math.Abs(currentpoint.X - p.X) == 1 && Math.Abs(currentpoint.Y - p.Y) == 2)
            {
                if (chessboard[currentpoint.X, (currentpoint.Y + p.Y) / 2] == null)
                    return true;
            }
            return false;
        }
    }

    class Che : ChessPiece
    {
        public Che(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {
        }
        public override string ChessName
        {
            get
            {  
                return "車";
            }
        }

        protected override bool JudgeMove(ChessPoint p)
        {
            if (p.X != currentpoint.X && p.Y != currentpoint.Y)
                return false;
            if (GetChessCount(currentpoint, p) > 0)
                return false;
            return true;
        }

    }

    class Xiang : ChessPiece
    {
        public Xiang(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {

        }
        public override string ChessName
        {
            get
            {
                    return "象";
            }
        }
        protected override bool JudgeMove(ChessPoint p)
        {
            if (Math.Abs(currentpoint.X - p.X) != 2 || Math.Abs(currentpoint.Y - p.Y) != 2)
                return false;

            if (chessboard[(currentpoint.X + p.X) / 2, (currentpoint.Y + p.Y) / 2] != null)
                return false;

            if (currentpoint.Y <= 4 && p.Y > 4) return false;
            if (currentpoint.Y >= 5 && p.Y < 5) return false;

            return true;
        }

    }

    class Shi : ChessPiece
    {
        public Shi(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {

        }
        public override string ChessName
        {
            get
            {

                return "士";
            }
        }
        protected override bool JudgeMove(ChessPoint tragPoint)
        {
            if (!((tragPoint.X >= 3 && tragPoint.X <= 5) && (tragPoint.Y <= 2 || tragPoint.Y >= 7)))
                return false;

            if (!(Math.Abs(tragPoint.X - this.currentpoint.X) == 1 && Math.Abs(tragPoint.Y - this.currentpoint.Y) == 1))
                return false;

            return true;
        }
    }

    class Pao : ChessPiece
    {

        public Pao(COLOUR colour, ChessPoint piecespoint, ChessBoard chessboard) : base(colour, piecespoint, chessboard)
        {

        }
        public override string ChessName
        {
            get
            {

                    return "炮";

            }
        }
        protected override bool JudgeMove(ChessPoint targPoint)
        {
            if (targPoint.X != currentpoint.X && targPoint.Y != currentpoint.Y)
                return false;

            if (chessboard[targPoint] != null && GetChessCount(currentpoint, targPoint) != 1)
                return false;

            if (chessboard[targPoint] == null && GetChessCount(currentpoint, targPoint) > 0)
                return false;

            return true;

        }
    }

  




}
