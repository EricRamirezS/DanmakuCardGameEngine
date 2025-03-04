using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IAttackBefore: IBaseEvent<AttackBeforeEventArgs> { void OnAttackBefore(object? sender, AttackBeforeEventArgs args); void IBaseEvent<AttackBeforeEventArgs>.HandleEvent(object? sender, AttackBeforeEventArgs args) { OnAttackBefore(sender, args); } }