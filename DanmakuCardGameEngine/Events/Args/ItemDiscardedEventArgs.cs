using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an Item card is discarded.
    /// </summary>
    public sealed class ItemDiscardedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only Item card that was discarded.
        /// </summary>
        public IItemCard DiscardedCard { get; }
        /// <summary>
        /// Gets the read-only player who discarded the Item card.
        /// </summary>
        public IReadOnlyPlayer DiscardingPlayer { get; }
    }
}