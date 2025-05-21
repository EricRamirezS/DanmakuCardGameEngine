using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class ModifierNames {
        public static readonly IModifierName Distance = new ModifierName("Distance");
        public static readonly IModifierName Range = new ModifierName("Range");
        public static readonly IModifierName AdditionalDanmaku = new ModifierName("Additional Danmaku");
        public static readonly IModifierName AdditionalDraw = new ModifierName("Additional Draw");
        public static readonly IModifierName MaxLife = new ModifierName("Max Life");
        public static readonly IModifierName MaxHand = new ModifierName("Max Hand");
    }
}