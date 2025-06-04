using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an Item card is played.
    /// </summary>
    public sealed class ItemPlayedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only Item card that was played.
        /// </summary>
        public IItemCard PlayerItem { get; }
        /// <summary>
        /// Gets the read-only player who played the Item card.
        /// </summary>
        public IReadOnlyPlayer Player { get; }
    }
}