using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStandbyBefore: IBaseEvent<StandbyBeforeEventArgs> { void OnStandbyBefore(object? sender, StandbyBeforeEventArgs args); void IBaseEvent<StandbyBeforeEventArgs>.HandleEvent(object? sender, StandbyBeforeEventArgs args) { OnStandbyBefore(sender, args); } }