using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.RoleDeck {
    public abstract class BaseRoleCard : RoleCard {
        protected BaseRoleCard(int id, string name, ISeason season) : base(id, name, season,
            ExpansionData.BaseExpansion) { }
    }
}