using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuRunSample.Players {
    public class ConsolePlayer : Player {
        public ConsolePlayer(ICharacterCard character, IRoleCard role) : base(character, role) { }

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
            throw new System.NotImplementedException();
        }
    }
}