using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IStackResolvedAfter: IBaseEvent<StackResolvedAfterEventArgs> { void OnStackResolvedAfter(object? sender, StackResolvedAfterEventArgs args); void IBaseEvent<StackResolvedAfterEventArgs>.HandleEvent(object? sender, StackResolvedAfterEventArgs args) { OnStackResolvedAfter(sender, args); } }