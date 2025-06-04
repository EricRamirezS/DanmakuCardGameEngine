using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines an interface for a "Main Card," which is a type of <see cref="IHandCard"/>
    /// that typically has both a primary (Main) and potentially an alternate (Alt) mode of play.
    /// This interface combines the playability aspects of <see cref="IHandCard"/> with
    /// specific methods and properties for managing these two modes.
    /// </summary>
    public interface IMainCard : IHandCard {
        /// <summary>
        /// Initiates the action of playing the card in its Main Mode.
        /// This method encapsulates the effects and processes that occur when the card is played
        /// using its primary functionality.
        /// </summary>
        void PlayMainMode();
        /// <summary>
        /// Initiates the action of playing the card in its Alternate Mode.
        /// This method encapsulates the effects and processes that occur when the card is played
        /// using its secondary functionality (e.g., for Split cards).
        /// </summary>
        void PlayAltMode();

        /// <summary>
        /// Gets a read-only list of card subtypes that are typically associated with the card's Main Mode usage.
        /// </summary>
        IReadOnlyList<ICardSubtypes> MainCardTypes { get; }

        /// <summary>
        /// Gets a read-only list of card subtypes that are typically associated with the card's Alternate Mode usage.
        /// This is particularly relevant for "Split cards" that have distinct functionalities for each mode.
        /// </summary>
        IReadOnlyList<ICardSubtypes> AltCardTypes { get; }
    }
}