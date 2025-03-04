using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEncounterStepAfter: IBaseEvent<EncounterStepAfterEventArgs> { void OnEncounterStepAfter(object? sender, EncounterStepAfterEventArgs args); void IBaseEvent<EncounterStepAfterEventArgs>.HandleEvent(object? sender, EncounterStepAfterEventArgs args) { OnEncounterStepAfter(sender, args); } }