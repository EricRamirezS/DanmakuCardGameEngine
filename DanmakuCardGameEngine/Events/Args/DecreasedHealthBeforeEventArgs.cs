namespace DanmakuCG_Data.Models.Events.Args;

public class DecreasedHealthBeforeEventArgs : DecreasedHealthAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}