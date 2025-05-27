using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines the interface for a manager that provides read-only access to various decks within the game.
    /// </summary>
    public interface IReadOnlyDeckManager {
        /// <summary>
        /// Retrieves a read-only view of a deck based on its card type.
        /// </summary>
        /// <typeparam name="TCard">The type of cards in the deck.</typeparam>
        /// <returns>A read-only deck containing cards of type <typeparamref name="TCard"/>.</returns>
        IReadOnlyDeck<TCard> GetReadOnlyDeck<TCard>() where TCard : ICard;
        /// <summary>
        /// Checks if a deck containing a specific card type is managed.
        /// </summary>
        /// <typeparam name="TCard">The type of cards in the deck to check for.</typeparam>
        /// <returns><c>true</c> if a deck of the specified card type exists; otherwise, <c>false</c>.</returns>
        bool ContainsDeck<TCard>() where TCard : ICard;
    }
}