using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a Spell Card is activated.
    /// </summary>
    public sealed class SpellCardActivatedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the Character Card associated with the activated Spell Card.
        /// </summary>
        public ICharacterCard Card { get; }
        /// <summary>
        /// Gets the read-only player who activated the Spell Card.
        /// </summary>
        public IReadOnlyPlayer ActivatingPlayer { get; }
    }
}