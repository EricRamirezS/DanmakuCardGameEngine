using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDecreasedHealthAfter: IBaseEvent<DecreasedHealthAfterEventArgs> { void OnDecreasedHealthAfter(object? sender, DecreasedHealthAfterEventArgs args); void IBaseEvent<DecreasedHealthAfterEventArgs>.HandleEvent(object? sender, DecreasedHealthAfterEventArgs args) { OnDecreasedHealthAfter(sender, args); } }