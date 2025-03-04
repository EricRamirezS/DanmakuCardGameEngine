using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEndOfTurnAfter: IBaseEvent<EndOfTurnAfterEventArgs> { void OnEndOfTurnAfter(object? sender, EndOfTurnAfterEventArgs args); void IBaseEvent<EndOfTurnAfterEventArgs>.HandleEvent(object? sender, EndOfTurnAfterEventArgs args) { OnEndOfTurnAfter(sender, args); } }