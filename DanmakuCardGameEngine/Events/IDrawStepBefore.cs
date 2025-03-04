using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDrawStepBefore: IBaseEvent<DrawStepBeforeEventArgs> { void OnDrawStepBefore(object? sender, DrawStepBeforeEventArgs args); void IBaseEvent<DrawStepBeforeEventArgs>.HandleEvent(object? sender, DrawStepBeforeEventArgs args) { OnDrawStepBefore(sender, args); } }