public class Coordinates
{
    int xCoord;
    int yCoord;

    public Coordinates()
    {
        this.xCoord = 0;
        this.yCoord = 0;
    }

    public Coordinates(int x, int y)
    {
        this.xCoord = x;
        this.yCoord = y;
    }

    public int X
    {
        get 
        { 
            return xCoord; 
        }
        set 
        { 
            xCoord = value; 
        }
    }

    public int Y
    {
        get 
        { 
            return yCoord; 
        }
        set 
        { 
            yCoord = value; 
        }
    }

    public override bool Equals(object obj)
    {
        Coordinates objAsMatrixCoords = obj as Coordinates;

        if (obj == null)
        {
            return false;
        }

        return (this.X == objAsMatrixCoords.X) && 
               (this.Y == objAsMatrixCoords.Y);
    }

    public static bool operator ==(Coordinates first, Coordinates second)
    {
        return first.Equals(second);
    }

    public static bool operator !=(Coordinates first, Coordinates second)
    {
        return !first.Equals(second);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}