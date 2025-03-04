using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards.Timing {
    public interface IAltMode : IMode {
        IList<CardType> AltCardTypes { get; }
    }
}