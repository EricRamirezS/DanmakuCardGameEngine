using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ISpellCardActivatedAfter: IBaseEvent<SpellCardActivatedAfterEventArgs> { void OnSpellCardActivatedAfter(object? sender, SpellCardActivatedAfterEventArgs args); void IBaseEvent<SpellCardActivatedAfterEventArgs>.HandleEvent(object? sender, SpellCardActivatedAfterEventArgs args) { OnSpellCardActivatedAfter(sender, args); } }