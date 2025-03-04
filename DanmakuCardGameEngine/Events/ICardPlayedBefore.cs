using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardPlayedBefore: IBaseEvent<CardPlayedBeforeEventArgs> { void OnCardPlayedBefore(object? sender, CardPlayedBeforeEventArgs args); void IBaseEvent<CardPlayedBeforeEventArgs>.HandleEvent(object? sender, CardPlayedBeforeEventArgs args) { OnCardPlayedBefore(sender, args); } }