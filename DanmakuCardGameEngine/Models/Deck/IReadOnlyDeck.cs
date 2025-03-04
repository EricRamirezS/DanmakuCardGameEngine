using System;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IReadOnlyDeck<TCard> where TCard : ICard {
        int Count { get; }
    }
}