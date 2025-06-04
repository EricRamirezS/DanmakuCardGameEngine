using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when the game state changes.
    /// </summary>
    public sealed class GameStateEventArgs : BaseEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateEventArgs"/> class.
        /// </summary>
        /// <param name="previousState">The previous game state.</param>
        /// <param name="newState">The new game state.</param>
        public GameStateEventArgs(IState previousState, IState newState) {
            PreviousState = previousState;
            NewState = newState;
        }
        /// <summary>
        /// Gets the previous game state.
        /// </summary>
        public IState PreviousState { get; }
        /// <summary>
        /// Gets or sets the new game state.
        /// </summary>
        public IState NewState { get; set; }
    }
}