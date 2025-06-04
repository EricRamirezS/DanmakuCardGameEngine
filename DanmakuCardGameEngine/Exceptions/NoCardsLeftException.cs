using System;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when there are no cards left in a specific deck.
    /// </summary>
    /// <typeparam name="TClass">The type of card in the deck, constrained to implement <see cref="ICard"/>.</typeparam>
    public class NoCardsLeftException<TClass> : Exception where TClass : ICard {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoCardsLeftException{TClass}"/> class with a specified error message.
        /// </summary>
        /// <param name="deck">The deck that has no cards left.</param>
        public NoCardsLeftException(Deck<TClass> deck) : base(
            $"There are no cards left in the Deck: {deck} of {typeof(TClass).Name}") { }
    }
}