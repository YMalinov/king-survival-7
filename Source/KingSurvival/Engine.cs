using System;
using System.Collections.Generic;

namespace KingSurvival
{
    /// <summary>
    /// The "Engine" class of the game. Here's where the magic happens.
    /// </summary>
    public class Engine
    {
        #region Constants

        /// <summary>
        /// Keeps the symbol of the first pawn ('A' is default).
        /// </summary>
        private const char PawnASymbol = 'A';

        /// <summary>
        /// Keeps the symbol of the second pawn ('B' is default).
        /// </summary>
        private const char PawnBSymbol = 'B';

        /// <summary>
        /// Keeps the symbol of the third pawn ('C' is default).
        /// </summary>
        private const char PawnCSymbol = 'C';

        /// <summary>
        /// Keeps the symbol of the fourth pawn ('D' is default).
        /// </summary>
        private const char PawnDSymbol = 'D';

        /// <summary>
        /// Keeps the symbol of the king ('K' is default).
        /// </summary>
        private const char KingSymbol = 'K';

        #endregion

        #region Private Fields

        /// <summary>
        /// Keeps the chess pieces in a dictionary, for convenient access, through their symbol.
        /// </summary>
        Dictionary<char, ChessPiece> chessPieces = new Dictionary<char, ChessPiece>()
        {
            { PawnASymbol, new ChessPiece(PawnASymbol, 0, 0) },
            { PawnBSymbol, new ChessPiece(PawnBSymbol, 2, 0) },
            { PawnCSymbol, new ChessPiece(PawnCSymbol, 4, 0) },
            { PawnDSymbol, new ChessPiece(PawnDSymbol, 6, 0) },

            { KingSymbol, new ChessPiece(KingSymbol, 3, 7) }
        };

        /// <summary>
        /// Keeps all available directions of the game.
        /// </summary>
        Dictionary<string, Coordinates> directions = new Dictionary<string, Coordinates>()
        {
            { "UL", new Coordinates(-1, -1) }, { "UR", new Coordinates(1, -1) },
            { "DL", new Coordinates(-1,  1) }, { "DR", new Coordinates(1,  1) }
        };

        /// <summary>
        /// An instance of the BoardRenderer class, which will be used for writing on the console.
        /// </summary>
        BoardRenderer boardRenderer;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates the engine, with a board size of boardSize * boardSize (default 8 * 8).
        /// </summary>
        /// <param name="boardSize">The size of the board (height/width).</param>
        public Engine(int boardSize = 8)
        {
            this.boardRenderer = new BoardRenderer(boardSize);
        }

