using System;

namespace DanmakuCardGameEngine.Enums.Object {
    public interface INamedObject :
        IEquatable<INamedObject> {
        string Name { get; }
    }
}