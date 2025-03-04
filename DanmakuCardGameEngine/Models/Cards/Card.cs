using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Cards {
    public class Card : ICard {
        public ICardType CardType { get; }
        public string Id { get; }
        public string Name { get; }
        public ISeason Season { get; }
        public IExpansion Expansion { get; }

        public static implicit operator ReadOnlyCard(Card c) {
            return new ReadOnlyCard(c.CardType);
        }

        public Card(ICardType cardType, string id, string name, ISeason season, IExpansion expansion) {
            CardType = cardType;
            Id = id;
            Name = name;
            Season = season;
            Expansion = expansion;
        }
    }
}