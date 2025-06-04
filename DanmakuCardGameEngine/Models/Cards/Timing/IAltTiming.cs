using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for cards that have an "Alternate Mode" of play, typically
    /// for "Split cards" which offer a secondary set of rules or effects.
    /// </summary>
    /// <remarks>
    /// This interface is specifically for the second text usage of "Split cards."
    /// Cards implementing <see cref="IAltTiming"/> are also expected to implement
    /// <see cref="IMainTiming"/> for their primary text and usage.
    /// </remarks>
    public interface IAltTiming : ITiming {
        /// <summary>
        /// Gets a read-only list of card subtypes that are typically associated with cards playable in Alternate Mode.
        /// </summary>
        IReadOnlyList<ICardSubtypes> AltCardTypes { get; }

        /// <summary>
        /// Initiates the action of playing the card in Alternate Mode.
        /// This method encapsulates the effects and processes that occur when the card is played.
        /// </summary>
        void PlayAltMode();
        /// <summary>
        /// Determines whether the card can currently be played in Alternate Mode.
        /// This method checks all conditions necessary for a valid Alternate Mode play.
        /// </summary>
        /// <returns><c>true</c> if the card can be played in Alternate Mode; otherwise, <c>false</c>.</returns>
        bool CanPlayAltMode();
    }
}