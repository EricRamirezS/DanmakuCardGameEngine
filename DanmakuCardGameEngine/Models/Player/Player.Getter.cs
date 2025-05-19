using System;
using System.Linq;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Player {
    public partial class Player {
        private int GetMaxLife() => DefaultData.MaxLife + GetModifierValue(ModifierNames.MaxLife);
        private int GetDanmakuLimit() => DefaultData.DanmakuLimit + GetModifierValue(ModifierNames.AdditionalDanmaku);
        private int GetRange() => DefaultData.Range + GetModifierValue(ModifierNames.Range);
        private int GetDistanceBonus() => GetModifierValue(ModifierNames.Distance);
        private int GetMaxHandSize() => DefaultData.MaxHandSize + GetModifierValue(ModifierNames.MaxHand);

        private int GetModifierValue(IModifierName modifierName) => Modifiers?.GetActiveModifiersByName(modifierName).Sum(data => data.Value) ?? 0;

        private IModifiers GetModifiers() {
            Modifiers modifiers = DanmakuCardGameEngine.Models.Commons.Modifiers.Empty;
            if (IsRoleRevealed) {
                modifiers.AddRange(RoleCard.Modifiers);
            }
            if (MainCharacterCard != null) {
                modifiers.AddRange(MainCharacterCard.Modifiers);
            }
            foreach (ICharacterCard extraCharacterCard in _extraCharacterCards) {
                modifiers.AddRange(extraCharacterCard.Modifiers);
            }
            foreach (IItemCard itemCard in ItemField) {
                modifiers.AddRange(itemCard.Modifiers);
            }
            return modifiers;
        }
    }
}