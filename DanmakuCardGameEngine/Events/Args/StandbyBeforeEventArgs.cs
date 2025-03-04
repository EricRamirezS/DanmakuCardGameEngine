namespace DanmakuCG_Data.Models.Events.Args;

public class StandbyBeforeEventArgs : StandbyAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}