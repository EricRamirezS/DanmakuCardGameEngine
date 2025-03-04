using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IMobAttackStepAfter: IBaseEvent<MobAttackStepAfterEventArgs> { void OnMobAttackStepAfter(object? sender, MobAttackStepAfterEventArgs args); void IBaseEvent<MobAttackStepAfterEventArgs>.HandleEvent(object? sender, MobAttackStepAfterEventArgs args) { OnMobAttackStepAfter(sender, args); } }