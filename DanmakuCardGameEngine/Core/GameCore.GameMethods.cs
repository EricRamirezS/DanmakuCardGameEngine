using System.Collections.Generic;
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
                (args) =>  
                {
                    IDeck<TCard> handCards = _gameState.DeckManager.GetDeck<TCard>();
                    player.Hand.AddRange( handCards.Draw(quantity).Cast<IHandCard>().AsEnumerable() );
                }
            );
        }

        public async Task DiscardCard(IPlayer player, IHandCard card) {
            player.Hand.Remove(card);
            await DiscardCard(card);
        }

        public async Task DiscardCard(ICard card) {
            IDeck deck = _gameState.DeckManager.GetDeck(card);
            await deck?.AddToDiscard(card);
        }
    }
}