using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Provides a concrete implementation of a generic discard pile.
    /// This class extends <see cref="List{T}"/> and implements <see cref="IDiscard{TCard}"/>,
    /// managing a collection of discarded cards of a specific type.
    /// </summary>
    /// <typeparam name="TCard">The type of cards in the discard pile, constrained to implement <see cref="ICard"/>.</typeparam>
    public class Discard<TCard> : List<TCard>, IDiscard<TCard> where TCard : ICard {
    }
}