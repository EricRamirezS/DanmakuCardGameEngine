using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface INewIncidentBefore: IBaseEvent<NewIncidentBeforeEventArgs> { void OnNewIncidentBefore(object? sender, NewIncidentBeforeEventArgs args); void IBaseEvent<NewIncidentBeforeEventArgs>.HandleEvent(object? sender, NewIncidentBeforeEventArgs args) { OnNewIncidentBefore(sender, args); } }