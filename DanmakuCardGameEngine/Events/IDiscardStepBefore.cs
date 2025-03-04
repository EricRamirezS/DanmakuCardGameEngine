using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDiscardStepBefore: IBaseEvent<DiscardStepBeforeEventArgs> { void OnDiscardStepBefore(object? sender, DiscardStepBeforeEventArgs args); void IBaseEvent<DiscardStepBeforeEventArgs>.HandleEvent(object? sender, DiscardStepBeforeEventArgs args) { OnDiscardStepBefore(sender, args); } }