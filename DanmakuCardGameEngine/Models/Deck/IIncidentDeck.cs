using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    /// <summary>
    /// Defines an interface for a deck specifically containing <see cref="IIncidentCard"/> objects.
    /// This interface extends <see cref="IDeck{TCard}"/> with <see cref="IIncidentCard"/> as its generic type.
    /// </summary>
    public interface IIncidentDeck : IDeck<IIncidentCard>  { }
}