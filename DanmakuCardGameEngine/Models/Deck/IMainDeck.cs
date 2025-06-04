using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines an interface for a deck specifically containing <see cref="IMainCard"/> objects.
    /// This interface extends <see cref="IDeck{TCard}"/> with <see cref="IMainCard"/> as its generic type.
    /// </summary>
    public interface IMainDeck : IDeck<IMainCard> { }
}