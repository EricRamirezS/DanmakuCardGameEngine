using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

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
        public virtual IRoleType AltRoleType => null;
        public virtual int? RequiredPlayers => null;
        public virtual IRoleCard RevealedForm => null;
    }
}