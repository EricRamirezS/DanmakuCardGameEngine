using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ISpellCardCancelledBefore: IBaseEvent<SpellCardCancelledBeforeEventArgs> { void OnSpellCardCancelledBefore(object? sender, SpellCardCancelledBeforeEventArgs args); void IBaseEvent<SpellCardCancelledBeforeEventArgs>.HandleEvent(object? sender, SpellCardCancelledBeforeEventArgs args) { OnSpellCardCancelledBefore(sender, args); } }