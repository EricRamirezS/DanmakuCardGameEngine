using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class RandomBotPlayer : Player {
        public RandomBotPlayer(string name) : base(name) { }

        public override Task DrawCard<TCard>(IDeck<TCard> deck) {
            throw new NotImplementedException();
        }
        public override Task DrawCards<TCard>(IDeck<TCard> deck, int quantity) {
            throw new NotImplementedException();
        }
        public override Task PlayCard(ICard card) {
            throw new NotImplementedException();
        }

        public override Task Attack(IReadOnlyPlayer player) {
            throw new NotImplementedException();
        }

        public override Task TakeDamage(int damage) {
            throw new NotImplementedException();
        }

        public override async Task ChooseCharacter(IList<ICharacterCard> characters) {
            MainCharacterCard = await ChooseAsync(characters.ToList().AsReadOnly(), GameCore.Instance.GameState);
        }
        public override Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState) {
            Random random = new Random();
            return Task.FromResult(options[random.Next(0, options.Count)]);
        }
    }
}