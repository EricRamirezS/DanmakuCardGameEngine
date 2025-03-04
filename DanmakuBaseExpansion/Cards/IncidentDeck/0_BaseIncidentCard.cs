using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.IncidentDeck {
    public abstract class BaseIncidentCard : IncidentCard {
        protected BaseIncidentCard(int id, string name, ISeason season) : base(id, name, season,
            ExpansionData.BaseExpansion) { }
    }
}