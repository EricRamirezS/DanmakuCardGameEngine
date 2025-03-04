using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards.Timing {
    public interface IAltMode : IMode {
        IReadOnlyList<ICardSubtypes> AltCardTypes { get; }

        void PlayAltMode();
        bool CanPlayAltMode();
    }
}