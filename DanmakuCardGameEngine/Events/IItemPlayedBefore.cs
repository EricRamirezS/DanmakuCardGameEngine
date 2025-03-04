using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IItemPlayedBefore: IBaseEvent<ItemPlayedBeforeEventArgs> { void OnItemPlayedBefore(object? sender, ItemPlayedBeforeEventArgs args); void IBaseEvent<ItemPlayedBeforeEventArgs>.HandleEvent(object? sender, ItemPlayedBeforeEventArgs args) { OnItemPlayedBefore(sender, args); } }