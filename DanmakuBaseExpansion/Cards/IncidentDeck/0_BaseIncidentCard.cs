using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    public abstract class BaseMainCard : MainCard {
        protected BaseMainCard(int id, string name, ISeason season, int pointValue) :
            base(id, name, season, ExpansionData.BaseExpansion, pointValue) { }
    }
}