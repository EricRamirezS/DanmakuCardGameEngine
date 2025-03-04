using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Enums {
    public class ModifierName: NamedObject, IModifierName {
        public ModifierName(string name) : base(name, "Modifiers") { }
    }
}