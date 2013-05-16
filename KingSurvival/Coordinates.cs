namespace KingSurvival
{
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

        public int XCoord
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

        public int YCoord
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

            return (this.XCoord == objAsMatrixCoords.XCoord) &&
                   (this.YCoord == objAsMatrixCoords.YCoord);
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
}