using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Player.Components;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Player {
    public class ReadOnlyPlayer : EquatablePlayer, IReadOnlyPlayer {
        public override string Id { get; }
        public override string Name { get; }
        public override bool HasCharacter(ICharacterCard card) {
            return card == MainCharacterCard;
        }

        public byte Life { get; }
        public byte MaxLife { get; }
        public bool IsDefeated { get; }
        public byte MaxHandSize { get; }
        public bool IsSpellCardUsed { get; }
        public byte DanmakuEffectiveCount { get; }
        public byte DanmakuCount { get; }
        public byte DanmakuLimit { get; }
        public byte Range { get; }
        public byte DistanceBonus { get; }
        public bool IsRoleRevealed { get; }
        public IReadOnlyHand Hand { get; }
        public IRoleCard RoleCard { get; }
        public IItemField ItemField { get; }
        public ICharacterCard MainCharacterCard { get; }
        public IModifiers Modifiers { get; }

        public ReadOnlyPlayer(IPlayer player) {
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
            IsRoleRevealed = player.IsRoleRevealed;
            if (IsRoleRevealed) {
                RoleCard = player.RoleCard;
            }

            ItemField = player.ItemField;
            Range = player.Range;
            DistanceBonus = player.DistanceBonus;
            Modifiers = player.Modifiers;
            Hand = player.Hand.ToReadOnly();
        }


        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}