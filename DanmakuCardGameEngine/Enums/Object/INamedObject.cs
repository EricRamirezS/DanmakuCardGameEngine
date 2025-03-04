using System;
using System.Collections.Generic;

namespace DanmakuCardGameEngine.Enums.Object {
    public interface INamedObject :
        IEquatable<INamedObject> {
        string Name { get; }
    }
}