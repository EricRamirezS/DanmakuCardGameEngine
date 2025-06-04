using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when a new Incident card is revealed.
    /// </summary>
    public sealed class NewIncidentEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the new Incident card that entered play.
        /// </summary>
        public IIncidentCard IncidentCard { get; }
    }
}