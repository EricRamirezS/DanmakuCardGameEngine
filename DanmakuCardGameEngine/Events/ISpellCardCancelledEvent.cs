using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ISpellCardCancelledEventBefore"/> and <see cref="ISpellCardCancelledEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="SpellCardCancelledEvent"/>.
    /// </summary>
    public interface ISpellCardCancelledEvent : ISpellCardCancelledEventBefore, ISpellCardCancelledEventAfter { }
}