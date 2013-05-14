namespace KingSurvival
{
    class Coordinates
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
            get { return xCoord; }
            set { xCoord = value; }
        }
        public int Y
        {
            get { return yCoord; }
            set { yCoord = value; }
        }
    }
}