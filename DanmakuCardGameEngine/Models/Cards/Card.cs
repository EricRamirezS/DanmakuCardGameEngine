using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Cards {
    public class Card : ICard {
        public ICardType CardType { get; }
        public virtual IModifiers Modifiers => Commons.Modifiers.Empty;
        public virtual void Subscribe(IEventManager eventManager) { }
        public virtual void Unsubscribe(IEventManager eventManager) { }
        public int Id { get; }
        public string Name { get; }
        public ISeason Season { get; }
        public IExpansion Expansion { get; }

        protected Card(ICardType cardType, int id, string name, ISeason season, IExpansion expansion) {
            CardType = cardType;
            Id = id;
            Name = name;
            Season = season;
            Expansion = expansion;
        }

        public bool Equals(ICard obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Card)obj);
        }

        public IReadOnlyCard ToReadOnly() {
            return new ReadOnlyCard(CardType);
        }
        public override string ToString() {
            return $"{Name} ({Id})";
        }
        private bool Equals(Card other) {
            return Equals(CardType, other.CardType) && Id == other.Id && Name == other.Name && Equals(Season, other.Season) &&
                   Equals(Expansion, other.Expansion);
        }
        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Card)obj);
        }
        public override int GetHashCode() {
            unchecked {
                int hashCode = CardType != null ? CardType.GetHashCode() : 0;
                hashCode = hashCode * 397 ^ Id;
                hashCode = hashCode * 397 ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (Season != null ? Season.GetHashCode() : 0);
                hashCode = hashCode * 397 ^ (Expansion != null ? Expansion.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}