using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    public abstract class ExpansionData : NamedObject, IExpansionData {
        protected ExpansionData(Expansion expansion) : base(expansion.Name, "Expansion") { }
        public virtual IRoleDeck RoleDeck { get; }
        public virtual IMainDeck MainDeck { get; }
        public virtual ICharacterDeck CharacterDeck { get; }
        public virtual IIncidentDeck IncidentDeck { get; }
        public abstract Expansion Expansion { get; }
        public virtual void RegisterOtherDecks(IDecksManager decksManager) {
        }
    }
}