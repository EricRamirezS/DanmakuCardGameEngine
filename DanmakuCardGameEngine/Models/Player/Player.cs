using System;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {
    public partial class Player : IPlayer {
        public Player(ICharacterCard character, IRoleCard role) {
            Id = Guid.NewGuid().ToString();
            Name = character.Name;
            CharacterCard = character;
            RoleCard = role;
            IsRoleRevealed = false;
            ItemField = new ItemField(this);
            Life = 4;
            MaxLife = 4;
            IsSpellCardUsed = false;
            IsDefeated = false;
            DanmakuEffectiveCount = 0;
            DanmakuCount = 0;
            DanmakuLimit = 1;
            Range = 1;
            DistanceBonus = 0;
        }

        public string Id { get; }
        public string Name { get; }
        public int Life { get; }
        public int MaxLife { get; }
        public bool IsSpellCardUsed { get; }
        public bool IsDefeated { get; }
        public int DanmakuEffectiveCount { get; }
        public int DanmakuCount { get; }
        public int DanmakuLimit { get; }
        public ICharacterCard CharacterCard { get; }
        public bool IsRoleRevealed { get; }
        public IRoleCard RoleCard { get; }
        public IItemField ItemField { get; }
        public int Range { get; }
        public int DistanceBonus { get; }


        public bool Equals(IReadOnlyPlayer other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}