using System;

namespace KingSurvival
{
    class Pawn
    {
        public char Symbol { get; private set; }

        public Coordinates Coordinates { get; set; }

        public Pawn(char symbol, Coordinates startingCoordinates)
        {
            this.Symbol = symbol;
            this.Coordinates = startingCoordinates;
        }
    }
}
