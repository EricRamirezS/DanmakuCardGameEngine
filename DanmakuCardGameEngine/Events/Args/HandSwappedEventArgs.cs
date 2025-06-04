using DanmakuCardGameEngine.Models.Player;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when two players' hands are swapped.
    /// </summary>
    public sealed class HandSwappedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the original read-only hand of Player 1 before the swap.
        /// </summary>
        public IReadOnlyHand Player1Hand { get; }
        /// <summary>
        /// Gets the original read-only hand of Player 2 before the swap.
        /// </summary>
        public IReadOnlyHand Player2Hand { get; }
        /// <summary>
        /// Gets the read-only Player 1 involved in the swap.
        /// </summary>
        public IReadOnlyPlayer Player1 { get; }
        /// <summary>
        /// Gets the read-only Player 2 involved in the swap.
        /// </summary>
        public IReadOnlyPlayer Player2 { get; }
        /// <summary>
        /// Gets or sets the new read-only hand of Player 1 after the swap.
        /// </summary>
        public IReadOnlyHand Player1NewHand { get; set; }
        /// <summary>
        /// Gets or sets the new read-only hand of Player 2 after the swap.
        /// </summary>
        public IReadOnlyHand Player2NewHand { get; set; }
    }
}