using System.Collections.Generic;
using DanmakuCardGameEngine.Enums.Object;

namespace DanmakuCardGameEngine.Tools {
    /// <summary>
    /// Provides utility methods and constants related to card operations.
    /// </summary>
    public static class CardUtils {
        /// <summary>
        /// A read-only empty list of card subtypes. This can be used to represent cards
        /// that have no specific subtypes, avoiding null checks or unnecessary list allocations.
        /// </summary>
        public static readonly IReadOnlyList<ICardSubtypes> EmptySubtypes = new List<ICardSubtypes>().AsReadOnly();
    }
}