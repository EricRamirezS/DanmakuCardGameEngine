using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IIncreasedHealthAfter: IBaseEvent<IncreasedHealthAfterEventArgs> { void OnIncreasedHealthAfter(object? sender, IncreasedHealthAfterEventArgs args); void IBaseEvent<IncreasedHealthAfterEventArgs>.HandleEvent(object? sender, IncreasedHealthAfterEventArgs args) { OnIncreasedHealthAfter(sender, args); } }