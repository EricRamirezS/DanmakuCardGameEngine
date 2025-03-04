using System;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Player;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DanmakuCardGameEngine.Events.Args {
    public abstract class BaseEventArgs : EventArgs {
        public IReadOnlyGameState GameState;
        public IReadOnlyPlayer CurrentPlayer => GameState.PlayerInTurn;
    }
}