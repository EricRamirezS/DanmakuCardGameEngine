using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IStackResolvedEventBefore"/> and <see cref="IStackResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="StackResolvedEvent"/>.
    /// </summary>
    public interface IStackResolvedEvent : IStackResolvedEventBefore, IStackResolvedEventAfter { }
}