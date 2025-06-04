using System;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Exceptions {
    /// <summary>
    /// Exception thrown when there are not enough roles of a specific type (e.g., Heroine)
    /// to meet the minimum player requirements for the game.
    /// </summary>
    internal class NoEnoughRolesException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEnoughRolesException"/> class with a specified error message.
        /// </summary>
        /// <param name="heroine">The type of role for which there are insufficient cards.</param>
        /// <param name="minPlayers">The minimum number of players required for this role type.</param>
        public NoEnoughRolesException(IRoleType heroine, int minPlayers) : base(
            $"No enough {heroine} roles found. At least {minPlayers} {(minPlayers == 1 ? "is" : "are")} required.") { }
    }
}