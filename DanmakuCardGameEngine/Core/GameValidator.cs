using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    internal static class GameValidator {
        public static void ValidateNumberOfPlayers(int nPlayers) {
            if (nPlayers < 4) throw new NoEnoughPlayersException(nPlayers);
            if (nPlayers > 8) throw new TooManyPlayersException(nPlayers);
        }

        public static void ValidateRoles(Deck<IRoleCard> roles, int nPlayers) {
            if (roles == null) throw new RoleDeckNotFoundException();
            if (roles.Count <= 0) throw new RoleDeckEmptyException();

            IRoleCard[] heroines =
                roles.Where(r => r.RoleType == RoleTypes.Heroine && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] stageBosses =
                roles.Where(r => r.RoleType == RoleTypes.StageBoss && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] partners =
                roles.Where(r => r.RoleType == RoleTypes.Partner && r.RequiredPlayers <= nPlayers).ToArray();
            IRoleCard[] extraBosses =
                roles.Where(r => r.RoleType == RoleTypes.ExtraBoss && r.RequiredPlayers <= nPlayers).ToArray();

            IReadOnlyDictionary<IRoleType, int> distribution = _roleDistribution[nPlayers];
            if (heroines.Length < distribution[RoleTypes.Heroine])
                throw new NoEnoughRolesException(RoleTypes.Heroine, distribution[RoleTypes.Heroine]);
            if (partners.Length < distribution[RoleTypes.Partner])
                throw new NoEnoughRolesException(RoleTypes.Partner, distribution[RoleTypes.Partner]);
            if (stageBosses.Length < distribution[RoleTypes.StageBoss])
                throw new NoEnoughRolesException(RoleTypes.StageBoss, distribution[RoleTypes.StageBoss]);
            if (extraBosses.Length < distribution[RoleTypes.ExtraBoss])
                throw new NoEnoughRolesException(RoleTypes.ExtraBoss, distribution[RoleTypes.ExtraBoss]);
        }

        internal static readonly IReadOnlyDictionary<int, IReadOnlyDictionary<IRoleType, int>> _roleDistribution =
            new Dictionary<int, IReadOnlyDictionary<IRoleType, int>> {
                {
                    4,
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 0 },
                        { RoleTypes.StageBoss, 2 },
                        { RoleTypes.ExtraBoss, 1 }
                    }
                }, {
                    5,
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 1 },
                        { RoleTypes.StageBoss, 2 },
                        { RoleTypes.ExtraBoss, 1 }
                    }
                }, {
                    6,
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 1 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 }
                    }
                }, {
                    7,
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 1 },
                        { RoleTypes.Partner, 2 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 }
                    }
                }, {
                    8,
                    new Dictionary<IRoleType, int> {
                        { RoleTypes.Heroine, 2 },
                        { RoleTypes.Partner, 2 },
                        { RoleTypes.StageBoss, 3 },
                        { RoleTypes.ExtraBoss, 1 }
                    }
                }
            };
    }
}