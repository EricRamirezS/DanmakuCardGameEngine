using DanmakuBaseExpansion.Decks;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuBaseExpansion {
    public class ExpansionData : DanmakuCardGameEngine.Core.ExpansionData {
        internal static readonly Expansion BaseExpansion = new Expansion("Base");


        public override IMainDeck MainDeck => BaseMainDeck.Get();
        public override IIncidentDeck IncidentDeck => BaseIncidentDeck.Get();
        public override ICharacterDeck CharacterDeck => BaseCharacterDeck.Get();
        public override IRoleDeck RoleDeck => BaseRoleDeck.Get();
        
        public override Expansion Expansion => BaseExpansion;
        public ExpansionData() : base(BaseExpansion) { }
    }
}