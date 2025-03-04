using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IEmptyHandAfter: IBaseEvent<EmptyHandAfterEventArgs> { void OnEmptyHandAfter(object? sender, EmptyHandAfterEventArgs args); void IBaseEvent<EmptyHandAfterEventArgs>.HandleEvent(object? sender, EmptyHandAfterEventArgs args) { OnEmptyHandAfter(sender, args); } }