using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Represents a delegate for simple event handlers that react to an occurrence
    /// without the ability to intercept or modify the "bubbling" flow of the event.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    /// <param name="args">The event arguments containing relevant information about the occurrence.</param>
    public delegate void SimpleEventHandler<in TArgs>(TArgs args) where TArgs : BaseEventArgs;
}