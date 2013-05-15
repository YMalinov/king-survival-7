using System;
using System.Collections.Generic;

class Engine
{
    int size = 0;

    Dictionary<char, ChessPiece> chessPieces = new Dictionary<char, ChessPiece>()
    {
        { 'A', new ChessPiece('A', 0, 0) },
        { 'B', new ChessPiece('B', 2, 0) },
        { 'C', new ChessPiece('C', 4, 0) },
        { 'D', new ChessPiece('D', 6, 0) },
        { 'K', new ChessPiece('K', 3, 7) }
    };

    Dictionary<string, Coordinates> directions = new Dictionary<string, Coordinates>()
    {
        { "UL", new Coordinates(-1, -1) }, { "UR", new Coordinates(1, -1) },
        { "DL", new Coordinates(-1,  1) }, { "DR", new Coordinates(1,  1) }
    };
    
    bool stopGame = false;

    BoardRenderer boardRenderer;

    public Engine(int boardSize)
    {
        this.size = boardSize;
        this.boardRenderer = new BoardRenderer(boardSize);
    }

    public Engine(char[,] board)
    {
        this.size = board.GetLength(0);
        this.boardRenderer = new BoardRenderer(board);
    }

    public void Print()
    {
        this.boardRenderer.PopulateBoard(chessPieces);
        this.boardRenderer.Render();
    }

    private Coordinates extractDirectionFromCommand(string cmd)
    {
        string directionFromCommand = cmd.Substring(1);
        Coordinates direction = directions[directionFromCommand];

        return direction;
    }

    private bool isValidPawnCommand(string cmd)
    {
        if (cmd.Length != 3)
        {
            return false;
        }

        bool validFirstChar = cmd[0] == 'A' || cmd[0] == 'B' || cmd[0] == 'C' || cmd[0] == 'D';
        bool validSecondChar = cmd[1] == 'D';
        bool validThirdChar = cmd[2] == 'L' || cmd[2] == 'R';

        return validFirstChar && validSecondChar && validThirdChar;
    }

    private bool isValidKingCommand(string cmd)
    {
        if (cmd.Length != 3)
        {
            return false;
        }

        bool validFirstChar = cmd[0] == 'K';
        bool validSecondChar = cmd[1] == 'U' || cmd[1] == 'D';
        bool validThirdChar = cmd[2] == 'L' || cmd[2] == 'R';

        return validFirstChar && validSecondChar && validThirdChar;
    }

    private bool areValidCoordinates(Coordinates coordinates)
    {
        bool isWidthInScreen = (0 < coordinates.X) && (coordinates.X < size - 1);
        bool isHeightInScreen = (0 < coordinates.Y) && (coordinates.Y < size - 1);

        return isWidthInScreen && isHeightInScreen;
    }

    private bool isOccupied(Coordinates coordinates)
    {
        foreach (var piece in chessPieces)
        {
            if (piece.Value.Coordinates == coordinates)
            {
                return true;
            }
        }

        return false;
    }

    private bool isKingBlocked()
    {
        Coordinates kingCoords = chessPieces['K'].Coordinates;

        foreach (var direction in directions)
        {
            Coordinates newCoords = new Coordinates(kingCoords.X + direction.Value.X, 
                                                    kingCoords.Y + direction.Value.Y);

            bool valid = areValidCoordinates(newCoords);
            bool occupied = isOccupied(newCoords);

            if (valid && !occupied)
            {
                return false;
            }
        }

        return true;
    }

    private bool allPawnsOnLastLine()
    {
        bool allAtLastLine = true;

        foreach (var pawn in chessPieces)
        {
            if (pawn.Value.Symbol == 'K')
            {
                continue;
            }

            allAtLastLine &= (pawn.Value.Y == size - 1);
        }

        return allAtLastLine;
    }

    private void movePiece(char currentPiece, int dirX, int dirY)
    {
        chessPieces[currentPiece].Y = dirY;
        chessPieces[currentPiece].X = dirX;
    }

    private void illegalMoveScreen()
    {
        Console.WriteLine("Illegal move!");
        Console.ReadKey();
    }

    public bool Run()
    {
        while (chessPieces['K'].Y > 0 && chessPieces['K'].Y < size && !stopGame)
        {
            while (true)
            {
                this.Print();

                if (isKingBlocked())
                {
                    Console.WriteLine("King loses!");
                    Environment.Exit(0);
                }

                Console.Write("King's Turn: ");
                string input = Console.ReadLine();

                input = input.ToUpper();
                if (isValidKingCommand(input))
                {
                    Coordinates direction = extractDirectionFromCommand(input);
                    Coordinates newCoords = new Coordinates(chessPieces['K'].X + direction.X, chessPieces['K'].Y + direction.Y);

                    if (areValidCoordinates(newCoords) && !isOccupied(newCoords))
                    {
                        movePiece('K', newCoords.X, newCoords.Y);
                        break;
                    }
                    else
                    {
                        illegalMoveScreen();
                    }
                }
                else
                {
                    illegalMoveScreen();
                }
            }

            while (true)
            {
                this.Print();

                if (allPawnsOnLastLine())
                {
                    Console.WriteLine("King wins!");
                    Environment.Exit(0);
                }

                Console.Write("Pawns' turn: ");
                string input = Console.ReadLine();

                input = input.ToUpper();
                if (isValidPawnCommand(input))
                {
                    Coordinates direction = extractDirectionFromCommand(input);
                    Coordinates newCoords = new Coordinates(chessPieces[input[0]].X + direction.X, chessPieces[input[0]].Y + direction.Y);
                    if (areValidCoordinates(newCoords) && !isOccupied(newCoords))
                    {
                        movePiece(input[0], newCoords.X, newCoords.Y);
                        break;
                    }
                    else
                    {
                        illegalMoveScreen();
                    }
                }
                else
                {
                    illegalMoveScreen();
                }

                this.Print();
            }
        }

        return stopGame;
    }
}