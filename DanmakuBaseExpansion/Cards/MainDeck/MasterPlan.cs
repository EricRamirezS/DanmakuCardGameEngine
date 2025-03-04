using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    [Serializable]
    public class LastWord : BaseMainCard {
        public LastWord(string id, ISeason season) : base(id,
            "Last Word",
            season,
            3) { }
    }
}