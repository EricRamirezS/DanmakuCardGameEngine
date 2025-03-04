using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Commons;

namespace DanmakuCardGameEngine.Models.Player {
    public partial class Player {
        private int GetMaxLife(IReadOnlyGameState gameState) {
            IModifierData data;
            int maxLife = _defaultData?.MaxLife ?? 0;
            if (IsRoleRevealed) {
                if (RoleCard.Modifiers.TryGetValue(ModifierNames.MaxLife, out data)) {
                    if (data.Duration == Durations.Active) {
                        maxLife += data.Value;
                    }
                }
            }

            if (MainCharacterCard.Modifiers.TryGetValue(ModifierNames.MaxLife, out data)) {
                maxLife += data.Value;
            }
            return maxLife;
        }

        private int GetDanmakuLimit(IReadOnlyGameState gameState) {
            throw new System.NotImplementedException();
        }

        private int GetRange(IReadOnlyGameState gameState) {
            throw new System.NotImplementedException();
        }

        private int GetDistanceBonus(IReadOnlyGameState gameState) {
            throw new System.NotImplementedException();
        }
    }
}