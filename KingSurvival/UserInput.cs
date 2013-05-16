using System;

namespace KingSurvival
{
    /// <summary>
    /// A helper class, which gets the user input.
    /// </summary>
    public static class UserInput
    {
        #region Constants

        /// <summary>
        /// What should be written on the console, when it's the king's turn.
        /// </summary>
        private const string InputFromKingMsg = "King's turn: ";

        /// <summary>
        /// What should be written on the console, when it's the pawn's turn.
        /// </summary>
        private const string InputFromPawnMsg = "Pawns' turn: ";

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the input from the player.
        /// </summary>
        /// <param name="player">Which player's turn is it.</param>
        /// <returns>A string with the player input.</returns>
        public static string GetInput(Player player)
        {
            string message = "";
            switch (player)
            {
                case Player.King:
                    {
                        message = InputFromKingMsg;
                        break;
                    }
                case Player.Pawn:
                    {
                        message = InputFromPawnMsg;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid player!");
                    }
            }

            Console.Write(message);
            string input = Console.ReadLine();

            return input.ToUpper();
        }

        #endregion
    }
}