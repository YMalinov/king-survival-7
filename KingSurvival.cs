using System;

namespace KingSurvival
{
    class KingSurvival
    {
        // for git connection test *will be removed
        static int size = 8;
        static Coordinates car = new Coordinates(4, 3);

        static Coordinates peshkaA = new Coordinates(1, 0);
        
        static Coordinates peshkaB = new Coordinates(3, 0);
        
        static Coordinates peshkaC = new Coordinates(5, 0);
        
        static Coordinates peshkaD = new Coordinates(7, 0);
        
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

            if (car.X + dirX < 0 || car.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (car.Y + dirY < 0 || car.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }
            if (gameBoard[car.Y + dirY, car.X + dirX] == 'A') 
            {
                gameBoard[car.Y + dirY, car.X + dirX] = 'K';
                gameBoard[peshkaA.Y, peshkaA.X] = '-';
            }
            if (gameBoard[car.Y + dirY, car.X + dirX] == 'B')
            {
                gameBoard[car.Y + dirY, car.X + dirX] = 'K';
                gameBoard[peshkaB.Y, peshkaB.X] = '-';
            }
            if (gameBoard[car.Y + dirY, car.X + dirX] == 'C')
            {
                gameBoard[car.Y + dirY, car.X + dirX] = 'K';
                gameBoard[peshkaC.Y, peshkaC.X] = '-';
            }
            if (gameBoard[car.Y + dirY, car.X + dirX] == 'D')
            {
                gameBoard[car.Y + dirY, car.X + dirX] = 'K';
                gameBoard[peshkaD.Y, peshkaD.X] = '-';
            }
            gameBoard[car.Y, car.X] = '-';
            gameBoard[car.Y + dirY, car.X + dirX] = 'K';
            car.Y += dirY;
            car.X += dirX;
            return;
        }

        static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            if (peshkaA.X + dirX < 0 || peshkaA.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
                
            }

            if (peshkaA.Y + dirY < 0 || peshkaA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'D' || 
                matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'B' || 
                matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
           
            matrix[peshkaA.Y, peshkaA.X] = '-';
            matrix[peshkaA.Y + dirY, peshkaA.X + dirX] = 'A';
            peshkaA.Y += dirY;
            peshkaA.X += dirX;
            return false;
        }
        static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaB.X + dirX < 0 || peshkaB.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (peshkaB.Y + dirY < 0 || peshkaB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }

            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'A' || 
                matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'C' || 
                matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            matrix[peshkaB.Y, peshkaB.X] = '-';
            matrix[peshkaB.Y + dirY, peshkaB.X + dirX] = 'B';
            peshkaB.Y += dirY;
            peshkaB.X += dirX;
            return false;
        }
        static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaC.X + dirX < 0 || peshkaC.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (peshkaC.Y + dirY < 0 || peshkaC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'A' || 
                matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'B' || 
                matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[peshkaC.Y, peshkaC.X] = '-';
            matrix[peshkaC.Y + dirY, peshkaC.X + dirX] = 'C';
            peshkaC.Y += dirY;
            peshkaC.X += dirX;
            return false;
        }
        static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaD.Y + dirY < 0 || peshkaD.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (peshkaD.X + dirX < 0 || peshkaD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn's win!");
                return true;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'A' || 
                matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'B' || 
                matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[peshkaD.Y, peshkaD.X] = '-';
            matrix[peshkaD.Y + dirY, peshkaD.X + dirX] = 'D';
            peshkaD.Y += dirY;
            peshkaD.X += dirX;
            return false;
        }

        static void Main()
        {
            board[peshkaA.Y, peshkaA.X] = 'A';
            board[peshkaB.Y, peshkaB.X] = 'B';
            board[peshkaC.Y, peshkaC.X] = 'C';
            board[peshkaD.Y, peshkaD.X] = 'D';

            board[car.Y, car.X] = 'K';
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
            while (car.Y > 0 && car.Y < size && !flag2)
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