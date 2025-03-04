using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards.Timing {
    public interface IMainMode : IMode {
        IReadOnlyList<ICardSubtypes> MainCardTypes { get; }

        void PlayMainMode();
        bool CanPlayMainMode();
    }
}