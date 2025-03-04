namespace DanmakuCardGameEngine.Models.Player {
    public abstract partial class Player {
        public bool Equals(IReadOnlyPlayer other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(IReadOnlyPlayer)) return false;
            return Equals((ReadOnlyPlayer)obj);
        }

        public override int GetHashCode() {
            int hashCode = (Id != null ? Id.GetHashCode() : 0);
            return hashCode;
        }
        
        public static bool operator ==(Player obj1, IReadOnlyPlayer obj2) {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            if (ReferenceEquals(obj2, null))
                return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Player obj1, IReadOnlyPlayer obj2) => !(obj1 == obj2);

    }
}