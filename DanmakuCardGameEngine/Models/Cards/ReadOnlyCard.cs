using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    /// <summary>
    /// Provides a read-only implementation of a card, exposing only its essential properties
    /// without allowing direct modification. This class is designed to wrap an <see cref="ICard"/>
    /// instance, providing a safe view of its basic information.
    /// </summary>
    public class ReadOnlyCard : IReadOnlyCard {
        /// <inheritdoc />
        public ICardType CardType { get; }

        /// <summary>
        /// The underlying mutable <see cref="ICard"/> instance that this read-only card wraps.
        /// </summary>
        private readonly ICard _card;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyCard"/> class from an existing mutable card.
        /// </summary>
        /// <param name="card">The <see cref="ICard"/> instance to create a read-only view from.</param>
        public ReadOnlyCard(ICard card) {
            CardType = card.CardType;
            _card = card;
        }
#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
        /// <inheritdoc />
        /// <remarks>
        /// This implementation checks for equality with an <see cref="ICard"/> instance
        /// by deferring the comparison to the underlying mutable card's <see cref="ICard.Equals(ICard)"/> method.
        /// </remarks>
        public bool Equals(ICard other) {
            // Ensure both the internal mutable card and the 'other' card are not null before comparing.
            // The comparison is delegated to the underlying ICard's Equals method.
            return _card != null && other != null && other.Equals(_card);
        }
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    }
}