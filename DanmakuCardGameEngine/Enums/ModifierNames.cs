using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Enums {
    public static class ModifierNames {
        public static readonly IModifierName Distance = new ModifierName("Distance");
        public static IModifierName Range = new ModifierName("Range");
        public static IModifierName AdditionalDanmaku = new ModifierName("Additional Danmaku");
        public static IModifierName AdditionalDraw = new ModifierName("Additional Draw");
        public static IModifierName MaxLife = new ModifierName("Max Life");
        public static IModifierName MaxHand = new ModifierName("Max Hand");
    }
}