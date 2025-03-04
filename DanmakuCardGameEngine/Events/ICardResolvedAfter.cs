using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardResolvedAfter: IBaseEvent<CardResolvedAfterEventArgs> { void OnCardResolvedAfter(object? sender, CardResolvedAfterEventArgs args); void IBaseEvent<CardResolvedAfterEventArgs>.HandleEvent(object? sender, CardResolvedAfterEventArgs args) { OnCardResolvedAfter(sender, args); } }