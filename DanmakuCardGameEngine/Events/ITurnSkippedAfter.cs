using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ITurnSkippedAfter: IBaseEvent<TurnSkippedAfterEventArgs> { void OnTurnSkippedAfter(object? sender, TurnSkippedAfterEventArgs args); void IBaseEvent<TurnSkippedAfterEventArgs>.HandleEvent(object? sender, TurnSkippedAfterEventArgs args) { OnTurnSkippedAfter(sender, args); } }