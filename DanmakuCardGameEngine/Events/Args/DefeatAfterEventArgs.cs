using DanmakuCG_Data.Models.PlayerController;

namespace DanmakuCG_Data.Models.Events.Args;

public class DefeatAfterEventArgs : BaseEventArgs {
    public Player DefeatedPlayer;
}