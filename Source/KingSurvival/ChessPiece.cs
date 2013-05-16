namespace KingSurvival
{
    /// <summary>
    /// A class, containing all information about a chess piece.
    /// </summary>
    public class ChessPiece
    {
        #region Constructors

        /// <summary>
        /// Creates an instance of the ChessPiece class.
        /// </summary>
        /// <param name="symbol">The desired symbol for this chess piece.</param>
        /// <param name="startingCoordinates">The starting coordinates.</param>
        public ChessPiece(char symbol, Coordinates startingCoordinates)
        {
            this.Symbol = symbol;
            this.Coordinates = startingCoordinates;
        }

        /// <summary>
        /// Creates an instance of the ChessPiece class.
        /// </summary>
        /// <param name="symbol">The desired symbol for this chess piece.</param>
        /// <param name="X">The X coordinate for the starting position.</param>
        /// <param name="Y">The Y coordinate for the starting position.</param>
        public ChessPiece(char symbol, int X, int Y)
        {
            this.Symbol = symbol;
            this.Coordinates = new Coordinates(X, Y);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The char symbol, representing this chess piece (i.e. what you see on the screen).
        /// </summary>
        public char Symbol { get; private set; }

        /// <summary>
        /// The current coordinates for this chess piece.
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// The current X coordinate.
        /// </summary>
        public int XCoord
        {
            get
            {
                return this.Coordinates.XCoord;
            }
            set
            {
                this.Coordinates.XCoord = value;
            }
        }

        /// <summary>
        /// The current Y coordinate.
        /// </summary>
        public int YCoord
        {
            get
            {
                return this.Coordinates.YCoord;
            }
            set
            {
                this.Coordinates.YCoord = value;
            }
        }

        #endregion
    }
}