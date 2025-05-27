using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player.Components {
    /// <summary>
    /// Defines a read-only interface for a player's hand, providing access to its size and card counting functionalities.
    /// This interface is used to expose hand information without allowing direct modification of the hand's contents.
    /// </summary>
    public interface IReadOnlyHand {
        /// <summary>
        /// Gets the current number of cards in the hand.
        /// </summary>
        int Count { get; }

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
    }
}