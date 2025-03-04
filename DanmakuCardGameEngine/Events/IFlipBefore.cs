using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IFlipBefore: IBaseEvent<FlipBeforeEventArgs> { void OnFlipBefore(object? sender, FlipBeforeEventArgs args); void IBaseEvent<FlipBeforeEventArgs>.HandleEvent(object? sender, FlipBeforeEventArgs args) { OnFlipBefore(sender, args); } }