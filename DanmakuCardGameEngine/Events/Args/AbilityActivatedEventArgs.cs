using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an ability is activated.
    /// </summary>
    public sealed class AbilityActivatedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only player who is the owner of the activated ability.
        /// </summary>
        public IReadOnlyPlayer EffectOwner { get; }
    }
}