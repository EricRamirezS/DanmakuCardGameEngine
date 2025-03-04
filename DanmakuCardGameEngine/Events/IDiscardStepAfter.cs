using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDiscardStepAfter: IBaseEvent<DiscardStepAfterEventArgs> { void OnDiscardStepAfter(object? sender, DiscardStepAfterEventArgs args); void IBaseEvent<DiscardStepAfterEventArgs>.HandleEvent(object? sender, DiscardStepAfterEventArgs args) { OnDiscardStepAfter(sender, args); } }