using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICardEntersDiscardPileBefore: IBaseEvent<CardEntersDiscardPileBeforeEventArgs> { void OnCardEntersDiscardPileBefore(object? sender, CardEntersDiscardPileBeforeEventArgs args); void IBaseEvent<CardEntersDiscardPileBeforeEventArgs>.HandleEvent(object? sender, CardEntersDiscardPileBeforeEventArgs args) { OnCardEntersDiscardPileBefore(sender, args); } }