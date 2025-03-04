using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IReadOnlyPlayer {
        string Id { get; }
        string Name { get; }
        int Life { get; }
        int MaxLife { get; }
        bool IsSpellCardUsed { get; }
        bool IsDefeated { get; }
        int DanmakuEffectiveCount { get; }
        int DanmakuCount { get; }
        int DanmakuLimit { get; }
        ICharacterCard MainCharacterCard { get; }
        IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
        bool IsRoleRevealed { get; }
        IRoleCard RoleCard { get; }
        IItemField ItemField { get; }
        int Range { get; }
        int DistanceBonus { get; }
        IModifiers Modifiers { get; }
    }

    public class ReadOnlyPlayer : IReadOnlyPlayer {
        public string Id { get; }
        public string Name { get; }
        public int Life { get; }
        public int MaxLife { get; }
        public bool IsSpellCardUsed { get; }
        public bool IsDefeated { get; }
        public int DanmakuEffectiveCount { get; }
        public int DanmakuCount { get; }
        public int DanmakuLimit { get; }
        public ICharacterCard MainCharacterCard { get; }
        public IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
        public bool IsRoleRevealed { get; }
        public IRoleCard RoleCard { get; }
        public IItemField ItemField { get; }
        public int Range { get; }
        public int DistanceBonus { get; }
        public IModifiers Modifiers { get; }

        public ReadOnlyPlayer(IReadOnlyPlayer player) {
            Id = player.Id;
            Name = player.Name;
            Life = player.Life;
            MaxLife = player.MaxLife;
            IsSpellCardUsed = player.IsSpellCardUsed;
            IsDefeated = player.IsDefeated;
            DanmakuEffectiveCount = player.DanmakuEffectiveCount;
            DanmakuCount = player.DanmakuCount;
            DanmakuLimit = player.DanmakuLimit;
            MainCharacterCard = player.MainCharacterCard;
            ExtraCharacterCards = player.ExtraCharacterCards;
            IsRoleRevealed = player.IsRoleRevealed;
            if (IsRoleRevealed) {
                RoleCard = player.RoleCard;
            }

            ItemField = player.ItemField;
            Range = player.Range;
            DistanceBonus = player.DistanceBonus;
            Modifiers = player.Modifiers;
        }


        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}