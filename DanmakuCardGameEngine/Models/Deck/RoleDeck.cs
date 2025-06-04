using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Represents a concrete implementation of a deck specifically for <see cref="IRoleCard"/> objects.
    /// This class extends <see cref="Deck{TCard}"/> with <see cref="IRoleCard"/> as its generic type,
    /// providing all standard deck functionalities for role cards.
    /// </summary>
    public class RoleDeck : Deck<IRoleCard>, IRoleDeck { }
}