using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a card has been resolved (its effects have been applied).
    /// </summary>
    public sealed class CardResolvedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the card that was resolved.
        /// </summary>
        public ICard ResolvedCard { get; }
    }
}