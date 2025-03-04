using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface INewIncidentAfter: IBaseEvent<NewIncidentAfterEventArgs> { void OnNewIncidentAfter(object? sender, NewIncidentAfterEventArgs args); void IBaseEvent<NewIncidentAfterEventArgs>.HandleEvent(object? sender, NewIncidentAfterEventArgs args) { OnNewIncidentAfter(sender, args); } }