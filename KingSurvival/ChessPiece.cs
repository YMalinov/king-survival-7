namespace KingSurvival
{
    public class ChessPiece
    {
        public char Symbol { get; private set; }

        public Coordinates Coordinates { get; set; }

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

        public ChessPiece(char symbol, Coordinates startingCoordinates)
        {
            this.Symbol = symbol;
            this.Coordinates = startingCoordinates;
        }

        public ChessPiece(char symbol, int X, int Y)
        {
            this.Symbol = symbol;
            this.Coordinates = new Coordinates(X, Y);
        }
    }
}