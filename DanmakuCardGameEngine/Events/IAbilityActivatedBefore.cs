using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IAbilityActivatedBefore: IBaseEvent<AbilityActivatedBeforeEventArgs> { void OnAbilityActivatedBefore(object? sender, AbilityActivatedBeforeEventArgs args); void IBaseEvent<AbilityActivatedBeforeEventArgs>.HandleEvent(object? sender, AbilityActivatedBeforeEventArgs args) { OnAbilityActivatedBefore(sender, args); } }