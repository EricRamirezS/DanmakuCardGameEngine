using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncidentResolvedAfter: IBaseEvent<IncidentResolvedAfterEventArgs> { void OnIncidentResolvedAfter(object? sender, IncidentResolvedAfterEventArgs args); void IBaseEvent<IncidentResolvedAfterEventArgs>.HandleEvent(object? sender, IncidentResolvedAfterEventArgs args) { OnIncidentResolvedAfter(sender, args); } }