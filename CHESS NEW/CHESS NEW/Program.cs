using System;
using Chess;
using CHESS_NEW;

namespace CHESS_NEW
{
    class Program
    {

        static void Main(string[] args)
        {
            Game();
        }
        public static void Game()
        {
            try
            {
                //初始化棋盘
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.Reset();
                //设置玩家
                Console.WriteLine("\nPlease enter the name of PlayerRed:");
                Player playerRed = new Player(Console.ReadLine(), COLOUR.RED);
                Console.WriteLine("\nPlease enter the name of PlayerBlack:");
                Player playerBlack = new Player(Console.ReadLine(), COLOUR.BLACK);

                bool gameover = false;

                while(gameover == false)
                {
                    //下棋
                    while (chessBoard.turn==false)
                    {
                        //红                    
                        Console.WriteLine($"\nPlayerRed:{playerRed.name}. Please select one piece: ");
                        string input1 = Console.ReadLine(); string input2 = Console.ReadLine();
                        ChessPoint p1 = new ChessPoint(int.Parse(input1), int.Parse(input2));
                        chessBoard.SeclectRedChess(p1);
                        if (chessBoard.EnableMove == true)
                        {
                            Console.WriteLine($"\nPlayerRed:{playerRed.name}. Please select a location to move: ");
                            string input3 = Console.ReadLine(); string input4 = Console.ReadLine();
                            ChessPoint p2 = new ChessPoint(int.Parse(input3), int.Parse(input4));
                            chessBoard.MoveRedChess(p2);
                        }
                    }
                    while (chessBoard.turn == true)
                    {
                        //黑
                        Console.WriteLine($"\nPlayerBlack:{playerBlack.name}. Please select one piece: ");
                        string input5 = Console.ReadLine(); string input6 = Console.ReadLine();
                        ChessPoint p3 = new ChessPoint(int.Parse(input5), int.Parse(input6));
                        chessBoard.SeclectBlackChess(p3);
                        if (chessBoard.EnableMove == true)
                        {
                            Console.WriteLine($"\nPlayerBlack:{playerBlack.name}. Please select a location to move: ");
                            string input7 = Console.ReadLine(); string input8 = Console.ReadLine();
                            ChessPoint p4 = new ChessPoint(int.Parse(input7), int.Parse(input8));
                            chessBoard.MoveBlackChess(p4);
                        }

                    }
                }





            }
            catch (System.Exception e) { Console.WriteLine(e); }
        }


        
    }


}
  
        
 





