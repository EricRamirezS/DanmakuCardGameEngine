using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Tools {
    public static class CardUtils {
        public static IReadOnlyList<ICardSubtypes> EmptySubtypes = new List<ICardSubtypes>().AsReadOnly();
    }
}