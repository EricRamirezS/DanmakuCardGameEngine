using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Deck {
    public interface IDeck<TCard> : IDeck, IReadOnlyConverter<IReadOnlyDeck<TCard>>, IList<TCard>
        where TCard : ICard {
        new TCard Draw();
        IDiscard<TCard> Discard { get; }

        new IList<TCard> Draw(int numberOfCard);
        void AddRange(IEnumerable<TCard> collection);
        Task AddToDiscard(TCard card);
    }

    public interface IDeck: IList, IShuffleable {
        ICard Draw();
        IList<ICard> Draw(int numberOfCards);
        Task AddToDiscard(ICard card);
        IDiscard GetDiscard();
    }
    
    public interface IShuffleable {
        void Shuffle();
    }
}