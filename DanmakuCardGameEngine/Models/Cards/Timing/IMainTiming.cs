using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards.Timing {
    /// <summary>
    /// Defines an interface for cards that can be played from hand.
    /// Most cards are designed to be used in this mode.
    /// </summary>
    /// <remarks>
    /// For "Split cards" (cards with two distinct text usages), <see cref="IMainTiming"/>
    /// refers specifically to the first set of rules or effects. Split cards are also expected
    /// to implement <see cref="IAltTiming"/> for their secondary text and usage.
    /// </remarks>
    public interface IMainTiming : ITiming {
        /// <summary>
        /// Gets a read-only list of card subtypes that are typically associated with cards playable in Main Mode.
        /// </summary>
        IReadOnlyList<ICardSubtypes> MainCardTypes { get; }

        /// <summary>
        /// Initiates the action of playing the card in Main Mode.
        /// This method encapsulates the effects and processes that occur when the card is played.
        /// </summary>
        void PlayMainMode();
        /// <summary>
        /// Determines whether the card can currently be played in Main Mode.
        /// This method checks all conditions necessary for a valid Main Mode play.
        /// </summary>
        /// <returns><c>true</c> if the card can be played in Main Mode; otherwise, <c>false</c>.</returns>
        bool CanPlayMainMode();
    }
}