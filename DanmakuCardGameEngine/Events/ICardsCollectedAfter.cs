using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardsCollectedAfter: IBaseEvent<CardsCollectedAfterEventArgs> { void OnCardsCollectedAfter(object? sender, CardsCollectedAfterEventArgs args); void IBaseEvent<CardsCollectedAfterEventArgs>.HandleEvent(object? sender, CardsCollectedAfterEventArgs args) { OnCardsCollectedAfter(sender, args); } }