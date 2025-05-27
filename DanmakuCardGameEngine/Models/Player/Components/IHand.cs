using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Defines an interface for a player's hand of cards, which behaves like a list of <see cref="IHandCard"/> objects
    /// and can be converted to a read-only representation (<see cref="IReadOnlyHand"/>).
    /// </summary>
    public interface IHand : IList<IHandCard>, IReadOnlyConverter<IReadOnlyHand> {
        /// <summary>
        /// Gets the maximum number of cards that can be held in this hand.
        /// </summary>
        int MaxHandSize { get; }
        /// <summary>
        /// Gets the total number of cards currently in the hand.
        /// </summary>
        /// <returns>The count of cards in the hand.</returns>
        int CardCount();
        /// <summary>
        /// Gets the number of cards of a specific type (<typeparamref name="T"/>) currently in the hand.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IHandCard"/> to count.</typeparam>
        /// <returns>The count of cards of type <typeparamref name="T"/> in the hand.</returns>
        int CardCount<T>() where T : IHandCard;

        /// <summary>
        /// Adds a collection of <see cref="IHandCard"/> objects to the hand.
        /// </summary>
        /// <param name="collection">The collection of cards to add.</param>
        void AddRange(IEnumerable<IHandCard> collection);
    }
}