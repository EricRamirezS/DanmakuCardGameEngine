using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an action or card is cancelled.
    /// </summary>
    public sealed class CancelEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the card that was cancelled.
        /// </summary>
        public ICard cancelledCard { get; }
        /// <summary>
        /// Gets the card that caused the cancellation.
        /// </summary>
        public ICard cancellingCard { get; }
        /// <summary>
        /// Gets the read-only player who performed the cancelling action.
        /// </summary>
        public IReadOnlyPlayer cancelingPlayer { get; }
        /// <summary>
        /// Gets the read-only player whose card or effect was cancelled.
        /// </summary>
        public IReadOnlyPlayer canceledPlayer { get; }
    }
}