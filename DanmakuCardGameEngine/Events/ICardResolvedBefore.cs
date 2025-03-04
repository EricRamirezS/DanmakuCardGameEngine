using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardResolvedBefore: IBaseEvent<CardResolvedBeforeEventArgs> { void OnCardResolvedBefore(object? sender, CardResolvedBeforeEventArgs args); void IBaseEvent<CardResolvedBeforeEventArgs>.HandleEvent(object? sender, CardResolvedBeforeEventArgs args) { OnCardResolvedBefore(sender, args); } }