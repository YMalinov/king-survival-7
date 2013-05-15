using System;
using System.Collections.Generic;

class Engine
{
    int size = 0;

    Dictionary<char, ChessPiece> chessPieces = new Dictionary<char, ChessPiece>()
    {
        { 'A', new ChessPiece('A', 1, 0) },
        { 'B', new ChessPiece('B', 3, 0) },
        { 'C', new ChessPiece('C', 5, 0) },
        { 'D', new ChessPiece('D', 7, 0) },
    };

    King king = new King(4, 7);

    char[,] gameBoard = null;

    bool IsKingTurn = true;

    bool stopGame = false;

    public Engine(char[,] board)
    {
        this.size = board.GetLength(0);
        this.gameBoard = board;
    }

    private char[,] PopulateBoard(char[,] board)
    {
        foreach (var piece in chessPieces)
        {
            if (piece.Value.InGame)
            {
                board[piece.Value.Y, piece.Value.X] = piece.Value.Symbol;
            }
        }

        board[king.Y, king.X] = king.Symbol;

        return board;
    }

    public void Print()
    {
        Console.Clear();

        char[,] board = (char[,])gameBoard.Clone();

        board = PopulateBoard(board);

        int height = board.GetLength(0);
        int width = board.GetLength(1);

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write("{0,2}", board[row, col]);
            }

            Console.WriteLine();
        }
    }

    private bool MoveKing(int dirX, int dirY)
    {
        if ((king.X + dirX < 0 || king.X + dirX > size - 1) ||
            (king.Y + dirY < 0 || king.Y + dirY > size - 1))
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = true;
            return false;
        }

        foreach (var piece in chessPieces)
        {
            if (king.Y + dirY == piece.Value.Y && 
                king.X + dirX == piece.Value.X)
            {
                piece.Value.InGame = false;
            }
        }

        if (king.X == 0)
        {
            return true;
        }

        king.Y += dirY;
        king.X += dirX;

        return false;
    }

    private bool MovePawn(char currentPawn, Coordinates direction)
    {
        if ((chessPieces[currentPawn].X + direction.X < 0 || chessPieces[currentPawn].X + direction.X > size - 1) ||
            (chessPieces[currentPawn].Y + direction.Y < 0 || chessPieces[currentPawn].Y + direction.Y > size - 1))
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        if (chessPieces[currentPawn].Y + direction.Y == king.Y && 
            chessPieces[currentPawn].X + direction.X == king.X)
        {
            Console.WriteLine("Pawn's win!");
            return true;
        }

        if (chessPieces[currentPawn].Y + direction.Y == chessPieces['A'].Y && chessPieces[currentPawn].X + direction.X == chessPieces['A'].X ||
            chessPieces[currentPawn].Y + direction.Y == chessPieces['B'].Y && chessPieces[currentPawn].X + direction.X == chessPieces['B'].X ||
            chessPieces[currentPawn].Y + direction.Y == chessPieces['C'].Y && chessPieces[currentPawn].X + direction.X == chessPieces['C'].X ||
            chessPieces[currentPawn].Y + direction.Y == chessPieces['D'].Y && chessPieces[currentPawn].X + direction.X == chessPieces['D'].X)
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
            IsKingTurn = false;
            return false;
        }

        chessPieces[currentPawn].Y += direction.Y;
        chessPieces[currentPawn].X += direction.X;
        return false;
    }

    private void ExecuteCommand(string cmd)
    {
        int x = 0;
        int y = 0;

        switch (cmd[1])
        {
            case 'D':
                {
                    y = 1;
                    break;
                }
            case 'U':
                {
                    y = -1;
                    break;
                }
            default:
                {
                    throw new ArgumentException("Invalid command!");
                }
        }

        switch (cmd[2])
        {
            case 'L':
                {
                    x = -1;
                    break;
                }
            case 'R':
                {
                    x = 1;
                    break;
                }
            default:
                {
                    throw new ArgumentException("Invalid command!");
                }
        }

        if (cmd[0] == 'K')
        {
            stopGame = MoveKing(x, y);
        }
        else
        {
            stopGame = MovePawn(cmd[0], new Coordinates(x, y));
        }
    }

    private bool isValidCommand(string cmd, bool isKing = false)
    {
        if (cmd.Length != 3)
        {
            return false;
        }

        bool validFirstChar = isKing ? (cmd[0] == 'K') : (cmd[0] == 'A' || cmd[0] == 'B' || cmd[0] == 'C' || cmd[0] == 'D');
        bool validSecondChar = isKing ? (cmd[1] == 'U' || cmd[1] == 'D') : (cmd[1] == 'D');
        bool validThirdChar = cmd[2] == 'L' || cmd[2] == 'R';

        if (validFirstChar && !isKing && !chessPieces[cmd[0]].InGame)
        {
            return false;
        }

        return validFirstChar && validSecondChar && validThirdChar;
    }

    public bool Run()
    {
        while (king.Y > 0 && king.Y < size && !stopGame)
        {
            IsKingTurn = true;
            while (IsKingTurn)
            {
                IsKingTurn = false;
                this.Print();

                Console.Write("King's Turn: ");
                string input = Console.ReadLine();

                input = input.ToUpper();

                if (isValidCommand(input, true))
                {
                    ExecuteCommand(input);
                }
                else
                {
                    IsKingTurn = true;
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("**Press a key to continue**");
                    Console.ReadKey();
                }
            }

            while (!IsKingTurn)
            {
                IsKingTurn = true;
                this.Print();

                Console.Write("Pawn's turn: ");
                string input = Console.ReadLine();

                input = input.ToUpper();

                if (isValidCommand(input))
                {
                    ExecuteCommand(input);
                }
                else
                {
                    IsKingTurn = false;
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("**Press a key to continue**");
                    Console.ReadKey();
                }

                this.Print();
            }
        }
        return stopGame;
    }
}