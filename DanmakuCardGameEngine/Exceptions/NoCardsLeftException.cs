using System;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class NoCardsLeftException<TClass> : Exception where TClass : ICard {
        public NoCardsLeftException(Deck<TClass> deck) : base(
            $"There are no cards left in the Deck: {deck} of {typeof(TClass).Name}") { }
    }
}