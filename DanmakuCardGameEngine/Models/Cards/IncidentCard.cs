using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public class IncidentCard : Card, IIncidentCard {
        protected IncidentCard(int id, string name, ISeason season, IExpansion expansion) : base(CardTypes.IncidentCard, id, name, season, expansion) { }
    }
}