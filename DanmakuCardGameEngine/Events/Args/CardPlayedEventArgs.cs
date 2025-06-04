using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a card is played.
    /// </summary>
    public sealed class CardPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who played the card.
        /// </summary>
        public IReadOnlyPlayer PlayedBy { get; }
        /// <summary>
        /// Gets the card that was played.
        /// </summary>
        public ICard PlayedCard { get; }
    }
}