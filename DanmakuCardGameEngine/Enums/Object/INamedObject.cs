using System;
using System.Collections.Generic;

namespace DanmakuCardGameEngine.Models.Commons {
    public interface INamedObject : IEquatable<INamedObject>, IEqualityComparer<INamedObject> {
        string Name { get; }
        string FullName { get; }
    }
}