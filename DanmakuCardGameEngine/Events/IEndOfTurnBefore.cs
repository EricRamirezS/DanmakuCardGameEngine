using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEndOfTurnBefore: IBaseEvent<EndOfTurnBeforeEventArgs> { void OnEndOfTurnBefore(object? sender, EndOfTurnBeforeEventArgs args); void IBaseEvent<EndOfTurnBeforeEventArgs>.HandleEvent(object? sender, EndOfTurnBeforeEventArgs args) { OnEndOfTurnBefore(sender, args); } }