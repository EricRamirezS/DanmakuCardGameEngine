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

        public bool Equals(NamedObject other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GetType() == other.GetType() && Name == other.Name && UniqueGroup == other.UniqueGroup;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((NamedObject)obj);
        }

        public override int GetHashCode() {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public bool Equals(INamedObject other) {
            return Equals((object)other);
        }

        public override string ToString() {
            return Name;
        }
    }
}