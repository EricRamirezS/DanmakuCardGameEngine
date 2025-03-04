using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDodgeBefore: IBaseEvent<DodgeBeforeEventArgs> { void OnDodgeBefore(object? sender, DodgeBeforeEventArgs args); void IBaseEvent<DodgeBeforeEventArgs>.HandleEvent(object? sender, DodgeBeforeEventArgs args) { OnDodgeBefore(sender, args); } }