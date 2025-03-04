using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDrawAfter: IBaseEvent<DrawAfterEventArgs> { void OnDrawAfter(object? sender, DrawAfterEventArgs args); void IBaseEvent<DrawAfterEventArgs>.HandleEvent(object? sender, DrawAfterEventArgs args) { OnDrawAfter(sender, args); } }