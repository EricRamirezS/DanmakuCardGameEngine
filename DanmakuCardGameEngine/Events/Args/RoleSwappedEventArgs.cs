using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Events.Args {
    /// <summary>
    /// Provides data for an event that occurs when two players' Role cards are swapped.
    /// </summary>
    public sealed class RoleSwappedEventArgs : BaseEventArgs {
        /// <summary>
        /// Gets the original read-only Role card of Player 1 before the swap.
        /// </summary>
        public IReadOnlyCard Player1Role { get; }
        /// <summary>
        /// Gets the original read-only Role card of Player 2 before the swap.
        /// </summary>
        public IReadOnlyCard Player2Role { get; }
        /// <summary>
        /// Gets the read-only Player 1 involved in the role swap.
        /// </summary>
        public IReadOnlyPlayer Player1 { get; }
        /// <summary>
        /// Gets the read-only Player 2 involved in the role swap.
        /// </summary>
        public IReadOnlyPlayer Player2 { get; }
        /// <summary>
        /// Gets or sets the new read-only Role card of Player 1 after the swap.
        /// </summary>
        public IReadOnlyCard Player1NewRole { get; set; }
        /// <summary>
        /// Gets or sets the new read-only Role card of Player 2 after the swap.
        /// </summary>
        public IReadOnlyCard Player2NewRole { get; set; }
    }
}