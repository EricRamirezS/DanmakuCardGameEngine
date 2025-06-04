using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player dodges an attack.
    /// </summary>
    public sealed class DodgeEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who dodged the attack.
        /// </summary>
        public IReadOnlyPlayer Attacker { get; }
    }
}