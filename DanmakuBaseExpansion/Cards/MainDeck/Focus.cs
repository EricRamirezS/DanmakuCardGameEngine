using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public class Focus : BaseMainCard {
        public Focus(string id, ISeason season) : base(
            id, 
            "Focus", 
            season,
            3) { }
    }
}