using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardPlayedAfter: IBaseEvent<CardPlayedAfterEventArgs> { void OnCardPlayedAfter(object? sender, CardPlayedAfterEventArgs args); void IBaseEvent<CardPlayedAfterEventArgs>.HandleEvent(object? sender, CardPlayedAfterEventArgs args) { OnCardPlayedAfter(sender, args); } }