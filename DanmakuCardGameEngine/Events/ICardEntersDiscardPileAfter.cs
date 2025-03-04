using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardEntersDiscardPileAfter: IBaseEvent<CardEntersDiscardPileAfterEventArgs> { void OnCardEntersDiscardPileAfter(object? sender, CardEntersDiscardPileAfterEventArgs args); void IBaseEvent<CardEntersDiscardPileAfterEventArgs>.HandleEvent(object? sender, CardEntersDiscardPileAfterEventArgs args) { OnCardEntersDiscardPileAfter(sender, args); } }