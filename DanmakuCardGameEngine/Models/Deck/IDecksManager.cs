using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IDecksManager : IReadOnlyDeckManager {
        Deck<TCard> GetDeck<TCard>() where TCard : ICard;
        TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard;
        void RegisterDeck<TCard>(Deck<TCard> deck) where TCard : ICard;
    }
}