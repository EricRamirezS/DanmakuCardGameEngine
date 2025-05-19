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
    public abstract partial class Player : ComparablePlayer, IPlayer {
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

        public string Id { get; }
        public string Name { get; set; }
        public int Life { get; set; }
        public int MaxLife => GetMaxLife();
        public int MaxHandSize => GetMaxHandSize();

        public bool IsSpellCardUsed { get; set; }
        public bool IsDefeated { get; set; }
        public int DanmakuEffectiveCount { get; set; }
        public int DanmakuCount { get; set; }
        public int DanmakuLimit => GetDanmakuLimit();
        public bool IsRoleRevealed { get; set; }
        IReadOnlyHand IReadOnlyPlayer.Hand => Hand;
        public int Range => GetRange();
        public int DistanceBonus => GetDistanceBonus();
        public IHand Hand { get; }
        public ICharacterCard MainCharacterCard { get; set; }
        private List<ICharacterCard> _extraCharacterCards = new List<ICharacterCard>();
        public IReadOnlyList<ICharacterCard> ExtraCharacterCards => _extraCharacterCards.AsReadOnly();
        public IRoleCard RoleCard { get; set; }
        public IItemField ItemField { get; set; }
        public IModifiers Modifiers => GetModifiers();

        public abstract Task DrawCard<TCard>(IDeck<TCard> deck) where TCard : ICard;
        public abstract Task DrawCards<TCard>(IDeck<TCard> deck, int quantity) where TCard : ICard;
        public abstract Task PlayCard(ICard card);
        public abstract Task Attack(IReadOnlyPlayer player);
        public abstract Task TakeDamage(int damage);
        public abstract Task ChooseCharacter(IList<ICharacterCard> characterCards);

        [JsonIgnore]
        public IDefaultData DefaultData { get; set; }
        
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

        public IReadOnlyPlayer ToReadOnlyPlayer() {
            return new ReadOnlyPlayer(this);
        }
        public abstract Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);
    }
}