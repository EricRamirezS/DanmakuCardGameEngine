using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ICancelBefore: IBaseEvent<CancelBeforeEventArgs> { void OnCancelBefore(object? sender, CancelBeforeEventArgs args); void IBaseEvent<CancelBeforeEventArgs>.HandleEvent(object? sender, CancelBeforeEventArgs args) { OnCancelBefore(sender, args); } }