using System.Linq;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Type;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Player {
    public partial class Player {
        /// <summary>
        /// Calculates the player's maximum life by summing their default maximum life
        /// and any active modifiers that affect maximum life.
        /// </summary>
        /// <returns>The calculated maximum life as a byte.</returns>
        private byte GetMaxLife() => (byte)(DefaultData.MaxLife + GetModifierValue(ModifierNames.MaxLife));

        /// <summary>
        /// Calculates the player's danmaku limit by summing their default danmaku limit
        /// and any active modifiers that provide additional danmaku capacity.
        /// </summary>
        /// <returns>The calculated danmaku limit as a byte.</returns>
        private byte GetDanmakuLimit() => (byte)(DefaultData.DanmakuLimit + GetModifierValue(ModifierNames.AdditionalDanmaku));

        /// <summary>
        /// Calculates the player's current attack range by summing their default range
        /// and any active modifiers that affect range.
        /// </summary>
        /// <returns>The calculated range as a byte.</returns>
        private byte GetRange() => (byte)(DefaultData.Range + GetModifierValue(ModifierNames.Range));

        /// <summary>
        /// Calculates the player's distance bonus by summing any active modifiers that affect distance.
        /// </summary>
        /// <returns>The calculated distance bonus as a byte.</returns>
        private byte GetDistanceBonus() => GetModifierValue(ModifierNames.Distance);

        /// <summary>
        /// Calculates the player's maximum hand size by summing their default maximum hand size
        /// and any active modifiers that affect maximum hand size.
        /// </summary>
        /// <returns>The calculated maximum hand size as a byte.</returns>
        private byte GetMaxHandSize() => (byte)(DefaultData.MaxHandSize + GetModifierValue(ModifierNames.MaxHand));

        /// <summary>
        /// Retrieves the combined value of all active modifiers for a specific modifier name.
        /// If no modifiers are found for the given name, or if the Modifiers collection is null, returns 0.
        /// </summary>
        /// <param name="modifierName">The name of the modifier to get the value for.</param>
        /// <returns>The total value of active modifiers for the specified name as a byte.</returns>
        private byte GetModifierValue(IModifierName modifierName) =>
            (byte?)Modifiers?.GetActiveModifiersByName(modifierName).Sum(data => data.Value) ?? 0;

        /// <summary>
        /// Gathers and combines all active modifiers affecting the player from various sources.
        /// Modifiers are collected from the player's revealed role card, main character card, and equipped item cards.
        /// </summary>
        /// <returns>An <see cref="IModifiers"/> object containing all active modifiers.</returns>
        private IModifiers GetModifiers() {
            Modifiers modifiers = DanmakuCardGameEngine.Models.Commons.Modifiers.Empty;
            if (IsRoleRevealed) {
                modifiers.AddRange(RoleCard.Modifiers);
            }
            if (MainCharacterCard != null) {
                modifiers.AddRange(MainCharacterCard.Modifiers);
            }
            foreach (IItemCard itemCard in ItemField) {
                modifiers.AddRange(itemCard.Modifiers);
            }
            return modifiers;
        }
    }
}