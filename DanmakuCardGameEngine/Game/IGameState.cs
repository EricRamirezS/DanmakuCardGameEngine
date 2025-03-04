using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    public interface IGameState: IReadOnlyGameState{
        IList<IPlayer> Players { get; set; }
        DecksManager DecksManager { get; set; }
        IState State { get; set; }

    }
}