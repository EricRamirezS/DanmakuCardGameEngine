using System;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public class ReadOnlyCard : IReadOnlyCard {
        public ICardType CardType { get; }
        private ICard _card;
        
        
        public ReadOnlyCard(ICard card) {
            CardType = card.CardType;
        }
        public bool Equals(ICard other) {
            return _card != null && other != null && other.Equals(_card);
        }
    }
}