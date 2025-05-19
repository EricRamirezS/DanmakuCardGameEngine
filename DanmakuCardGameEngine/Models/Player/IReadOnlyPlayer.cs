using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {

    public interface IComparablePlayer : IComparable<IComparablePlayer> {
        string Id { get; }
        string Name { get; }
        ICharacterCard MainCharacterCard { get; }
        IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
    }

    public interface IReadOnlyPlayer : IComparablePlayer {
        int Life { get; }
        int MaxLife { get; }
        bool IsDefeated { get; }
        int MaxHandSize { get; }
        bool IsSpellCardUsed { get; }
        int DanmakuEffectiveCount { get; }
        int DanmakuCount { get; }
        int DanmakuLimit { get; }
        int Range { get; }
        int DistanceBonus { get; }
        bool IsRoleRevealed { get; }
        IReadOnlyHand Hand { get; }
        IRoleCard RoleCard { get; }
        IItemField ItemField { get; }
        IModifiers Modifiers { get; }
    }

    public class ComparablePlayer : IComparablePlayer, IComparable<IComparablePlayer>, IComparable<ComparablePlayer>, IComparable {
        public string Id { get; }
        public string Name { get; }
        public ICharacterCard MainCharacterCard { get; }
        public IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }

        public int CompareTo(ComparablePlayer other) {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            int idComparison = string.Compare(Id, other.Id, StringComparison.Ordinal);
            if (idComparison != 0) return idComparison;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
        public int CompareTo(object obj) {
            if (obj is null) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is ComparablePlayer other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ComparablePlayer)}");
        }
        public static bool operator <(ComparablePlayer left, ComparablePlayer right) {
            return Comparer<ComparablePlayer>.Default.Compare(left, right) < 0;
        }
        public static bool operator >(ComparablePlayer left, ComparablePlayer right) {
            return Comparer<ComparablePlayer>.Default.Compare(left, right) > 0;
        }
        public static bool operator <=(ComparablePlayer left, ComparablePlayer right) {
            return Comparer<ComparablePlayer>.Default.Compare(left, right) <= 0;
        }
        public static bool operator >=(ComparablePlayer left, ComparablePlayer right) {
            return Comparer<ComparablePlayer>.Default.Compare(left, right) >= 0;
        }
        public int CompareTo(IComparablePlayer obj) {
            if (obj is null) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is ComparablePlayer other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ComparablePlayer)}");
        }
    }

    public class ReadOnlyPlayer : ComparablePlayer, IReadOnlyPlayer {
        public string Id { get; }
        public string Name { get; }
        public int Life { get; }
        public int MaxLife { get; }
        public bool IsDefeated { get; }
        public int MaxHandSize { get; }
        public bool IsSpellCardUsed { get; }
        public int DanmakuEffectiveCount { get; }
        public int DanmakuCount { get; }
        public int DanmakuLimit { get; }
        public int Range { get; }
        public int DistanceBonus { get; }
        public bool IsRoleRevealed { get; }
        public IReadOnlyHand Hand { get; }
        public IRoleCard RoleCard { get; }
        public IItemField ItemField { get; }
        public ICharacterCard MainCharacterCard { get; }
        public IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
        public IModifiers Modifiers { get; }
        
        public ReadOnlyPlayer(Player player) {
            Id = player.Id;
            Name = player.Name;
            Life = player.Life;
            MaxLife = player.MaxLife;
            MaxHandSize = player.MaxHandSize;
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
            Hand = player.Hand.ToReadOnlyHand();
        }


        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}