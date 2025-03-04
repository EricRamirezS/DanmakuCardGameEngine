using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDecreasedHealthBefore: IBaseEvent<DecreasedHealthBeforeEventArgs> { void OnDecreasedHealthBefore(object? sender, DecreasedHealthBeforeEventArgs args); void IBaseEvent<DecreasedHealthBeforeEventArgs>.HandleEvent(object? sender, DecreasedHealthBeforeEventArgs args) { OnDecreasedHealthBefore(sender, args); } }