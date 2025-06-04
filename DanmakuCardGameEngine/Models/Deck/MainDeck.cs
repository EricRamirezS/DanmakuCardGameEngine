
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Represents a concrete implementation of a deck specifically for <see cref="IMainCard"/> objects.
    /// This class extends <see cref="Deck{TCard}"/> with <see cref="IMainCard"/> as its generic type,
    /// providing all standard deck functionalities for main cards.
    /// </summary>
    public class MainDeck : Deck<IMainCard>, IMainDeck { }
}