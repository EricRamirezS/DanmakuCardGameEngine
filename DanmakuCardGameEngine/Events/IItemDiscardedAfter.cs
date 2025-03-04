using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IItemDiscardedAfter: IBaseEvent<ItemDiscardedAfterEventArgs> { void OnItemDiscardedAfter(object? sender, ItemDiscardedAfterEventArgs args); void IBaseEvent<ItemDiscardedAfterEventArgs>.HandleEvent(object? sender, ItemDiscardedAfterEventArgs args) { OnItemDiscardedAfter(sender, args); } }