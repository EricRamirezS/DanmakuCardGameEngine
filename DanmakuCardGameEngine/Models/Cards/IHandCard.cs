using DanmakuCardGameEngine.Enums;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines an interface for a card that can be held in a player's hand.
    /// Hand cards have a point value, a card mode (indicating how they can be played),
    /// and methods to check their playability in different contexts.
    /// </summary>
    public interface IHandCard : ICard {
        /// <summary>
        /// Gets the point value of the hand card. This value might be used for scoring,
        /// resource generation, or other game mechanics.
        /// </summary>
        int PointValue { get; }
        /// <summary>
        /// Gets the mode of the card, which determines how it can be played (e.g., Main, Alt).
        /// </summary>
        CardMode CardMode { get; }

        /// <summary>
        /// Determines whether the hand card can currently be played.
        /// This method typically checks general playability conditions, regardless of specific timing modes.
        /// </summary>
        /// <returns><c>true</c> if the card can be played; otherwise, <c>false</c>.</returns>
        bool CanBePlayed();
        /// <summary>
        /// Determines whether the hand card can currently be played in its Main Mode.
        /// This method checks conditions specific to playing the card as its primary effect.
        /// </summary>
        /// <returns><c>true</c> if the card can be played in Main Mode; otherwise, <c>false</c>.</returns>
        bool CanPlayMainMode();
        /// <summary>
        /// Determines whether the hand card can currently be played in its Alternate Mode (if applicable).
        /// This method checks conditions specific to playing the card as its secondary effect (e.g., for Split cards).
        /// </summary>
        /// <returns><c>true</c> if the card can be played in Alternate Mode; otherwise, <c>false</c>.</returns>
        bool CanPlayAltMode();
    }
}