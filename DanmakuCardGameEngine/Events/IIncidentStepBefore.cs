using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncidentStepBefore: IBaseEvent<IncidentStepBeforeEventArgs> { void OnIncidentStepBefore(object? sender, IncidentStepBeforeEventArgs args); void IBaseEvent<IncidentStepBeforeEventArgs>.HandleEvent(object? sender, IncidentStepBeforeEventArgs args) { OnIncidentStepBefore(sender, args); } }