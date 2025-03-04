using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IHandRevealedAfter: IBaseEvent<HandRevealedAfterEventArgs> { void OnHandRevealedAfter(object? sender, HandRevealedAfterEventArgs args); void IBaseEvent<HandRevealedAfterEventArgs>.HandleEvent(object? sender, HandRevealedAfterEventArgs args) { OnHandRevealedAfter(sender, args); } }