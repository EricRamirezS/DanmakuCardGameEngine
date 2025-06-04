using System;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Game;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable once MemberCanBeMadeStatic.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Abstract base class for all event arguments in the game engine.
    /// Provides access to the current game state and a property to indicate if the event is uncancellable.
    /// </summary>
    public abstract class BaseEventArgs : EventArgs {
        /// <summary>
        /// Gets the current read-only game state.
        /// </summary>
        public IReadOnlyGameState GameState => GameCore.Instance.GameState;
        /// <summary>
        /// Gets or sets a value indicating whether the event is uncancellable.
        /// If <c>true</c>, the event cannot be prevented or overridden by other actions.
        /// </summary>
        public bool Uncancellable { get; internal set; }
    }

}
