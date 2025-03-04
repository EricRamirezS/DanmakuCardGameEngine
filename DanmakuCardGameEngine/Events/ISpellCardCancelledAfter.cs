using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ISpellCardCancelledAfter: IBaseEvent<SpellCardCancelledAfterEventArgs> { void OnSpellCardCancelledAfter(object? sender, SpellCardCancelledAfterEventArgs args); void IBaseEvent<SpellCardCancelledAfterEventArgs>.HandleEvent(object? sender, SpellCardCancelledAfterEventArgs args) { OnSpellCardCancelledAfter(sender, args); } }