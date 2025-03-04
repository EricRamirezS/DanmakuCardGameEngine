using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStandbyAfter: IBaseEvent<StandbyAfterEventArgs> { void OnStandbyAfter(object? sender, StandbyAfterEventArgs args); void IBaseEvent<StandbyAfterEventArgs>.HandleEvent(object? sender, StandbyAfterEventArgs args) { OnStandbyAfter(sender, args); } }