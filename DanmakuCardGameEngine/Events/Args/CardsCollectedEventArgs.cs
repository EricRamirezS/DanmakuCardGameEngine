using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when cards are collected (typically after an incident).
    /// </summary>
    public sealed class CardsCollectedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the incident card associated with the collected cards.
        /// </summary>
        public IncidentCard IncidentCard { get; }
        /// <summary>
        /// Gets a list of hand cards that were collected.
        /// </summary>
        public IList<IHandCard> CollectedCards { get; }
    }
}