using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Represents a concrete implementation of an Incident Card in the Danmaku Card Game Engine.
    /// Incident cards are special cards that introduce events or situations affecting the game state,
    /// often leading to unique challenges or rule modifications.
    /// </summary>
    public class IncidentCard : Card, IIncidentCard {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncidentCard"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the incident card.</param>
        /// <param name="name">The display name of the incident card.</param>
        /// <param name="season">The season associated with the incident card.</param>
        /// <param name="expansion">The expansion set to which the incident card belongs.</param>
        protected IncidentCard(int id, string name, ISeason season, IExpansion expansion) : base(CardTypes.IncidentCard, id, name, season, expansion) { }
    }
}