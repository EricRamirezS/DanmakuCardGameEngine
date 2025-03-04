using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncidentStepAfter: IBaseEvent<IncidentStepAfterEventArgs> { void OnIncidentStepAfter(object? sender, IncidentStepAfterEventArgs args); void IBaseEvent<IncidentStepAfterEventArgs>.HandleEvent(object? sender, IncidentStepAfterEventArgs args) { OnIncidentStepAfter(sender, args); } }