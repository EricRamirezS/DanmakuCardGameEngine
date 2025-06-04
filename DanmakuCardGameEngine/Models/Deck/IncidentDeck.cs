using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Represents a concrete implementation of a deck specifically for <see cref="IIncidentCard"/> objects.
    /// This class extends <see cref="Deck{TCard}"/> with <see cref="IIncidentCard"/> as its generic type,
    /// providing all standard deck functionalities for incident cards.
    /// </summary>
    public class IncidentDeck : Deck<IIncidentCard>, IIncidentDeck { }
}