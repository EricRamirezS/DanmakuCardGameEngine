using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {
    public abstract partial class Player : IPlayer {
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
            Modifiers = new Modifiers();
        }
        
        public string Id { get; }
        public string Name { get; set; }
        public int Life { get; set; }
        public int MaxLife => GetMaxLife(GameCore.Instance.GameState);
        
        public bool IsSpellCardUsed { get; set; }
        public bool IsDefeated { get; set; }
        public int DanmakuEffectiveCount { get; set; }
        public int DanmakuCount { get; set; }
        public int DanmakuLimit => GetDanmakuLimit(GameCore.Instance.GameState);
        public ICharacterCard MainCharacterCard { get; set; }
        private List<ICharacterCard> _extraCharacterCards = new List<ICharacterCard>();
        private IDefaultData _defaultData;
        public IReadOnlyList<ICharacterCard> ExtraCharacterCards => _extraCharacterCards.AsReadOnly();
        public bool IsRoleRevealed { get; set; }
        public IRoleCard RoleCard { get; set; }
        public IItemField ItemField { get; set; }
        public int Range => GetRange(GameCore.Instance.GameState);
        public int DistanceBonus => GetDistanceBonus(GameCore.Instance.GameState);
        public IModifiers Modifiers { get; }

        public abstract void DrawCard(IDeck<ICard> deck);
        public abstract void PlayCard(ICard card);
        public abstract void Attack(IReadOnlyPlayer player);
        public abstract void TakeDamage(int damage);
        public abstract object MakeChoice(params object[] choices);
        public abstract void ChooseCharacter(IList<ICharacterCard> characterCards);

        public void InitStats(IDefaultData defaultData) {
            _defaultData = defaultData;
            
            IsRoleRevealed = RoleCard.Id == 1 && RoleCard.Name == "Heroine" &&
                             RoleCard.RoleType == RoleTypes.Heroine;

            Life = MaxLife;
            IsSpellCardUsed = false;
            IsDefeated = false;
        }

        public IReadOnlyPlayer ToReadOnlyPlayer() {
            return new ReadOnlyPlayer(this);
        }
    }
}