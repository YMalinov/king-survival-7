namespace KingSurvival
{
    class Coordinates
    {
        int x;
        int y;

        public Coordinates()
        {
            this.x = 0;
            this.y = 0;
        }
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}