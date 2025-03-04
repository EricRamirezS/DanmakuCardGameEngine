using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class CardTypes {
        public static readonly ICardType MainCard = new CardType("Main Card");
        public static readonly ICardType IncidentCard = new CardType("Incident Card");
        public static readonly ICardType RoleCard = new CardType("Role Card");
        public static readonly ICardType CharacterCard = new CardType("Character Card");
    }
}