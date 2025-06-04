using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player's turn is skipped.
    /// </summary>
    public sealed class TurnSkippedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose turn was skipped.
        /// </summary>
        public IReadOnlyPlayer SkippingPlayer;
    }
}