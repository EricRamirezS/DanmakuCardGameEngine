using System;

namespace DanmakuCardGameEngine.Models.Commons {
    public class NamedObject<T> : INamedObject where T : INamedObject {
        public string Name { get; }
        private readonly Type _type = typeof(T);
        public string FullName => _type.Namespace + _type.Name + Name;

        protected NamedObject(string name) {
            Name = name;
        }

        protected bool Equals(T other) {
            return Equals((object)other);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((INamedObject)obj);
        }

        public override int GetHashCode() {
            return FullName != null ? FullName.GetHashCode() : 0;
        }


        public bool Equals(INamedObject other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FullName == other.FullName;
        }

        public bool Equals(INamedObject x, INamedObject y) {
            if (ReferenceEquals(null, x)) return false;
            if (ReferenceEquals(null, y)) return false;
            if (ReferenceEquals(x, y)) return true;
            return x.FullName == y.FullName;
        }

        public int GetHashCode(INamedObject obj) {
            return obj.FullName != null ? obj.FullName.GetHashCode() : 0;
        }

        public static bool operator ==(NamedObject<T> obj1, INamedObject obj2) {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            if (ReferenceEquals(obj2, null))
                return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(NamedObject<T> obj1, INamedObject obj2) => !(obj1 == obj2);
    }
}