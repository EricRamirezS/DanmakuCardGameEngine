using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDrawBefore: IBaseEvent<DrawBeforeEventArgs> { void OnDrawBefore(object? sender, DrawBeforeEventArgs args); void IBaseEvent<DrawBeforeEventArgs>.HandleEvent(object? sender, DrawBeforeEventArgs args) { OnDrawBefore(sender, args); } }