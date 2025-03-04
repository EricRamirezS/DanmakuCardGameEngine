using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncreasedHealthBefore: IBaseEvent<IncreasedHealthBeforeEventArgs> { void OnIncreasedHealthBefore(object? sender, IncreasedHealthBeforeEventArgs args); void IBaseEvent<IncreasedHealthBeforeEventArgs>.HandleEvent(object? sender, IncreasedHealthBeforeEventArgs args) { OnIncreasedHealthBefore(sender, args); } }