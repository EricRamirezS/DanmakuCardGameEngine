using DanmakuCardGameEngine.Events.EventObjects;

namespace DanmakuCardGameEngine.Events {
    /// <summary>
    /// Combines the <see cref="IIncidentStepEventBefore"/> and <see cref="IIncidentStepEventAfter"/> interfaces,
    /// allowing a single subscriber to handle both phases of the <see cref="IncidentStepEvent"/>.
    /// </summary>
    public interface IIncidentStepEvent : IIncidentStepEventBefore, IIncidentStepEventAfter { }
}