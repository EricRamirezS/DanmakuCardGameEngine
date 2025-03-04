using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ITurnZeroBefore: IBaseEvent<TurnZeroBeforeEventArgs> { void OnTurnZeroBefore(object? sender, TurnZeroBeforeEventArgs args); void IBaseEvent<TurnZeroBeforeEventArgs>.HandleEvent(object? sender, TurnZeroBeforeEventArgs args) { OnTurnZeroBefore(sender, args); } }