namespace KingSurvival
{
    /// <summary>
    /// Contains every possible message, which can be written on the console.
    /// </summary>
    public enum Message
    {
        /// <summary>
        /// Will print on the console:
        ///     King wins in X moves.
        /// </summary>
        KingWin,

        /// <summary>
        /// Will print on the console:
        ///     King loses.
        /// </summary>
        KingLose,

        /// <summary>
        /// Will print on the console:
        ///     Illegal move!
        /// </summary>
        InvalidMove
    }
}