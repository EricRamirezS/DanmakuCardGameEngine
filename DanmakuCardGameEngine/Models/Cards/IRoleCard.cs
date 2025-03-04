using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface IRoleCard : ICard {
        IRoleType RoleType { get; }
        IRoleType AltRoleType { get; }
        int? RequiredPlayers { get; }
        IRoleCard RevealedForm { get; }
    }

    public abstract class RoleCard : Card, IRoleCard {
        protected RoleCard(int id, string name, ISeason season, IExpansion expansion) : base(CardTypes.RoleCard, id,
            name, season, expansion) { }

        public abstract IRoleType RoleType { get; }
        public virtual IRoleType AltRoleType { get; }
        public virtual int? RequiredPlayers { get; }
        public virtual IRoleCard RevealedForm { get; }
    }
}