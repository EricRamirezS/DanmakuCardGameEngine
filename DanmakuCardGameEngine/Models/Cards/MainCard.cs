using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public class MainCard : HandCard, IMainCard {
        public MainCard(int id, string name, ISeason season, IExpansion expansion, int pointValue) : base(
            CardTypes.MainCard, id, name, season, expansion, pointValue) { }
    }
}