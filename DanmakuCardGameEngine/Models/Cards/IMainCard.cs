using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IMainCard : IHandCard {
        void PlayMainMode();
        void PlayAltMode();
        IReadOnlyList<ICardSubtypes> MainCardTypes { get; }
        IReadOnlyList<ICardSubtypes> AltCardTypes { get; }
    }
}