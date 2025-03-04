using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEmptyHandBefore: IBaseEvent<EmptyHandBeforeEventArgs> { void OnEmptyHandBefore(object? sender, EmptyHandBeforeEventArgs args); void IBaseEvent<EmptyHandBeforeEventArgs>.HandleEvent(object? sender, EmptyHandBeforeEventArgs args) { OnEmptyHandBefore(sender, args); } }