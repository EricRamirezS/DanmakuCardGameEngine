using System;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Events.Args;

namespace DanmakuCardGameEngine.Events.EventObjects {

    /// <summary>
    /// Provides a generic implementation for an event system with "Before" and "After" phases,
    /// and a "bubbling" capability that allows "Before" handlers to stop event propagation
    /// and the execution of the main action.
    /// </summary>
    /// <typeparam name="TArgs">The type of event arguments, which must inherit from <see cref="BaseEventArgs"/>.</typeparam>
    public class BubblingEvent<TArgs> where TArgs : BaseEventArgs {

        /// <summary>
        /// Delegates for event handlers that execute *before* the main event action.
        /// These handlers can set <c>bubbleEvent</c> to <c>false</c> to stop propagation.
        /// </summary>
        private event BubblingEventHandler<TArgs> BeforeHandlers;

        /// <summary>
        /// Delegates for event handlers that execute *after* the main event action.
        /// These handlers cannot stop event propagation.
        /// </summary>
        private event SimpleEventHandler<TArgs> AfterHandlers;

        /// <summary>
        /// Invokes event handlers in sequence: first the <c>Before</c> handlers,
        /// then the main action (<paramref name="execution"/>), and finally the <c>After</c> handlers.
        /// </summary>
        /// <param name="args">The event arguments to be passed to all handlers.</param>
        /// <param name="execution">A function representing the main logic of the event,
        /// which will only execute if no <c>Before</c> handler stops bubbling.</param>
        /// <param name="uncancellable">True if the event cannot be cancelled, false otherwise.</param>
        /// <returns>A <see cref="Task{TResult}"/> that completes with <c>true</c> if the event executed completely
        /// (including the main action), or <c>false</c> if a <c>Before</c> handler stopped bubbling.
        /// If an exception occurs, the Task completes with the exception.</returns>
        public Task<bool> Invoke(TArgs args, Action<TArgs> execution, bool uncancellable = false) {
            try {
                bool continueBubbling = true;
                args.Uncancellable = uncancellable;

                // Invoke Before handlers
                if (BeforeHandlers != null) {
                    foreach (Delegate handler in BeforeHandlers.GetInvocationList()) {
                        // Invoke the handler and get the 'bubble' value
                        ((BubblingEventHandler<TArgs>)handler).Invoke(ref args, out bool bubble);

                        // If 'bubble' is false, stop bubbling and execution
                        if (bubble || uncancellable) continue;
                        continueBubbling = false;
                        break; // Exit the Before handlers loop
                    }
                }

                // If bubbling was stopped by a Before handler, neither the main action nor AfterHandlers are executed
                if (!continueBubbling || uncancellable) return Task.FromResult(false);

                // Execute the main event action
                execution?.Invoke(args);

                // Invoke After handlers
                if (AfterHandlers == null) return Task.FromResult(true);

                foreach (Delegate handler in AfterHandlers.GetInvocationList()) {
                    ((SimpleEventHandler<TArgs>)handler).Invoke(args);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex) {
                // Catch any exception during invocation and propagate it through the Task
                return Task.FromException<bool>(ex);
            }
        }

        /// <summary>
        /// Allows subscription to event handlers that execute *before* the main event action.
        /// Subscribers can intercept the event and potentially stop its propagation.
        /// </summary>
        public event BubblingEventHandler<TArgs> Before
        {
            add => BeforeHandlers += value;
            remove => BeforeHandlers -= value;
        }

        /// <summary>
        /// Allows subscription to event handlers that execute *after* the main event action.
        /// These handlers are for reaction only and cannot stop the event flow.
        /// </summary>
        public event SimpleEventHandler<TArgs> After
        {
            add => AfterHandlers += value;
            remove => AfterHandlers -= value;
        }
    }


}