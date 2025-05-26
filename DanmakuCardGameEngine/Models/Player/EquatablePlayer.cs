using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    public abstract class EquatablePlayer : IEquatablePlayer {
        public abstract string Id { get; }
        public abstract string Name { get; }
        public abstract bool HasCharacter(ICharacterCard card);

        public static bool operator ==(EquatablePlayer left, EquatablePlayer right) {
            return AreEquals(left, right);
        }

        public static bool operator !=(EquatablePlayer left, EquatablePlayer right) {
            return !(left == right);
        }

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
        public static bool AreEquals(IEquatablePlayer x, IEquatablePlayer y) {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public bool Equals(IEquatablePlayer x, IEquatablePlayer y) {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(IEquatablePlayer obj) {
            unchecked {
                return ((obj.Id != null ? obj.Id.GetHashCode() : 0) * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }
    }
}