using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    public abstract class EquatablePlayer : IEquatablePlayer {
        public abstract string Id { get; }
        public abstract string Name { get; }
        public abstract bool HasCharacter(ICharacterCard card);

        public bool Equals(IEquatablePlayer other) {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj is IEquatablePlayer e) return Equals(e);
            return false;
        }

        public override int GetHashCode() {
            unchecked {
                return (Id != null ? Id.GetHashCode() : 0) * 397 ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}