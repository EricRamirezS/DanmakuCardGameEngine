using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IHandSwappedBefore: IBaseEvent<HandSwappedBeforeEventArgs> { void OnHandSwappedBefore(object? sender, HandSwappedBeforeEventArgs args); void IBaseEvent<HandSwappedBeforeEventArgs>.HandleEvent(object? sender, HandSwappedBeforeEventArgs args) { OnHandSwappedBefore(sender, args); } }