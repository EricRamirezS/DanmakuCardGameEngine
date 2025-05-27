using DanmakuCardGameEngine.Models.Cards;


namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Provides a read-only implementation of a player's hand, allowing access to hand information
    /// without exposing mutable operations. This class is designed to work with an underlying
    /// <see cref="IHand"/> instance.
    /// </summary>
    public class ReadOnlyHand : IReadOnlyHand {
        private readonly IHand _cards;

        /// <inheritdoc />
        public int Count => _cards.Count;

        /// <inheritdoc />
        public int MaxHandSize { get; }

        /// <inheritdoc />
        public int CardCount() => _cards.CardCount();

        /// <inheritdoc />
        public int CardCount<T>() where T : IHandCard => _cards.CardCount<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyHand"/> class from an existing mutable hand.
        /// </summary>
        /// <param name="hand">The <see cref="IHand"/> instance to create a read-only view from.</param>
        internal ReadOnlyHand(IHand hand) {
            _cards = hand;
            MaxHandSize = hand.MaxHandSize;
        }
    }
}