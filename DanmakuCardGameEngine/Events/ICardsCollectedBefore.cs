using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardsCollectedBefore: IBaseEvent<CardsCollectedBeforeEventArgs> { void OnCardsCollectedBefore(object? sender, CardsCollectedBeforeEventArgs args); void IBaseEvent<CardsCollectedBeforeEventArgs>.HandleEvent(object? sender, CardsCollectedBeforeEventArgs args) { OnCardsCollectedBefore(sender, args); } }