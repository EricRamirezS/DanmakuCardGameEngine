namespace DanmakuCG_Data.Models.Events.Args;

public class SpellCardActivatedBeforeEventArgs : SpellCardActivatedAfterEventArgs, IBubbleEvent {
    public bool BubbleEvent { get; set; } = true;
}