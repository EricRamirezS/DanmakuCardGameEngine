using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IItemPlayedAfter: IBaseEvent<ItemPlayedAfterEventArgs> { void OnItemPlayedAfter(object? sender, ItemPlayedAfterEventArgs args); void IBaseEvent<ItemPlayedAfterEventArgs>.HandleEvent(object? sender, ItemPlayedAfterEventArgs args) { OnItemPlayedAfter(sender, args); } }