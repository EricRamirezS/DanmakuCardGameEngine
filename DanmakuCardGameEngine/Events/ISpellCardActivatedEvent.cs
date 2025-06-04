using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="ISpellCardActivatedEventBefore"/> and <see cref="ISpellCardActivatedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="SpellCardActivatedEvent"/>.
    /// </summary>
    public interface ISpellCardActivatedEvent : ISpellCardActivatedEventBefore, ISpellCardActivatedEventAfter { }
}