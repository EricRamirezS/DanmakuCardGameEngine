using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IDodgeAfter: IBaseEvent<DodgeAfterEventArgs> { void OnDodgeAfter(object? sender, DodgeAfterEventArgs args); void IBaseEvent<DodgeAfterEventArgs>.HandleEvent(object? sender, DodgeAfterEventArgs args) { OnDodgeAfter(sender, args); } }