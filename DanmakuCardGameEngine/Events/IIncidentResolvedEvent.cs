using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IIncidentResolvedEventBefore"/> and <see cref="IIncidentResolvedEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncidentResolvedEvent"/>.
    /// </summary>
    public interface IIncidentResolvedEvent : IIncidentResolvedEventBefore, IIncidentResolvedEventAfter { }
}