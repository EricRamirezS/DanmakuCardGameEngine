using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ITurnSkippedBefore: IBaseEvent<TurnSkippedBeforeEventArgs> { void OnTurnSkippedBefore(object? sender, TurnSkippedBeforeEventArgs args); void IBaseEvent<TurnSkippedBeforeEventArgs>.HandleEvent(object? sender, TurnSkippedBeforeEventArgs args) { OnTurnSkippedBefore(sender, args); } }