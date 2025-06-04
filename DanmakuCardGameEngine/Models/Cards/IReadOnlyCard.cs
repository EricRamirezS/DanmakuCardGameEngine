using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Defines a read-only interface for a card, providing access to its essential properties
    /// without allowing modification. This representation is typically used when a card's full details
    /// are not accessible, such as when it's face down in a deck or in a public zone where only
    /// basic information (like its type from the card back) is known.
    /// </summary>
    /// <remarks>
    /// Unless a card is in a player's hand, discard pile, or otherwise explicitly revealed,
    /// its <see cref="CardType"/> is often the only identifiable characteristic due to distinct card back designs.
    /// </remarks>
    public interface IReadOnlyCard: IEquatable<ICard> {
        /// <summary>
        /// Gets the type of the card. This property is usually visible even when the card's
        /// full details are not, as different card types have distinct back designs.
        /// </summary>
        ICardType CardType { get; }
    }
}