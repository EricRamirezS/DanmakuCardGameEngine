using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuBaseExpansion.Cards.CharacterDeck.BaseImplementation {
    public abstract class BaseCharacterCard : CharacterCard {
        protected BaseCharacterCard(int id, string name, ISeason season) : base(id, name, season,
            ExpansionData.BaseExpansion) { }
    }
}