using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDiscardAfter: IBaseEvent<DiscardAfterEventArgs> { void OnDiscardAfter(object? sender, DiscardAfterEventArgs args); void IBaseEvent<DiscardAfterEventArgs>.HandleEvent(object? sender, DiscardAfterEventArgs args) { OnDiscardAfter(sender, args); } }