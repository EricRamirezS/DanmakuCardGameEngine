using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IDiscard<TCard> : IList<TCard> where TCard : ICard { }
}