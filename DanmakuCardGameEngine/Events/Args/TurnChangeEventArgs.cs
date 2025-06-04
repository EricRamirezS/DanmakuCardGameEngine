namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when the turn number changes.
    /// </summary>
    public sealed class TurnChangeEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="TurnChangeEventArgs"/> class.
        /// </summary>
        /// <param name="previousTurn">The previous turn number.</param>
        /// <param name="newTurn">The new turn number.</param>
        public TurnChangeEventArgs(int previousTurn, int newTurn) {
            PreviousTurn = previousTurn;
            NewTurn = newTurn;
        }
        /// <summary>
        /// Gets the previous turn number.
        /// </summary>
        public int PreviousTurn { get; }
        /// <summary>
        /// Gets the new turn number.
        /// </summary>
        public int NewTurn { get; }
    }
}