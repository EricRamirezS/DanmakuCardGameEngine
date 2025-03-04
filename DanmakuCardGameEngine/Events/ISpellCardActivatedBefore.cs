using DanmakuCG_Data.Models.Events.Args;

namespace DanmakuCG_Data.Models.Events;

public interface ISpellCardActivatedBefore: IBaseEvent<SpellCardActivatedBeforeEventArgs> { void OnSpellCardActivatedBefore(object? sender, SpellCardActivatedBeforeEventArgs args); void IBaseEvent<SpellCardActivatedBeforeEventArgs>.HandleEvent(object? sender, SpellCardActivatedBeforeEventArgs args) { OnSpellCardActivatedBefore(sender, args); } }