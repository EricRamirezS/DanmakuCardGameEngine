using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {
    public abstract partial class Player : EquatablePlayer, IPlayer {
        protected Player(string name) {
            Id = Guid.NewGuid().ToString();
            Name = name;
            MainCharacterCard = null;
            RoleCard = null;
            ItemField = new ItemField(this);
            IsRoleRevealed = false;
            Life = 4;
            IsSpellCardUsed = false;
            IsDefeated = false;
            DanmakuEffectiveCount = 0;
            DanmakuCount = 0;
            Hand = new Hand(this);
        }

        public override string Id { get; }
        public override string Name { get; }
        public int Life { get; set; }
        public int MaxLife => GetMaxLife();
        public int MaxHandSize => GetMaxHandSize();

        public bool IsSpellCardUsed { get; set; }
        public bool IsDefeated { get; set; }
        public int DanmakuEffectiveCount { get; set; }
        public int DanmakuCount { get; set; }
        public int DanmakuLimit => GetDanmakuLimit();
        public bool IsRoleRevealed { get; set; }
        public int Range => GetRange();
        public int DistanceBonus => GetDistanceBonus();
        public IHand Hand { get; }
        public ICharacterCard MainCharacterCard { get; set; }
        public IRoleCard RoleCard { get; set; }
        public IItemField ItemField { get; }
        public IModifiers Modifiers => GetModifiers();

        public async Task DrawCards<TCard>(int quantity) where TCard : IHandCard {
            await GameCore.Instance.DrawCards<TCard>(this, quantity);
        }

        public abstract Task PlayCard(ICard card);
        public abstract Task Attack(IReadOnlyPlayer player);
        public abstract Task TakeDamage(int damage);
        public abstract Task<ICharacterCard> ChooseCharacter(IList<ICharacterCard> characterCards);
        public abstract Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);

        [JsonIgnore] public IDefaultData DefaultData { get; set; }

        public void InitStats() {

            if (RoleCard.Id == 1 && RoleCard.Name == "Heroine" &&
                RoleCard.RoleType == RoleTypes.Heroine) {
                RevealRole();
            }

            Life = MaxLife;
            IsSpellCardUsed = false;
            IsDefeated = false;
        }
        private void RevealRole() {
            IsRoleRevealed = true;
        }

        public IReadOnlyPlayer ToReadOnly() {
            return new ReadOnlyPlayer(this);
        }

        public override bool HasCharacter(ICharacterCard card) {
            return MainCharacterCard == card;
        }

        public bool Equals(IReadOnlyPlayer other) {
            return base.Equals(other);
        }
        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
        public static bool operator ==(Player left, IReadOnlyPlayer right) {
            return AreEquals(left, right);
        }
        public static bool operator !=(Player left, IReadOnlyPlayer right) {
            return !AreEquals(left, right);
        }
        public static bool operator ==(IReadOnlyPlayer left, Player right) {
            return AreEquals(left, right);
        }
        public static bool operator !=(IReadOnlyPlayer left, Player right) {
            return !AreEquals(left, right);
        }
    }
}