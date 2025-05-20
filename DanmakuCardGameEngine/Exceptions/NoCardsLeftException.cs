using System;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Exceptions {
    public class NoCardsLeftException<TClass> : Exception where TClass : ICard {
        public NoCardsLeftException(Deck<TClass> deck) : base(
            $"There are no cards left in the Deck: {deck} of {typeof(TClass).Name}") { }
    }
}