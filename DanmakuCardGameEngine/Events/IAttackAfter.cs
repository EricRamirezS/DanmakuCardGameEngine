using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IAttackAfter: IBaseEvent<AttackAfterEventArgs> { void OnAttackAfter(object? sender, AttackAfterEventArgs args); void IBaseEvent<AttackAfterEventArgs>.HandleEvent(object? sender, AttackAfterEventArgs args) { OnAttackAfter(sender, args); } }