using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Models.Commons {
    public interface IModifierData {
        int Value { get; }
        IDuration Duration { get; }
        object Source { get; }
    }

    public class ModifierData : IModifierData {
        public int Value { get; }
        public IDuration Duration { get; }
        public object Source { get; }

        public ModifierData(object source, int value, IDuration duration) {
            Value = value;
            Duration = duration;
            Source = source;
        }
    }

    public interface IModifiers : IDictionary<IModifierName, IModifierData> { }

    public class Modifiers : Dictionary<IModifierName, IModifierData>, IModifiers {
        public static Modifiers Empty { get; } = new Modifiers();
    }
}