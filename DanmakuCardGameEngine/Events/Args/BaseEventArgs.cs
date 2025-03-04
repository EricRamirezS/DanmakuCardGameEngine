using DanmakuCG_Data.Game;
using DanmakuCG_Data.Game.ReadOnlyModels;
using DanmakuCG_Data.Models.PlayerController;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DanmakuCG_Data.Models.Events.Args;

public abstract class BaseEventArgs : EventArgs {
    public ReadOnlyGameState GameState;
    public Player ViewingPlayer => GameState.ViewingPlayer;
    public ReadOnlyPlayer CurrentPlayer => GameState.CurrentPlayer;
}