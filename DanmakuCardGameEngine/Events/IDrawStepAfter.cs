using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDrawStepAfter: IBaseEvent<DrawStepAfterEventArgs> { void OnDrawStepAfter(object? sender, DrawStepAfterEventArgs args); void IBaseEvent<DrawStepAfterEventArgs>.HandleEvent(object? sender, DrawStepAfterEventArgs args) { OnDrawStepAfter(sender, args); } }