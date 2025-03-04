using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStartOfTurnAfter: IBaseEvent<StartOfTurnAfterEventArgs> { void OnStartOfTurnAfter(object? sender, StartOfTurnAfterEventArgs args); void IBaseEvent<StartOfTurnAfterEventArgs>.HandleEvent(object? sender, StartOfTurnAfterEventArgs args) { OnStartOfTurnAfter(sender, args); } }