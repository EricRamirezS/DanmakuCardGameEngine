using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    public class ExpansionData : NamedObject, IExpansionData {
        public ExpansionData(string name) : base(name, "Expansion") { }
        public virtual IRoleDeck RoleDeck { get; }
        public virtual IMainDeck MainDeck { get; }
        public virtual CharacterDeck CharacterDeck { get; }
        public virtual IncidentDeck IncidentDeck { get; }
        public virtual IDictionary<CardType, IDeck<ICard>> OtherDecks { get; }
    }
}