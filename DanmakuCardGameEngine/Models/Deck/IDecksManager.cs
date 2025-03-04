using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IDecksManager : IReadOnlyDeckManager {
        Deck<TCard> GetDeck<TCard>() where TCard : ICard;
        TDeck GetDeck<TDeck, TCard>() where TDeck : IDeck<TCard> where TCard : ICard;
        bool GetDeck<TDeck, TCard>(out TDeck deck) where TDeck : IDeck<TCard> where TCard : ICard;
        void RegisterDeck<TCard>(Deck<TCard> deck) where TCard : ICard;
        void AddToDeck<TCard>(Deck<TCard> deck) where TCard : ICard;
    }
}