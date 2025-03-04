using DanmakuCG_Data.Game;

namespace DanmakuCG_Data.Models.Events.Args;

public class DrawStepAfterEventArgs : BaseEventArgs {
    public int CardsToDraw = IDefaultData.CardDraw;
}