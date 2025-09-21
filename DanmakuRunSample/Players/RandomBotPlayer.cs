using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class RandomBotPlayer : Player {
        public RandomBotPlayer(string name) : base(name) { }

        public override Task PlayCard(ICard card) {
            throw new NotImplementedException();
        }

        public override Task Attack(IReadOnlyPlayer player) {
            throw new NotImplementedException();
        }

        public override Task TakeDamage(int damage) {
            throw new NotImplementedException();
        }

        private static readonly Random _random = new Random();

        public async override Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState, CancellationToken cancellationToken = default) {
            // random bot takes a random amount of time to choose an option (between 1 and 12 seconds)
#if DEBUG
            int delayMs = _random.Next(1000, 2000);
#else
            int delayMs = _random.Next(1000, 12500);
#endif

            await Task.Delay(delayMs, cancellationToken);

            return options[_random.Next(0, options.Count)];
        }

        public override T Choose<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState) {
            Random random = new Random();
            return options[random.Next(0, options.Count)];
        }
    }
}