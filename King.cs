class King : ChessPiece
{
    public King(Coordinates coords)
        : base('K', coords)
    {
    }

    public King(int X, int Y)
        : base('K', X, Y)
    {
    }
}