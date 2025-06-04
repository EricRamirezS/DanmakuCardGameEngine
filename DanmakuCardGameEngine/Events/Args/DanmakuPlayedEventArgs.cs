using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a Danmaku card is played.
    /// </summary>
    public sealed class DanmakuPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Danmaku card that was played.
        /// </summary>
        public ICard PlayedCard { get; }
        /// <summary>
        /// Gets the read-only player who played the Danmaku card.
        /// </summary>
        public IReadOnlyPlayer PlayedBy { get; }
    }
}