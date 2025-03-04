using System;
using System.Collections;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class Deck<TCard> : List<TCard>, IDeck<TCard> where TCard : ICard {
        
        public override string ToString() {
            return "Deck of " + typeof(TCard);
        }
    }
}