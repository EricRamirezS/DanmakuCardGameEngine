using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {
    /// <summary>
    /// Represents a delegate for event handlers that can intercept event execution
    /// and control whether the event should "bubble" (continue its propagation) or stop.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    /// <param name="args">The event arguments containing relevant information about the occurrence.</param>
    /// <param name="bubbleEvent">An output boolean value that indicates whether the event should continue bubbling.
    /// Setting it to <c>false</c> will stop the execution of remaining <c>Before</c> handlers
    /// and the main event action.</param>
    public delegate void BubblingEventHandler<TArgs>(ref TArgs args, out bool bubbleEvent) where TArgs : BaseEventArgs;
}