using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IDiscard<TCard> : IDiscard, IList<TCard> where TCard : ICard { }

    public interface IDiscard : System.Collections.IEnumerable {
    }
}   