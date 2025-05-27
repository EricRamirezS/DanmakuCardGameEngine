using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {

    /// <summary>
    /// Represents a discard pile that can hold a specific type of cards.
    /// It combines the functionalities of a general discard pile and a list of cards,
    /// allowing for type-safe operations on the discarded cards.
    /// </summary>
    /// <typeparam name="TCard">The specific type of <see cref="ICard"/> that this discard pile contains.</typeparam>
    public interface IDiscard<TCard> : IDiscard, IList<TCard> where TCard : ICard { }

    /// <summary>
    /// Represents a general discard pile, providing basic enumeration capabilities.
    /// This interface serves as a non-generic base for discard piles, allowing for
    /// common operations across different card types.
    /// </summary>
    public interface IDiscard : System.Collections.IEnumerable { }
}   