using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Exceptions;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    /// <summary>
    /// Provides static utility methods for validating various aspects of the game setup,
    /// such as the number of players and the distribution of role cards.
    /// </summary>
    internal static class GameValidator {
        /// <summary>
        /// Validates the total number of players participating in the game.
        /// Throws an exception if the number of players is outside the acceptable range (4 to 8).
        /// </summary>
        /// <param name="nPlayers">The actual number of players provided for the game.</param>
        /// <exception cref="NoEnoughPlayersException">Thrown if <paramref name="nPlayers"/> is less than 4.</exception>
        /// <exception cref="TooManyPlayersException">Thrown if <paramref name="nPlayers"/> is greater than 8.</exception>
        public static void ValidateNumberOfPlayers(int nPlayers) {
            if (nPlayers < 4) throw new NoEnoughPlayersException(nPlayers);
            if (nPlayers > 8) throw new TooManyPlayersException(nPlayers);
        }

        /// <summary>
        /// Validates the distribution and availability of role cards based on the number of players.
        /// Ensures that the provided role deck contains the minimum required number of each role type
        /// for the given player count.
        /// </summary>
        /// <param name="roles">The deck of <see cref="IRoleCard"/> objects to validate.</param>
        /// <param name="nPlayers">The total number of players in the game.</param>
        /// <exception cref="RoleDeckNotFoundException">Thrown if the <paramref name="roles"/> deck is null.</exception>
        /// <exception cref="RoleDeckEmptyException">Thrown if the <paramref name="roles"/> deck is empty.</exception>
        /// <exception cref="NoEnoughRolesException">Thrown if there are insufficient roles of a specific type
        /// to meet the requirements for <paramref name="nPlayers"/>.</exception>
        public static void ValidateRoles(IDeck<IRoleCard> roles, int nPlayers) {
            if (roles == null) throw new RoleDeckNotFoundException();
            if (((IList)roles).Count <= 0) throw new RoleDeckEmptyException();

            // Filter roles that are applicable for the current number of players
            IRoleCard[] heroines =
                roles.Where(r => r.RoleType == RoleTypes.Heroine && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] stageBosses =
                roles.Where(r => r.RoleType == RoleTypes.StageBoss && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] partners =
                roles.Where(r => r.RoleType == RoleTypes.Partner && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] extraBosses =
                roles.Where(r => r.RoleType == RoleTypes.ExtraBoss && r.RequiredPlayers <= nPlayers).ToArray();

            // Get the required role distribution for the given number of players
            IReadOnlyDictionary<IRoleType, int> distribution = RoleDistribution[nPlayers];

            // Validate if enough roles of each type are available
            if (heroines.Length < distribution[RoleTypes.Heroine])
                throw new NoEnoughRolesException(RoleTypes.Heroine, distribution[RoleTypes.Heroine]);
            if (partners.Length < distribution[RoleTypes.Partner])
                throw new NoEnoughRolesException(RoleTypes.Partner, distribution[RoleTypes.Partner]);
            if (stageBosses.Length < distribution[RoleTypes.StageBoss])
                throw new NoEnoughRolesException(RoleTypes.StageBoss, distribution[RoleTypes.StageBoss]);
            if (extraBosses.Length < distribution[RoleTypes.ExtraBoss])
                throw new NoEnoughRolesException(RoleTypes.ExtraBoss, distribution[RoleTypes.ExtraBoss]);
        }

        /// <summary>
        /// A static read-only dictionary that defines the required distribution of role types
        /// based on the total number of players in the game.
        /// The outer dictionary's key is the number of players, and its value is another
        /// dictionary mapping <see cref="IRoleType"/> to the required count for that role.
        /// </summary>
        internal static readonly IReadOnlyDictionary<int, IReadOnlyDictionary<IRoleType, int>> RoleDistribution =
            new Dictionary<int, IReadOnlyDictionary<IRoleType, int>> {
                {
                    4, // For 4 players
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 0 },
                        { RoleTypes.StageBoss, 2 },
                        { RoleTypes.ExtraBoss, 1 },
                    }
                }, {
                    5, // For 5 players
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 1 },
                        { RoleTypes.StageBoss, 2 },
                        { RoleTypes.ExtraBoss, 1 },
                    }
                }, {
                    6, // For 6 players
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 1 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 },
                    }
                }, {
                    7, // For 7 players
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 2 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 },
                    }
                }, {
                    8, // For 8 players
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 2 },
                        { RoleTypes.Partner, 2 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 },
                    }
                },
            };
    }
}