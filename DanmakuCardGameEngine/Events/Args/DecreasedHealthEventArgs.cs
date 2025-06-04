using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player's health decreases.
    /// </summary>
    public sealed class DecreasedHealthEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the previous health value of the affected player.
        /// </summary>
        public byte PreviousHealth { get; }
        /// <summary>
        /// Gets or sets the new health value of the affected player.
        /// </summary>
        public byte NewHealth { get; set; }
        /// <summary>
        /// Gets the read-only player whose health decreased.
        /// </summary>
        public IReadOnlyPlayer AffectedPlayer { get; }
    }
}