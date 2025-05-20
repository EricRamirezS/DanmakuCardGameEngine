using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface ICharacterCard : ICard {
        ISpellCardTiming SpellCardTiming { get; }
    }

    public abstract class CharacterCard : Card, ICharacterCard {
        protected CharacterCard(int id, string name, ISeason season, IExpansion expansion) : base(
            CardTypes.CharacterCard, id, name, season, expansion) { }

        public abstract ISpellCardTiming SpellCardTiming { get; }
    }
}