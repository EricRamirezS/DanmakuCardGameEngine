namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when the round number changes.
    /// </summary>
    public sealed class RoundChangeEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoundChangeEventArgs"/> class.
        /// </summary>
        /// <param name="previousRound">The previous round number.</param>
        /// <param name="newRound">The new round number.</param>
        public RoundChangeEventArgs(int previousRound, int newRound) {
            PreviousRound = previousRound;
            NewRound = newRound;
        }
        /// <summary>
        /// Gets the previous round number.
        /// </summary>
        public int PreviousRound { get; }
        /// <summary>
        /// Gets the new round number.
        /// </summary>
        public int NewRound { get; }
    }
}