using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStackResolvedBefore: IBaseEvent<StackResolvedBeforeEventArgs> { void OnStackResolvedBefore(object? sender, StackResolvedBeforeEventArgs args); void IBaseEvent<StackResolvedBeforeEventArgs>.HandleEvent(object? sender, StackResolvedBeforeEventArgs args) { OnStackResolvedBefore(sender, args); } }