using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IReadOnlyDeckManager {
        ReadOnlyDeck<TCard> GetReadOnlyDeck<TCard>() where TCard : ICard;
    }
}