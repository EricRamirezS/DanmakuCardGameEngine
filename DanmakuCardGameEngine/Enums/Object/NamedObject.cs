using System;

namespace DanmakuCardGameEngine.Enums.Object {
    [Serializable]
    public abstract class NamedObject : INamedObject {
        public string Name { get; }
        private string UniqueGroup { get; }

        protected NamedObject(string name) {
            Name = name;
        }

        protected NamedObject(string name, string uniqueGroup) {
            Name = name;
            UniqueGroup = uniqueGroup;
        }

        public static bool operator ==(NamedObject obj1, INamedObject obj2) {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            return !ReferenceEquals(obj2, null) && obj1.Equals(obj2);
        }

        public static bool operator !=(NamedObject obj1, INamedObject obj2) => !(obj1 == obj2);

        protected bool Equals(NamedObject other) {
            return Name == other.Name && UniqueGroup == other.UniqueGroup;
        }

        public override bool Equals(object obj) {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((NamedObject)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Name != null ? Name.GetHashCode() : 0) * 397 ^ (UniqueGroup != null ? UniqueGroup.GetHashCode() : 0);
            }
        }

        public bool Equals(INamedObject other) {
            return Equals((object)other);
        }

        public override string ToString() {
            return Name;
        }
    }
}