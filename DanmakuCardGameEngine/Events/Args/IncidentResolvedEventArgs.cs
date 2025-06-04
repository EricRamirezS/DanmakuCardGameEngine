using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when an incident has been resolved.
    /// </summary>
    public sealed class IncidentResolvedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the read-only incident card that was resolved.
        /// </summary>
        public IIncidentCard ResolvedIncident { get; }
    }
}