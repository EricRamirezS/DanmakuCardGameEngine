using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Events.Args;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore {

        /// <inheritdoc />
        /// <summary>
        /// Asynchronously draws a specified quantity of cards of a particular type for a given player.
        /// This method triggers an <see cref="EventManager.OnDraw"/> event.
        /// </summary>
        /// <typeparam name="TCard">The type of <see cref="IHandCard"/> to draw.</typeparam>
        /// <param name="player">The player who will draw the cards.</param>
        /// <param name="quantity">The number of cards to draw.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous drawing operation.</returns>
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

        /// <summary>
        /// Asynchronously discards a specific hand card from a player's hand and moves it to the appropriate discard pile.
        /// </summary>
        /// <param name="player">The player from whose hand the card will be discarded.</param>
        /// <param name="card">The hand card to discard.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous discard operation.</returns>
        public async Task DiscardCard(IPlayer player, IHandCard card) {
            player.Hand.Remove(card);
            await DiscardCard(card);
        }

        /// <summary>
        /// Asynchronously discards a generic card by moving it to its appropriate discard pile.
        /// </summary>
        /// <param name="card">The card to discard.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous discard operation.</returns>
        public async Task DiscardCard(ICard card) {
            IDeck deck = _gameState.DeckManager.GetDeck(card);
            await deck?.AddToDiscard(card);
        }
    }
}