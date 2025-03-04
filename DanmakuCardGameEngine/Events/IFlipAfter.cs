using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IFlipAfter: IBaseEvent<FlipAfterEventArgs> { void OnFlipAfter(object? sender, FlipAfterEventArgs args); void IBaseEvent<FlipAfterEventArgs>.HandleEvent(object? sender, FlipAfterEventArgs args) { OnFlipAfter(sender, args); } }