using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICancelAfter: IBaseEvent<CancelAfterEventArgs> { void OnCancelAfter(object? sender, CancelAfterEventArgs args); void IBaseEvent<CancelAfterEventArgs>.HandleEvent(object? sender, CancelAfterEventArgs args) { OnCancelAfter(sender, args); } }