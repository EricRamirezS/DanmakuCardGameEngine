using System;
using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class ConsolePlayer : Player {
        public ConsolePlayer(string name) : base(name) { }

        public override void DrawCard(IDeck<ICard> deck) {
            throw new System.NotImplementedException();
        }

        public override void PlayCard(ICard card) {
            throw new System.NotImplementedException();
        }

        public override void Attack(IReadOnlyPlayer player) {
            throw new System.NotImplementedException();
        }

        public override void TakeDamage(int damage) {
            throw new System.NotImplementedException();
        }

        public override object MakeChoice(params object[] choices) {
            int option = 0;
            for (int i = 0; i < choices.Length; i++) {
                Console.WriteLine($"{i + 1}.- {choices[i]}");
            }

            while (option < 1 || option > choices.Length) {
                if (!int.TryParse(Console.ReadLine(), out option)) {
                    Console.WriteLine("Invalid option");
                }
            }

            return choices[option - 1];
        }

        public override void ChooseCharacter(IList<ICharacterCard> characters) {
            MainCharacterCard = (ICharacterCard)MakeChoice(characters.ToArray());
        }
    }
}