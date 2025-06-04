using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player's Role card is revealed.
    /// </summary>
    public sealed class RoleRevealedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player whose Role card was revealed.
        /// </summary>
        public IReadOnlyPlayer RevealingPlayer { get; }
        /// <summary>
        /// Gets the read-only Role card that was revealed.
        /// </summary>
        public IRoleCard Revealedole { get; }
    }
}