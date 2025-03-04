using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IMobAttackStepBefore: IBaseEvent<MobAttackStepBeforeEventArgs> { void OnMobAttackStepBefore(object? sender, MobAttackStepBeforeEventArgs args); void IBaseEvent<MobAttackStepBeforeEventArgs>.HandleEvent(object? sender, MobAttackStepBeforeEventArgs args) { OnMobAttackStepBefore(sender, args); } }