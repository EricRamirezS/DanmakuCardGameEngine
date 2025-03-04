using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IItemDiscardedBefore: IBaseEvent<ItemDiscardedBeforeEventArgs> { void OnItemDiscardedBefore(object? sender, ItemDiscardedBeforeEventArgs args); void IBaseEvent<ItemDiscardedBeforeEventArgs>.HandleEvent(object? sender, ItemDiscardedBeforeEventArgs args) { OnItemDiscardedBefore(sender, args); } }