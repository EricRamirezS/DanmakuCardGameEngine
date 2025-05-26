using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Models.Cards {
    public interface ICharacterCard : ICard {
        ISpellCardTiming SpellCardTiming { get; }
        IPlayer Owner { get; }
        bool AbilityAvailable { get; }
        bool SpellCardAvailable { get; }
        void ChooseCharacter(IPlayer owner);
        void ChooseCharacter(IPlayer owner, bool abilityAvailable, bool spellCardAvailable);
        void Dismiss();
    }

    public abstract class CharacterCard : Card, ICharacterCard {
        protected CharacterCard(int id, string name, ISeason season, IExpansion expansion) : base(
            CardTypes.CharacterCard, id, name, season, expansion) { }

        public abstract ISpellCardTiming SpellCardTiming { get; }
        public IPlayer Owner { get; private set; }
        public virtual bool AbilityAvailable { get; private set; }
        public virtual bool SpellCardAvailable { get; private set; }

        public virtual void ChooseCharacter(IPlayer owner) {
            Owner = owner;
            AbilityAvailable = true;
            SpellCardAvailable = true;
            Subscribe(GameCore.Instance.EventManager);
        }

        public virtual void ChooseCharacter(IPlayer owner, bool abilityAvailable, bool spellCardAvailable) {
            Owner = owner;
            AbilityAvailable = abilityAvailable;
            SpellCardAvailable = spellCardAvailable;
            Subscribe(GameCore.Instance.EventManager);
        }

        public virtual void Dismiss() {
            Owner = null;
            AbilityAvailable = false;
            SpellCardAvailable = false;
            Unsubscribe(GameCore.Instance.EventManager);
        }

    }
}