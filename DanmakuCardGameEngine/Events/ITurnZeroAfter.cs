using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ITurnZeroAfter: IBaseEvent<TurnZeroAfterEventArgs> { void OnTurnZeroAfter(object? sender, TurnZeroAfterEventArgs args); void IBaseEvent<TurnZeroAfterEventArgs>.HandleEvent(object? sender, TurnZeroAfterEventArgs args) { OnTurnZeroAfter(sender, args); } }