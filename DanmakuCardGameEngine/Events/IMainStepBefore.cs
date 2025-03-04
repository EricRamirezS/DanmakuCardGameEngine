using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IMainStepBefore: IBaseEvent<MainStepBeforeEventArgs> { void OnMainStepBefore(object? sender, MainStepBeforeEventArgs args); void IBaseEvent<MainStepBeforeEventArgs>.HandleEvent(object? sender, MainStepBeforeEventArgs args) { OnMainStepBefore(sender, args); } }