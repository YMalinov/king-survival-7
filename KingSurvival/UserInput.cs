using System;

namespace KingSurvival
{
    public static class UserInput
    {
        public static string GetInput(Player player)
        {
            switch (player)
            {
                case Player.King:
                    {
                        writeInputFromKing();
                        break;
                    }
                case Player.Pawn:
                    {
                        writeInputFromPawn();
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid player!");
                    }
            }

            string input = Console.ReadLine();
            return input.ToUpper();
        }

        private static void writeInputFromPawn()
        {
            Console.Write("Pawns' turn: ");
        }

        private static void writeInputFromKing()
        {
            Console.Write("King's turn: ");
        }
    }
}