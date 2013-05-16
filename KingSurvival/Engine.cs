using System;
using System.Collections.Generic;

namespace KingSurvival
{
    public class Engine
    {
        private const char PawnASymbol = 'A';
        private const char PawnBSymbol = 'B';
        private const char PawnCSymbol = 'C';
        private const char PawnDSymbol = 'D';

        private const char KingSymbol = 'K';

        Dictionary<char, ChessPiece> chessPieces = new Dictionary<char, ChessPiece>()
        {
            { PawnASymbol, new ChessPiece(PawnASymbol, 0, 0) },
            { PawnBSymbol, new ChessPiece(PawnBSymbol, 2, 0) },
            { PawnCSymbol, new ChessPiece(PawnCSymbol, 4, 0) },
            { PawnDSymbol, new ChessPiece(PawnDSymbol, 6, 0) },

            { KingSymbol, new ChessPiece(KingSymbol, 3, 7) }
        };

        Dictionary<string, Coordinates> directions = new Dictionary<string, Coordinates>()
        {
            { "UL", new Coordinates(-1, -1) }, { "UR", new Coordinates(1, -1) },
            { "DL", new Coordinates(-1,  1) }, { "DR", new Coordinates(1,  1) }
        };

        BoardRenderer boardRenderer;

        public Engine(int boardSize)
        {
            this.boardRenderer = new BoardRenderer(boardSize);
        }

        public Engine(char[,] board)
        {
            this.boardRenderer = new BoardRenderer(board);
        }

        public void Print()
        {
            this.boardRenderer.PopulateBoard(chessPieces);
            this.boardRenderer.Render();
        }

        private Coordinates ExtractDirectionFromCommand(string cmd)
        {
            string directionFromCommand = cmd.Substring(1);
            Coordinates direction = directions[directionFromCommand];

            return direction;
        }

        private bool IsValidPawnCommand(string cmd)
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

        private bool IsValidKingCommand(string cmd)
        {
            if (cmd.Length != 3)
            {
                return false;
            }

            bool validFirstChar = cmd[0] == KingSymbol;
            bool validSecondChar = cmd[1] == 'U' || cmd[1] == 'D';
            bool validThirdChar = cmd[2] == 'L' || cmd[2] == 'R';

            return validFirstChar && validSecondChar && validThirdChar;
        }

        private bool areValidCoordinates(Coordinates coordinates)
        {
            bool isWidthInScreen = (0 <= coordinates.XCoord) && (coordinates.XCoord < boardRenderer.Size);
            bool isHeightInScreen = (0 <= coordinates.YCoord) && (coordinates.YCoord < boardRenderer.Size);

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

        private bool IsKingBlocked()
        {
            Coordinates kingCoords = chessPieces[KingSymbol].Coordinates;

            foreach (var direction in directions)
            {
                Coordinates newCoords = new Coordinates(kingCoords.XCoord + direction.Value.XCoord,
                                                        kingCoords.YCoord + direction.Value.YCoord);

                bool valid = areValidCoordinates(newCoords);
                bool occupied = isOccupied(newCoords);

                if (valid && !occupied)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isKingOnFirstLine()
        {
            return chessPieces[KingSymbol].YCoord == 0;
        }

        private bool allPawnsOnLastLine()
        {
            bool allAtLastLine = true;

            foreach (var pawn in chessPieces)
            {
                if (pawn.Value.Symbol == KingSymbol)
                {
                    continue;
                }

                allAtLastLine &= (pawn.Value.YCoord == boardRenderer.Size - 1);
            }

            return allAtLastLine;
        }

        private void movePiece(char currentPiece, int newX, int newY)
        {
            chessPieces[currentPiece].XCoord = newX;
            chessPieces[currentPiece].YCoord = newY;
        }

        public void Run()
        {
            int moves = 0;
            while (true)
            {
                while (true)
                {
                    this.Print();

                    if (IsKingBlocked())
                    {
                        boardRenderer.WriteMessage(Message.KingLose);
                        Environment.Exit(0);
                    }

                    string input = UserInput.GetInput(Player.King);

                    if (IsValidKingCommand(input))
                    {
                        Coordinates direction = ExtractDirectionFromCommand(input);
                        Coordinates newCoords = new Coordinates(chessPieces[KingSymbol].XCoord + direction.XCoord, chessPieces[KingSymbol].YCoord + direction.YCoord);

                        if (areValidCoordinates(newCoords) && !isOccupied(newCoords))
                        {
                            movePiece(KingSymbol, newCoords.XCoord, newCoords.YCoord);
                            break;
                        }
                        else
                        {
                            boardRenderer.WriteMessage(Message.InvalidMove);
                        }
                    }
                    else
                    {
                        boardRenderer.WriteMessage(Message.InvalidMove);
                    }
                }

                moves++;

                while (true)
                {
                    this.Print();

                    if (allPawnsOnLastLine() || isKingOnFirstLine())
                    {
                        boardRenderer.WriteMessage(Message.KingWin, moves);
                        Environment.Exit(0);
                    }

                    string input = UserInput.GetInput(Player.Pawn);

                    if (IsValidPawnCommand(input))
                    {
                        Coordinates direction = ExtractDirectionFromCommand(input);
                        Coordinates newCoords = new Coordinates(chessPieces[input[0]].XCoord + direction.XCoord, chessPieces[input[0]].YCoord + direction.YCoord);
                        if (areValidCoordinates(newCoords) && !isOccupied(newCoords))
                        {
                            movePiece(input[0], newCoords.XCoord, newCoords.YCoord);
                            break;
                        }
                        else
                        {
                            boardRenderer.WriteMessage(Message.InvalidMove);
                        }
                    }
                    else
                    {
                        boardRenderer.WriteMessage(Message.InvalidMove);
                    }

                    this.Print();
                }

                moves++;
            }
        }
    }
}