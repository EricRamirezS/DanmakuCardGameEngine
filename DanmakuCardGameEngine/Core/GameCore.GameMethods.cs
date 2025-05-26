using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore {

        public Task DrawCards<TCard>(IPlayer player, int quantity) where TCard : IHandCard {
            return EventManager.OnDraw.Invoke(
                new DrawEventArgs(),
                () =>
                {
                    IDeck<TCard> handCards = _gameState.DeckManager.GetDeck<TCard>();
                    player.Hand.AddRange( handCards.Draw(quantity).Cast<IHandCard>().AsEnumerable() );
                }
            );
        }
    }
}