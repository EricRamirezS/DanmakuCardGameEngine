using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player's hand is empty.
    /// </summary>
    public sealed class EmptyHandEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose hand is empty.
        /// </summary>
        public IReadOnlyPlayer EmptyHandedPlayer { get; }
    }
}