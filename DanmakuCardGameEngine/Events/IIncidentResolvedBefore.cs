using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncidentResolvedBefore: IBaseEvent<IncidentResolvedBeforeEventArgs> { void OnIncidentResolvedBefore(object? sender, IncidentResolvedBeforeEventArgs args); void IBaseEvent<IncidentResolvedBeforeEventArgs>.HandleEvent(object? sender, IncidentResolvedBeforeEventArgs args) { OnIncidentResolvedBefore(sender, args); } }