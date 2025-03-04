using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IHandSwappedAfter: IBaseEvent<HandSwappedAfterEventArgs> { void OnHandSwappedAfter(object? sender, HandSwappedAfterEventArgs args); void IBaseEvent<HandSwappedAfterEventArgs>.HandleEvent(object? sender, HandSwappedAfterEventArgs args) { OnHandSwappedAfter(sender, args); } }