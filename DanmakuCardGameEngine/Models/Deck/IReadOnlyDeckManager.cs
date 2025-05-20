using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IReadOnlyDeckManager {
        IReadOnlyDeck<TCard> GetReadOnlyDeck<TCard>() where TCard : ICard;
        bool ContainsDeck<TCard>() where TCard : ICard;
    }
}