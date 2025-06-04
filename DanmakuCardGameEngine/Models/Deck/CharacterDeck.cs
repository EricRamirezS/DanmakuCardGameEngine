using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Represents a concrete implementation of a deck specifically for <see cref="ICharacterCard"/> objects.
    /// This class extends <see cref="Deck{TCard}"/> with <see cref="ICharacterCard"/> as its generic type,
    /// providing all standard deck functionalities for character cards.
    /// </summary>
    public class CharacterDeck : Deck<ICharacterCard>, ICharacterDeck { }
}