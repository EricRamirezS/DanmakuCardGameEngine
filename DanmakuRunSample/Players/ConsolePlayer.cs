using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
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
        
        public override async Task<ICharacterCard> ChooseCharacter(IList<ICharacterCard> characters) {
            Console.Clear();
            Console.WriteLine(GameCore.Instance.GameState);
            ICharacterCard characterCard = await ChooseAsync(characters.ToList().AsReadOnly(), GameCore.Instance.GameState);
            return characterCard;
        }
        
        public override Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState) {
            int option = 0;
            for (int i = 0; i < options.Count; i++) {
                Console.WriteLine($"{i + 1}.- {options[i]}");
            }

            while (option < 1 || option > options.Count) {
                if (!int.TryParse(Console.ReadLine(), out option)) {
                    Console.WriteLine("Invalid option");
                }
            }

            return Task.FromResult(options[option - 1]);
        }
    }
}