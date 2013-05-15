class ChessPiece
{
    public char Symbol { get; private set; }

    public Coordinates Coordinates { get; set; }

    public int X
    {
        get
        {
            return this.Coordinates.X;
        }
        set
        {
            this.Coordinates.X = value;
        }
    }

    public int Y
    {
        get
        {
            return this.Coordinates.Y;
        }
        set
        {
            this.Coordinates.Y = value;
        }
    }

    public bool InGame { get; set; }

    public ChessPiece(char symbol, Coordinates startingCoordinates)
    {
        this.Symbol = symbol;
        this.Coordinates = startingCoordinates;
        this.InGame = true;
    }

    public ChessPiece(char symbol, int X, int Y)
    {
        this.Symbol = symbol;
        this.Coordinates = new Coordinates(X, Y);
        this.InGame = true;
    }
}