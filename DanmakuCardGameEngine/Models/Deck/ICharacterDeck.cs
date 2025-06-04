using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines an interface for a deck specifically containing <see cref="ICharacterCard"/> objects.
    /// This interface extends <see cref="IDeck{TCard}"/> with <see cref="ICharacterCard"/> as its generic type.
    /// </summary>
    public interface ICharacterDeck : IDeck<ICharacterCard> { }
}