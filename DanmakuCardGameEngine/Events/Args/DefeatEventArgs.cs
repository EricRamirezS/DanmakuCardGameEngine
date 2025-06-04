using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a player is defeated.
    /// </summary>
    public sealed class DefeatEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who was defeated.
        /// </summary>
        public IReadOnlyPlayer DefeatPlayer { get; }
    }
}