using System;
using System.Text;
using System.Collections.Generic;

namespace KingSurvival
{
    /// <summary>
    /// Here's where the writing on the console is done.
    /// </summary>
    public class BoardRenderer
    {
        #region Constants

        /// <summary>
        /// The char for the white cells.
        /// </summary>
        private const char WhiteCell = '-';

        /// <summary>
        /// The char for the black cells.
        /// </summary>
        private const char BlackCell = '+';

        #endregion

        #region Private Fields

        /// <summary>
        /// A two dimensional char array, containing the initial state of the game board.
        /// </summary>
        private char[,] emptyBoard = null;

        /// <summary>
        /// A two dimensional char array, containing the game board with all of the chess pieces on it.
        /// </summary>
        private char[,] populatedBoard = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates the BoardRenderer with a custom size. The game board is generated
        /// with the GenerateBoard method.
        /// </summary>
        /// <param name="size">An integer, indicating the width/height of the game board.</param>
        public BoardRenderer(int size)
        {
            this.EmptyBoard = GenerateBoard(size);
        }

        /// <summary>
        /// Instantiates the BoardRenderer with a custom two-dimensional char array, for a board.
        /// </summary>
        /// <remarks>
        /// Will throw an ArgumentException, if the width and height if the input char[,] are not equal.
        /// </remarks>
        /// <param name="board">A two dimensional char array, representing the game board.</param>
        public BoardRenderer(char[,] board)
        {
            this.EmptyBoard = board;
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// The property, containing the initial state of the board.
        /// </summary>
        /// <remarks>
        /// Will throw an ArgumentException, if the board sides aren't equal.
        /// </remarks>
        private char[,] EmptyBoard
        {
            get
            {
                return emptyBoard;
            }
            set
            {
                if (value.GetLength(0) != value.GetLength(1))
                {
                    throw new ArgumentException("Invalid board size: both sides must be equal!");
                }

                this.emptyBoard = value;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The property, containing the length of the side of the game board.
        /// </summary>
        public int Size
        {
            get
            {
                return emptyBoard.GetLength(0);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Will generate a custom size two-dimensional char array, representing the 
        /// game board, with alternating white and black cells.
        /// </summary>
        /// <param name="size">The length of the side of the board.</param>
        /// <returns>A two-dimensional char array, representing the game board.</returns>
        private char[,] GenerateBoard(int size)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row % 2 == 0)
                    {
                        if (col % 2 == 0)
                        {
                            board[row, col] = BlackCell;
                        }
                        else
                        {
                            board[row, col] = WhiteCell;
                        }
                    }
                    else
                    {
                        if (col % 2 == 0)
                        {
                            board[row, col] = WhiteCell;
                        }
                        else
                        {
                            board[row, col] = BlackCell;
                        }
                    }
                }
            }

            return board;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the chess pieces on the initial board, on their corresponding coordinates.
        /// </summary>
        /// <param name="pieces">The dictionary, containing each chess piece.</param>
        public void PopulateBoard(Dictionary<char, ChessPiece> pieces)
        {
            this.populatedBoard = (char[,])this.EmptyBoard.Clone();

            foreach (var piece in pieces)
            {
                this.populatedBoard[piece.Value.XCoord, piece.Value.YCoord] = piece.Value.Symbol;
            }
        }

        /// <summary>
        /// Prints a message on the screen.
        /// </summary>
        /// <param name="msg">An Message enum value, indicating which message should be written.</param>
        /// <param name="moves">How many moves have passed, since the beginning of the game (default : 0).</param>
        public void WriteMessage(Message msg, int moves = 0)
        {
            string messageAsString = "";
            switch (msg)
            {
                case Message.InvalidMove:
                    {
                        messageAsString = "Illegal move!";
                        break;
                    }
                case Message.KingWin:
                    {
                        messageAsString = string.Format("King wins in {0} turns.", moves);
                        break;
                    }
                case Message.KingLose:
                    {
                        messageAsString = string.Format("King loses");
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Not a recognized message!");
                    }
            }

            Console.WriteLine(messageAsString);
            Console.ReadKey();
        }

        /// <summary>
        /// Clears the console and prints the decorated game board.
        /// </summary>
        public void Render()
        {
            Console.Clear();

            int len = populatedBoard.GetLength(0);

            StringBuilder output = new StringBuilder();

            output.Append("    ");
            for (int index = 0; index < len; index++)
            {
                output.Append(index + " ");
            }
            output.Append('\n');

            string border = string.Format("{0}{1}\n", new string(' ', 3), new string('-', populatedBoard.GetLength(0) * 2 + 1));
            output.Append(border);

            for (int row = 0; row < len; row++)
            {
                output.AppendFormat("{0} | ", row);
                for (int col = 0; col < len; col++)
                {
                    output.Append(populatedBoard[col, row] + " ");
                }

                output.Append("|\n");
            }

            output.Append(border);

            Console.Write(output);
        }

        #endregion
    }
}