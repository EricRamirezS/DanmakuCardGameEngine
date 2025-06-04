using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an attack is initiated.
    /// </summary>
    public sealed class AttackEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who initiated the attack.
        /// </summary>
        public IReadOnlyPlayer Attacker { get; }
        /// <summary>
        /// Gets a value indicating whether the attack is unavoidable.
        /// If <c>true</c>, targets cannot dodge this attack.
        /// </summary>
        public bool Unavoidable { get; }
        /// <summary>
        /// Gets a list of read-only players who are the targets of the attack.
        /// </summary>
        public IList<IReadOnlyPlayer> Targets { get; }
    }
}