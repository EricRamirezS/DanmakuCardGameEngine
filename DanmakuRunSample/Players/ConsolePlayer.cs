using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class ConsolePlayer : Player {
        public ConsolePlayer(string name) : base(name) { }

        public override Task PlayCard(ICard card) {
            throw new NotImplementedException();
        }

        public override Task Attack(IReadOnlyPlayer player) {
            throw new NotImplementedException();
        }

        public override Task TakeDamage(int damage) {
            throw new NotImplementedException();
        }

        public async override Task<T> ChooseAsync<T>(
            IReadOnlyList<T> options,
            IReadOnlyGameState gameState,
            CancellationToken cancellationToken = default) {
            for (int i = 0; i < options.Count; i++) {
                Console.WriteLine($"{i + 1}.- {options[i]}");
            }

            while (true) {
                cancellationToken.ThrowIfCancellationRequested();

                string input = await Task.Run(Console.ReadLine, cancellationToken);

                if (int.TryParse(input, out int option) &&
                    option >= 1 &&
                    option <= options.Count) {
                    return options[option - 1];
                }

                Console.WriteLine("Invalid option");
            }
        }


        public override T Choose<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState) {
            int option = 0;
            for (int i = 0; i < options.Count; i++) {
                Console.WriteLine($"{i + 1}.- {options[i]}");
            }

            while (option < 1 || option > options.Count) {
                if (!int.TryParse(Console.ReadLine(), out option)) {
                    Console.WriteLine("Invalid option");
                }
            }

            return options[option - 1];
        }
    }
}