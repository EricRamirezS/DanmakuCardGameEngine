using System.Collections.Generic;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public abstract class MainCard : HandCard, IMainCard {
        protected MainCard(int id, string name, ISeason season, IExpansion expansion, int pointValue) : base(
            CardTypes.MainCard, id, name, season, expansion, pointValue) { }

        public abstract void PlayMainMode();
        public abstract void PlayAltMode();
        public abstract IReadOnlyList<ICardSubtypes> MainCardTypes { get; }
        public abstract IReadOnlyList<ICardSubtypes> AltCardTypes { get; }

    }
}