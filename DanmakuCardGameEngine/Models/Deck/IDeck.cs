using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines a generic interface for a deck of cards, providing functionalities for drawing,
    /// discarding, shuffling, and managing a collection of a specific type of <see cref="ICard"/>.
    /// It extends both <see cref="IDeck"/> for non-generic operations and <see cref="IList{TCard}"/>
    /// for list-like behaviors, and <see cref="IReadOnlyConverter{T}"/> for read-only conversion.
    /// </summary>
    /// <typeparam name="TCard">The specific type of <see cref="ICard"/> that this deck contains.</typeparam>
    // ReSharper disable once PossibleInterfaceMemberAmbiguity
    public interface IDeck<TCard> : IDeck, IReadOnlyConverter<IReadOnlyDeck<TCard>>, IList<TCard>
        where TCard : ICard {
        /// <summary>
        /// Draws a single card of type <typeparamref name="TCard"/> from the top of the deck.
        /// If the deck is empty, it shuffles the discard pile back into the deck before drawing.
        /// </summary>
        /// <returns>The drawn card.</returns>
        new TCard Draw();
        /// <summary>
        /// Gets the discard pile associated with this generic deck.
        /// </summary>
        IDiscard<TCard> Discard { get; }

        /// <summary>
        /// Draws a specified number of cards of type <typeparamref name="TCard"/> from the deck.
        /// </summary>
        /// <param name="numberOfCard">The quantity of cards to draw.</param>
        /// <returns>A list of drawn cards.</returns>
        new IList<TCard> Draw(int numberOfCard);
        /// <summary>
        /// Adds a collection of cards of type <typeparamref name="TCard"/> to the deck.
        /// </summary>
        /// <param name="collection">The collection of cards to add.</param>
        void AddRange(IEnumerable<TCard> collection);
        /// <summary>
        /// Asynchronously adds a single card of type <typeparamref name="TCard"/> to the discard pile.
        /// </summary>
        /// <param name="card">The card to add to the discard pile.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddToDiscard(TCard card);
    }

    /// <summary>
    /// Defines a non-generic interface for a deck of cards, providing basic functionalities
    /// for drawing, discarding, and shuffling. It extends <see cref="IList"/> for non-generic
    /// list-like behaviors and <see cref="IShuffleable"/> for shuffling capabilities.
    /// </summary>
    public interface IDeck: IList, IShuffleable {
        /// <summary>
        /// Draws a single <see cref="ICard"/> from the top of the deck.
        /// If the deck is empty, it shuffles the discard pile back into the deck before drawing.
        /// </summary>
        /// <returns>The drawn card.</returns>
        ICard Draw();
        /// <summary>
        /// Draws a specified number of <see cref="ICard"/> objects from the deck.
        /// </summary>
        /// <param name="numberOfCards">The quantity of cards to draw.</param>
        /// <returns>A list of drawn cards.</returns>
        IList<ICard> Draw(int numberOfCards);
        /// <summary>
        /// Asynchronously adds a single <see cref="ICard"/> to the discard pile.
        /// </summary>
        /// <param name="card">The card to add to the discard pile.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddToDiscard(ICard card);
        /// <summary>
        /// Gets the discard pile associated with this deck.
        /// </summary>
        /// <returns>The discard pile.</returns>
        IDiscard GetDiscard();
    }
    
    /// <summary>
    /// Defines an interface for objects that can be shuffled.
    /// </summary>
    public interface IShuffleable {
        /// <summary>
        /// Shuffles the elements within the implementing collection.
        /// </summary>
        void Shuffle();
    }
}