        /// <summary>
        /// Instantiates the engine, with a custom board. The BoardRenderer will throw an ArgumentException,
        /// if the input board's width and height aren't equal.
        /// </summary>
        /// <param name="board">The input board.</param>
        public Engine(char[,] board)
        {
            this.boardRenderer = new BoardRenderer(board);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Extracts the wanted direction from a command. We're actually only interested in
        /// the last two letters of the cmd variable.
        /// </summary>
        /// <param name="cmd">The player command.</param>
        /// <returns>A variable of type "Coordinates", with the wanted direction.</returns>
        private Coordinates ExtractDirectionFromCommand(string cmd)
        {
            string directionFromCommand = cmd.Substring(1);
            Coordinates direction = directions[directionFromCommand];

            return direction;
        }

        /// <summary>
        /// Checks if the player issued command is valid for pawns (keep in mind that pawns can't move up).
        /// </summary>
        /// <param name="cmd">The player command</param>
        /// <returns>A bool value, indicating whether the player issued command is valid for pawns.</returns>
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

        /// <summary>
        /// Checks if the player issued command is valid for the king (the king can move up).
        /// </summary>
        /// <param name="cmd">The player command</param>
        /// <returns>A bool value, indicating whether the player issued command is valid for the king.</returns>
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

        /// <summary>
        /// Checks if the input coordinates are in the board.
        /// </summary>
        /// <param name="coordinates">The input coordinates.</param>
        /// <returns>A bool value, indicating whether the coordinates are valid.</returns>
        private bool AreValidCoordinates(Coordinates coordinates)
        {
            bool isWidthInScreen = (0 <= coordinates.XCoord) && (coordinates.XCoord < boardRenderer.Size);
            bool isHeightInScreen = (0 <= coordinates.YCoord) && (coordinates.YCoord < boardRenderer.Size);

            return isWidthInScreen && isHeightInScreen;
        }

        /// <summary>
        /// Checks if the cell at the input coordinates is occupied by another chess piece.
        /// </summary>
        /// <param name="coordinates">The input coordinates.</param>
        /// <returns>A bool value, indicating whether the coordinates are occupied or not.</returns>
        private bool IsOccupied(Coordinates coordinates)
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

        /// <summary>
        /// Checks if the king has any valid moves left. Otherwise the game should end, with a win for the pawns.
        /// </summary>
        /// <returns>A bool value, indicating whether the king is blocked.</returns>
        private bool IsKingBlocked()
        {
            Coordinates kingCoords = chessPieces[KingSymbol].Coordinates;

            foreach (var direction in directions)
            {
                Coordinates newCoords = new Coordinates(kingCoords.XCoord + direction.Value.XCoord,
                                                        kingCoords.YCoord + direction.Value.YCoord);

                bool valid = AreValidCoordinates(newCoords);
                bool occupied = IsOccupied(newCoords);

                if (valid && !occupied)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether the king is on the first row of the board. If so, the game should end, with a win for the king.
        /// </summary>
        /// <returns>A bool value, indicating whether the king is on the first row.</returns>
        private bool IsKingOnFirstRow()
        {
            return chessPieces[KingSymbol].YCoord == 0;
        }

        /// <summary>
        /// Checks whether all pawns are on the last row of the board. If so, the game should end with a win for the king,
        /// as the pawns have no valid moves left.
        /// </summary>
        /// <returns>A bool value, indicating whether all pawns are on the last row.</returns>
        private bool AllPawnsOnLastRow()
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

        /// <summary>
        /// Moves a chess piece, to designated coordinates.
        /// </summary>
        /// <param name="currentPiece">A char value, indicating the current chess piece.</param>
        /// <param name="newCoords">The new coordinates.</param>
        private void MovePiece(char currentPiece, Coordinates newCoords)
        {
            chessPieces[currentPiece].Coordinates = newCoords;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Populates the board with the new positions of all chess pieces and renders it (writes it
        /// on the console).
        /// </summary>
        public void Print()
        {
            this.boardRenderer.PopulateBoard(chessPieces);
            this.boardRenderer.Render();
        }

        /// <summary>
        /// Here are the loops, which actually run the game. Here's what each of them does:
        ///     1. Print the board on the console, clearing the old one.
        ///     2. Check if the king or the pawns have won.
        ///     3. Get input from the player (if the input is invalid, or impossible, print "Illegal move!" and try again).
        ///     4. Move the piece to the designated direction and continue playing, until a side wins.
        /// </summary>
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
                        Coordinates newCoords = chessPieces[KingSymbol].Coordinates + direction;

                        if (AreValidCoordinates(newCoords) && !IsOccupied(newCoords))
                        {
                            MovePiece(KingSymbol, newCoords);
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

                    if (AllPawnsOnLastRow() || IsKingOnFirstRow())
                    {
                        boardRenderer.WriteMessage(Message.KingWin, moves);
                        Environment.Exit(0);
                    }

                    string input = UserInput.GetInput(Player.Pawn);

                    if (IsValidPawnCommand(input))
                    {
                        Coordinates direction = ExtractDirectionFromCommand(input);
                        Coordinates newCoords = chessPieces[input[0]].Coordinates + direction;

                        if (AreValidCoordinates(newCoords) && !IsOccupied(newCoords))
                        {
                            MovePiece(input[0], newCoords);
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

        #endregion

        #region Main Entry Point

        /// <summary>
        /// Doesn't seem to compile without it...
        /// </summary>
        static void Main()
        {
        }

        #endregion
    }
}