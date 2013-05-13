using System;

namespace KingSurvival
{
    class KingSurvival
    {
        // for git connection test *will be removed
        static int size = 8;
        static Coordinates king = new Coordinates(4, 3);

        static Coordinates pawnA = new Coordinates(1, 0);
        
        static Coordinates pawnB = new Coordinates(3, 0);
        
        static Coordinates pawnC = new Coordinates(5, 0);
        
        static Coordinates pawnD = new Coordinates(7, 0);
        
        static bool flag = true;


        static char[,] board = new char[,] {{'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'}};

        public static bool IsKingTurn
        {
            get
            {
                return flag;
            }
        }

        public static int Size
        {
            get
            {
                return size;
            }
        }

        static void Print(char[,] gameBoard)
        {
            Console.Clear();
            
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,2}", gameBoard[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void Try(int dirX, int dirY, char[,] gameBoard)
        {

            if (king.X + dirX < 0 || king.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (king.Y + dirY < 0 || king.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }
            if (gameBoard[king.Y + dirY, king.X + dirX] == 'A') 
            {
                gameBoard[king.Y + dirY, king.X + dirX] = 'K';
                gameBoard[pawnA.Y, pawnA.X] = '-';
            }
            if (gameBoard[king.Y + dirY, king.X + dirX] == 'B')
            {
                gameBoard[king.Y + dirY, king.X + dirX] = 'K';
                gameBoard[pawnB.Y, pawnB.X] = '-';
            }
            if (gameBoard[king.Y + dirY, king.X + dirX] == 'C')
            {
                gameBoard[king.Y + dirY, king.X + dirX] = 'K';
                gameBoard[pawnC.Y, pawnC.X] = '-';
            }
            if (gameBoard[king.Y + dirY, king.X + dirX] == 'D')
            {
                gameBoard[king.Y + dirY, king.X + dirX] = 'K';
                gameBoard[pawnD.Y, pawnD.X] = '-';
            }
            gameBoard[king.Y, king.X] = '-';
            gameBoard[king.Y + dirY, king.X + dirX] = 'K';
            king.Y += dirY;
            king.X += dirX;
            return;
        }

        static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            if (pawnA.X + dirX < 0 || pawnA.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
                
            }

            if (pawnA.Y + dirY < 0 || pawnA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'D' || 
                matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'B' || 
                matrix[pawnA.Y + dirY, pawnA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
           
            matrix[pawnA.Y, pawnA.X] = '-';
            matrix[pawnA.Y + dirY, pawnA.X + dirX] = 'A';
            pawnA.Y += dirY;
            pawnA.X += dirX;
            return false;
        }
        static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnB.X + dirX < 0 || pawnB.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (pawnB.Y + dirY < 0 || pawnB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }

            if (matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'A' || 
                matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'C' || 
                matrix[pawnB.Y + dirY, pawnB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            matrix[pawnB.Y, pawnB.X] = '-';
            matrix[pawnB.Y + dirY, pawnB.X + dirX] = 'B';
            pawnB.Y += dirY;
            pawnB.X += dirX;
            return false;
        }
        static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnC.X + dirX < 0 || pawnC.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (pawnC.Y + dirY < 0 || pawnC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'A' || 
                matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'B' || 
                matrix[pawnC.Y + dirY, pawnC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[pawnC.Y, pawnC.X] = '-';
            matrix[pawnC.Y + dirY, pawnC.X + dirX] = 'C';
            pawnC.Y += dirY;
            pawnC.X += dirX;
            return false;
        }
        static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (pawnD.Y + dirY < 0 || pawnD.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (pawnD.X + dirX < 0 || pawnD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'A' || 
                matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'B' || 
                matrix[pawnD.Y + dirY, pawnD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[pawnD.Y, pawnD.X] = '-';
            matrix[pawnD.Y + dirY, pawnD.X + dirX] = 'D';
            pawnD.Y += dirY;
            pawnD.X += dirX;
            return false;
        }

        static void Main()
        {
            board[pawnA.Y, pawnA.X] = 'A';
            board[pawnB.Y, pawnB.X] = 'B';
            board[pawnC.Y, pawnC.X] = 'C';
            board[pawnD.Y, pawnD.X] = 'D';

            board[king.Y, king.X] = 'K';
            Print(board);
            bool flag2 = false;

            flag2 = RunGame(board, flag2);
            if (flag2)
            {
                Console.WriteLine("Pawn's win!");
            }
            else
            {
                Console.WriteLine("King's win!");
            }
        }
  
        private static bool RunGame(char[,] m, bool flag2)
        {
            while (king.Y > 0 && king.Y < size && !flag2)
            {
                flag = true;
                while (flag)
                {
                    flag = false;

                    Print(m);
                    Console.Write("King's Turn: ");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        flag = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                Try(-1, -1, m);
                                break;
                            }
                        case "KUR":
                            {
                                Try(1, -1, m);
                                break;
                            }
                        case "KDL":
                            {
                                Try(-1, 1, m);
                                break;
                            }
                        case "KDR":
                            {
                                Try(1, 1, m);
                                break;
                            }
                        default:
                            {
                                flag = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                }

                while (!flag)
                {
                    flag = true;
                    Print(m);
                    Console.Write("Pawn's turn: ");
                    string dd = Console.ReadLine();
                    if (dd == "")
                    {
                        flag = false;
                        continue;
                    }

                    dd = dd.ToUpper();

                    switch (dd)
                    {
                        case "ADR":
                            {
                                flag2 = PawnAMove(1, 1, m);
                                break;
                            }
                        case "ADL":
                            {
                                flag2 = PawnAMove(-1, 1, m);
                                break;
                            }
                        case "BDL":
                            {
                                flag2 = PawnBMove(-1, 1, m);
                                break;
                            }
                        case "BDR":
                            {
                                flag2 = PawnBMove(1, 1, m);
                                break;
                            }
                        case "CDL":
                            {
                                flag2 = PawnCMove(-1, 1, m);
                                break;
                            }
                        case "CDR":
                            {
                                flag2 = PawnCMove(1, 1, m);
                                break;
                            }
                        case "DDR":
                            {
                                flag2 = PawnDMove(1, 1, m);
                                break;
                            }
                        case "DDL":
                            {
                                flag2 = PawnDMove(-1, 1, m);
                                break;
                            }
                        default:
                            {
                                flag = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                    Print(m);
                }
            }
            return flag2;
        }
    }
}