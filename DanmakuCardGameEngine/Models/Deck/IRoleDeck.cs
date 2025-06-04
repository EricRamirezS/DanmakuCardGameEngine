using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines an interface for a deck specifically containing <see cref="IRoleCard"/> objects.
    /// This interface extends <see cref="IDeck{TCard}"/> with <see cref="IRoleCard"/> as its generic type.
    /// </summary>
    public interface IRoleDeck : IDeck<IRoleCard> { }
}