using System;

class Engine
{
    int size = 0;

    King king = new King(4, 7);

    ChessPiece pawnA = new ChessPiece('A', 1, 0);

    ChessPiece pawnB = new ChessPiece('B', 3, 0);

    ChessPiece pawnC = new ChessPiece('C', 5, 0);

    ChessPiece pawnD = new ChessPiece('D', 7, 0);

    char[,] gameBoard = null;

    bool IsKingTurn = true;

    public Engine(char[,] board)
    {
        //TODO: add an "AddObject" method in this class
        board[pawnA.Y, pawnA.X] = pawnA.Symbol;
        board[pawnB.Y, pawnB.X] = pawnB.Symbol;
        board[pawnC.Y, pawnC.X] = pawnC.Symbol;
        board[pawnD.Y, pawnD.X] = pawnD.Symbol;
        board[king.Y, king.X] = king.Symbol;

        this.size = board.GetLength(0);
        this.gameBoard = board;
    }

    public void Print()
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

    private void Try(int dirX, int dirY)
    {

        if (king.X + dirX < 0 || king.X + dirX > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = true;
            return;
        }

        if (king.Y + dirY < 0 || king.Y + dirY > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = true;
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

    //there should be a single method "PawnMove(Pawn currentPawn, int newX, int newY)", 
    //which moves the currentPawn to coordinates(newX, newY)
    private bool PawnAMove(int dirX, int dirY)
    {
        if (pawnA.X + dirX < 0 || pawnA.X + dirX > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
                
        }

        if (pawnA.Y + dirY < 0 || pawnA.Y + dirY > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        if (gameBoard[pawnA.Y + dirY, pawnA.X + dirX] == 'K')
        {
            Console.WriteLine("Pawn's win!");
            return true;
        }
        if (gameBoard[pawnA.Y + dirY, pawnA.X + dirX] == 'D' || 
            gameBoard[pawnA.Y + dirY, pawnA.X + dirX] == 'B' || 
            gameBoard[pawnA.Y + dirY, pawnA.X + dirX] == 'C')
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
           
        gameBoard[pawnA.Y, pawnA.X] = '-';
        gameBoard[pawnA.Y + dirY, pawnA.X + dirX] = 'A';
        pawnA.Y += dirY;
        pawnA.X += dirX;
        return false;
    }
    private bool PawnBMove(int dirX, int dirY)
    {
        if (pawnB.X + dirX < 0 || pawnB.X + dirX > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        if (pawnB.Y + dirY < 0 || pawnB.Y + dirY > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        if (gameBoard[pawnB.Y + dirY, pawnB.X + dirX] == 'K')
        {
            Console.WriteLine("Pawn's win!");
            return true;
        }

        if (gameBoard[pawnB.Y + dirY, pawnB.X + dirX] == 'A' || 
            gameBoard[pawnB.Y + dirY, pawnB.X + dirX] == 'C' || 
            gameBoard[pawnB.Y + dirY, pawnB.X + dirX] == 'D')
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        gameBoard[pawnB.Y, pawnB.X] = '-';
        gameBoard[pawnB.Y + dirY, pawnB.X + dirX] = 'B';
        pawnB.Y += dirY;
        pawnB.X += dirX;
        return false;
    }
    private bool PawnCMove(int dirX, int dirY)
    {
        if (pawnC.X + dirX < 0 || pawnC.X + dirX > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        if (pawnC.Y + dirY < 0 || pawnC.Y + dirY > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        if (gameBoard[pawnC.Y + dirY, pawnC.X + dirX] == 'K')
        {
            Console.WriteLine("Pawn's win!");
            return true;
        }
        if (gameBoard[pawnC.Y + dirY, pawnC.X + dirX] == 'A' || 
            gameBoard[pawnC.Y + dirY, pawnC.X + dirX] == 'B' || 
            gameBoard[pawnC.Y + dirY, pawnC.X + dirX] == 'D')
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        gameBoard[pawnC.Y, pawnC.X] = '-';
        gameBoard[pawnC.Y + dirY, pawnC.X + dirX] = 'C';
        pawnC.Y += dirY;
        pawnC.X += dirX;
        return false;
    }
    private bool PawnDMove(int dirX, int dirY)
    {
        if (pawnD.Y + dirY < 0 || pawnD.Y + dirY > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        if (pawnD.X + dirX < 0 || pawnD.X + dirX > size - 1)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }
        if (gameBoard[pawnD.Y + dirY, pawnD.X + dirX] == 'K')
        {
            Console.WriteLine("Pawn's win!");
            return true;
        }
        if (gameBoard[pawnD.Y + dirY, pawnD.X + dirX] == 'A' || 
            gameBoard[pawnD.Y + dirY, pawnD.X + dirX] == 'B' || 
            gameBoard[pawnD.Y + dirY, pawnD.X + dirX] == 'C')
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        gameBoard[pawnD.Y, pawnD.X] = '-';
        gameBoard[pawnD.Y + dirY, pawnD.X + dirX] = 'D';
        pawnD.Y += dirY;
        pawnD.X += dirX;
        return false;
    }

    public bool Run()
    {
        bool flag2 = false;

        while (king.Y > 0 && king.Y < size && !flag2)
        {
            IsKingTurn = true;
            while (IsKingTurn)
            {
                IsKingTurn = false;

                Print();
                Console.Write("King's Turn: ");
                string direction = Console.ReadLine();
                if (direction == "")
                {
                    IsKingTurn = true;
                    continue;
                }

                direction = direction.ToUpper();

                switch (direction)
                {
                    case "KUL":
                        {
                            Try(-1, -1);
                            break;
                        }
                    case "KUR":
                        {
                            Try(1, -1);
                            break;
                        }
                    case "KDL":
                        {
                            Try(-1, 1);
                            break;
                        }
                    case "KDR":
                        {
                            Try(1, 1);
                            break;
                        }
                    default:
                        {
                            IsKingTurn = true;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine("**Press a key to continue**");
                            Console.ReadKey();
                            break;
                        }
                }
            }

            while (!IsKingTurn)
            {
                IsKingTurn = true;
                this.Print();
                Console.Write("Pawn's turn: ");
                string dd = Console.ReadLine();
                if (dd == "")
                {
                    IsKingTurn = false;
                    continue;
                }

                dd = dd.ToUpper();

                switch (dd)
                {
                    case "ADR":
                        {
                            flag2 = PawnAMove(1, 1);
                            break;
                        }
                    case "ADL":
                        {
                            flag2 = PawnAMove(-1, 1);
                            break;
                        }
                    case "BDL":
                        {
                            flag2 = PawnBMove(-1, 1);
                            break;
                        }
                    case "BDR":
                        {
                            flag2 = PawnBMove(1, 1);
                            break;
                        }
                    case "CDL":
                        {
                            flag2 = PawnCMove(-1, 1);
                            break;
                        }
                    case "CDR":
                        {
                            flag2 = PawnCMove(1, 1);
                            break;
                        }
                    case "DDR":
                        {
                            flag2 = PawnDMove(1, 1);
                            break;
                        }
                    case "DDL":
                        {
                            flag2 = PawnDMove(-1, 1);
                            break;
                        }
                    default:
                        {
                            IsKingTurn = false;
                            Console.WriteLine("Invalid input!");
                            Console.WriteLine("**Press a key to continue**");
                            Console.ReadKey();
                            break;
                        }
                }
                this.Print();
            }
        }
        return flag2;
    }
}