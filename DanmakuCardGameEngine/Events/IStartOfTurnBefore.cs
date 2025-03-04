using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStartOfTurnBefore: IBaseEvent<StartOfTurnBeforeEventArgs> { void OnStartOfTurnBefore(object? sender, StartOfTurnBeforeEventArgs args); void IBaseEvent<StartOfTurnBeforeEventArgs>.HandleEvent(object? sender, StartOfTurnBeforeEventArgs args) { OnStartOfTurnBefore(sender, args); } }