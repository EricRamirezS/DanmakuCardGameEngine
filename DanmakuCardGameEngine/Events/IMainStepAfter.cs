using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IMainStepAfter: IBaseEvent<MainStepAfterEventArgs> { void OnMainStepAfter(object? sender, MainStepAfterEventArgs args); void IBaseEvent<MainStepAfterEventArgs>.HandleEvent(object? sender, MainStepAfterEventArgs args) { OnMainStepAfter(sender, args); } }