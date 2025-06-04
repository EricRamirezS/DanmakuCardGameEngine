using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a Spell Card is cancelled.
    /// </summary>
    public sealed class SpellCardCancelledEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Character Card whose Spell Card was cancelled.
        /// </summary>
        public ICharacterCard Card { get; }
        /// <summary>
        /// Gets the read-only player who was activating the Spell Card.
        /// </summary>
        public IReadOnlyPlayer ActivatingPlayer { get; }
        /// <summary>
        /// Gets the read-only player who cancelled the Spell Card.
        /// </summary>
        public IReadOnlyPlayer CancellingPlayer { get; }
    }
}