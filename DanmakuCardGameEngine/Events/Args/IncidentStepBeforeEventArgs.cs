namespace DanmakuCG_Data.Models.Events.Args;

public class IncidentStepBeforeEventArgs : IncidentStepAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}