using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines the interface for a manager that handles multiple decks within the game,
    /// providing methods to retrieve, register, and add to decks.
    /// It extends <see cref="IReadOnlyDeckManager"/> to also allow modifications.
    /// </summary>
    public interface IDecksManager : IReadOnlyDeckManager {
        /// <summary>
        /// Retrieves a deck of a specific card type.
        /// </summary>
        /// <typeparam name="TCard">The type of cards in the deck.</typeparam>
        /// <returns>The deck containing cards of type <typeparamref name="TCard"/>.</returns>
        IDeck<TCard> GetDeck<TCard>() where TCard : ICard;
        /// <summary>
        /// Retrieves a specific type of deck that contains a specific card type.
        /// </summary>
        /// <typeparam name="TDeck">The specific type of deck to retrieve (e.g., <see cref="IDeck{TCard}"/>).</typeparam>
        /// <typeparam name="TCard">The type of cards contained within the deck.</typeparam>
        /// <returns>The requested deck instance.</returns>
        TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard;
        /// <summary>
        /// Attempts to retrieve a specific type of deck that contains a specific card type.
        /// </summary>
        /// <typeparam name="TDeck">The specific type of deck to retrieve.</typeparam>
        /// <typeparam name="TCard">The type of cards contained within the deck.</typeparam>
        /// <param name="deck">When this method returns, contains the deck if found; otherwise, the default value for <typeparamref name="TDeck"/>.</param>
        /// <returns><c>true</c> if the deck was found; otherwise, <c>false</c>.</returns>
        bool GetDeck<TDeck, TCard>(out TDeck deck) where TDeck : IDeck<TCard> where TCard : ICard;
        /// <summary>
        /// Registers a deck with the manager, making it accessible for retrieval.
        /// </summary>
        /// <typeparam name="TCard">The type of cards in the deck being registered.</typeparam>
        /// <param name="deck">The deck instance to register.</param>
        void RegisterDeck<TCard>(IDeck<TCard> deck) where TCard : ICard;
        /// <summary>
        /// Adds cards from an existing deck into another deck managed by the manager.
        /// This method's precise behavior depends on the implementation (e.g., merging, appending).
        /// </summary>
        /// <typeparam name="TCard">The type of cards in the deck to add.</typeparam>
        /// <param name="deck">The deck whose contents are to be added.</param>
        void AddToDeck<TCard>(IDeck<TCard> deck) where TCard : ICard;
    }
}