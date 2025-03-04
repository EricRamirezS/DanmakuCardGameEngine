using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEncounterStepBefore: IBaseEvent<EncounterStepBeforeEventArgs> { void OnEncounterStepBefore(object? sender, EncounterStepBeforeEventArgs args); void IBaseEvent<EncounterStepBeforeEventArgs>.HandleEvent(object? sender, EncounterStepBeforeEventArgs args) { OnEncounterStepBefore(sender, args); } }