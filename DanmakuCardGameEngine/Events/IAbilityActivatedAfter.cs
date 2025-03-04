using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface IAbilityActivatedAfter : IBaseEvent<AbilityActivatedAfterEventArgs> { void OnAbilityActivatedAfter(object? sender, AbilityActivatedAfterEventArgs args); void IBaseEvent<AbilityActivatedAfterEventArgs>.HandleEvent(object? sender, AbilityActivatedAfterEventArgs args) { OnAbilityActivatedAfter(sender, args); } }