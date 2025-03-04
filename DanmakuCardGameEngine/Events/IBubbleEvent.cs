namespace DanmakuCG_Data.Models.Events;

public interface IBubbleEvent : IEvent {
    bool BubbleEvent { get; set; }
}