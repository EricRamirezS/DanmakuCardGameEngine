using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Player.Components {
    public interface IHand : IList<IHandCard>, IReadOnlyConverter<IReadOnlyHand> {
        int MaxHandSize { get; }
        int CardCount();
        int CardCount<T>() where T : IHandCard;

        void AddRange(IEnumerable<IHandCard> collection);
    }

}