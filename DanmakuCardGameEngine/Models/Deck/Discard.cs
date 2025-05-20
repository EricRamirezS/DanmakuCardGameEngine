using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public class Discard<TCard> : List<TCard>, IDiscard<TCard> where TCard : ICard {
    }
}