using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public class Card : ICard {
        public ICardType CardType { get; }
        public virtual IModifiers Modifiers => Commons.Modifiers.Empty;
        public int Id { get; }
        public string Name { get; }
        public ISeason Season { get; }
        public IExpansion Expansion { get; }

        public static implicit operator ReadOnlyCard(Card c) {
            return new ReadOnlyCard(c.CardType);
        }

        protected Card(ICardType cardType, int id, string name, ISeason season, IExpansion expansion) {
            CardType = cardType;
            Id = id;
            Name = name;
            Season = season;
            Expansion = expansion;
        }

        public override string ToString() {
            return $"{Name} ({Id})";
        }
    }
}