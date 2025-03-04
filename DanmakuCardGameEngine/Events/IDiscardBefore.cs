using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDiscardBefore: IBaseEvent<DiscardBeforeEventArgs> { void OnDiscardBefore(object? sender, DiscardBeforeEventArgs args); void IBaseEvent<DiscardBeforeEventArgs>.HandleEvent(object? sender, DiscardBeforeEventArgs args) { OnDiscardBefore(sender, args); } }