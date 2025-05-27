using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Commons {
    /// <summary>
    /// Defines an interface for data representing a single modifier that can affect game entities.
    /// It includes properties for the modifier's name, value, duration, and its source,
    /// along with a method to check its validity.
    /// </summary>
    public interface IModifierData {
        /// <summary>
        /// Gets the name of the modifier, identifying its type and effect.
        /// </summary>
        IModifierName ModifierName { get; }
        /// <summary>
        /// Gets the integer value of the modifier, representing the magnitude of its effect.
        /// </summary>
        int Value { get; }
        /// <summary>
        /// Gets the duration of the modifier, indicating how long it remains active.
        /// </summary>
        IDuration Duration { get; }
        /// <summary>
        /// Gets the source object from which this modifier originated (e.g., a card, an ability).
        /// This property is ignored during JSON serialization.
        /// </summary>
        [JsonIgnore] object Source { get; }

        /// <summary>
        /// Determines whether the modifier is currently valid and active based on its duration and game state.
        /// </summary>
        /// <returns><c>true</c> if the modifier is valid and active; otherwise, <c>false</c>.</returns>
        bool IsValid();
    }

    /// <summary>
    /// Implements the <see cref="IModifierData"/> interface, representing a concrete modifier with
    /// properties for its name, value, duration, and source. It also manages its activation state
    /// to determine validity based on game rounds and turns.
    /// </summary>
    public class ModifierData : IModifierData {
        /// <inheritdoc />
        public IModifierName ModifierName { get; }
        /// <inheritdoc />
        public int Value { get; }
        /// <inheritdoc />
        public IDuration Duration { get; }
        /// <inheritdoc />
        public object Source { get; }

        private int _activatedRound;
        private int _activatedTurn;
        private bool _activated;

        /// <summary>
        /// Gets or sets a value indicating whether this modifier has been activated.
        /// Setting this property records the current game round and turn numbers,
        /// which are used to determine the modifier's validity for duration-based effects.
        /// </summary>
        private bool Activated
        {
            get => _activated;
            set
            {
                _activatedRound = GameCore.Instance.GameState.CurrentRoundNumber;
                _activatedTurn = GameCore.Instance.GameState.CurrentTurnNumber;
                _activated = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierData"/> class.
        /// </summary>
        /// <param name="modifierName">The name of the modifier.</param>
        /// <param name="source">The source object from which this modifier originated.</param>
        /// <param name="value">The integer value of the modifier.</param>
        /// <param name="duration">The duration of the modifier.</param>
        public ModifierData(IModifierName modifierName, object source, int value, IDuration duration) {
            ModifierName = modifierName;
            Value = value;
            Duration = duration;
            Source = source;
        }

        /// <inheritdoc />
        /// <remarks>
        /// This method determines validity based on the <see cref="Duration"/> property:
        /// <list type="bullet">
        /// <item><term><see cref="Durations.Active"/></term><description>Always valid.</description></item>
        /// <item><term><see cref="Durations.Turn"/></term><description>Valid only if activated in the current turn.</description></item>
        /// <item><term><see cref="Durations.Round"/></term><description>Valid only if activated in the current round.</description></item>
        /// </list>
        /// If the modifier has not been activated, it is considered invalid unless its duration is <see cref="Durations.Active"/>.
        /// </remarks>
        public virtual bool IsValid() {
            if (Duration == Durations.Active) {
                return true;
            }

            if (!Activated) return false; // If not activated, it cannot be valid for turn/round durations

            if (Duration == Durations.Turn) {
                return _activatedTurn == GameCore.Instance.GameState.CurrentTurnNumber;
            }

            if (Duration == Durations.Round) {
                return _activatedRound == GameCore.Instance.GameState.CurrentRoundNumber;
            }

            return false; // Should not reach here for defined durations
        }

        /// <summary>
        /// Creates and returns a new <see cref="ModifierData"/> instance identical to this one,
        /// but with its <see cref="Activated"/> status set to <c>true</c>.
        /// This effectively "applies" the modifier for tracking its duration.
        /// </summary>
        /// <returns>A new <see cref="ModifierData"/> instance with its <see cref="Activated"/> flag set to <c>true</c>.</returns>
        public ModifierData Apply() {
            ModifierData data = new ModifierData(ModifierName, Source, Value, Duration) {
                Activated = true,
            };
            return data;
        }
    }

    /// <summary>
    /// Defines an interface for a collection of <see cref="IModifierData"/> objects,
    /// providing methods to retrieve modifiers by their name, specifically focusing on active ones.
    /// It extends <see cref="IList{T}"/> to allow list-like operations.
    /// </summary>
    public interface IModifiers : IList<IModifierData> {
        /// <summary>
        /// Retrieves all modifier data entries that match the specified modifier name, regardless of their validity.
        /// </summary>
        /// <param name="modifierName">The name of the modifier to search for.</param>
        /// <returns>A list of <see cref="IModifierData"/> objects matching the name.</returns>
        IList<IModifierData> GetModifiersByName(IModifierName modifierName);
        /// <summary>
        /// Retrieves only the active (valid) modifier data entries that match the specified modifier name.
        /// </summary>
        /// <param name="modifierName">The name of the modifier to search for.</param>
        /// <returns>A list of active <see cref="IModifierData"/> objects matching the name.</returns>
        IList<IModifierData> GetActiveModifiersByName(IModifierName modifierName);
    }

    /// <summary>
    /// Implements the <see cref="IModifiers"/> interface, providing a concrete collection of
    /// <see cref="IModifierData"/> objects. It extends <see cref="List{T}"/> to manage the
    /// collection and includes methods for filtering modifiers by name and validity.
    /// </summary>
    public class Modifiers : List<IModifierData>, IModifiers {
        /// <summary>
        /// Gets a static read-only empty instance of <see cref="Modifiers"/>.
        /// This can be used to represent a state with no modifiers without creating new objects.
        /// </summary>
        public static Modifiers Empty => new Modifiers();

        /// <inheritdoc />
        public IList<IModifierData> GetModifiersByName(IModifierName modifierName) {
            return FindAll(e => e.ModifierName == modifierName).ToList();
        }

        /// <inheritdoc />
        public IList<IModifierData> GetActiveModifiersByName(IModifierName modifierName) {
            return FindAll(e => e.ModifierName == modifierName && e.IsValid()).ToList();
        }
    }
}
