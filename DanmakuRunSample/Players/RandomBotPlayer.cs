using System;
using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class RandomBotPlayer : Player {
        public RandomBotPlayer(string name) : base(name) { }

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
            Random random = new Random();
            return choices[random.Next(0, choices.Length)];
        }

        public override void ChooseCharacter(IList<ICharacterCard> characters) {
            MainCharacterCard = (ICharacterCard)MakeChoice(characters.ToArray());
        }
    }
}