using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IHandRevealedBefore: IBaseEvent<HandRevealedBeforeEventArgs> { void OnHandRevealedBefore(object? sender, HandRevealedBeforeEventArgs args); void IBaseEvent<HandRevealedBeforeEventArgs>.HandleEvent(object? sender, HandRevealedBeforeEventArgs args) { OnHandRevealedBefore(sender, args); } }