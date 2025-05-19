using System;
using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using Newtonsoft.Json;

namespace DanmakuCardGameEngine.Models.Commons {
    public interface IModifierData {
        IModifierName ModifierName { get; }
        int Value { get; }
        IDuration Duration { get; }
        [JsonIgnore] object Source { get; }

        bool IsValid();
    }

    public class ModifierData : IModifierData {

        public IModifierName ModifierName { get; }
        public int Value { get; }
        public IDuration Duration { get; }
        public object Source { get; }

        private int _activatedRound;
        private int _activatedTurn;
        private bool _activated;

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

        public ModifierData(IModifierName modifierName, object source, int value, IDuration duration) {
            ModifierName = modifierName;
            Value = value;
            Duration = duration;
            Source = source;
        }

        public virtual bool IsValid() {

            if (Duration == Durations.Active) {
                return true;
            }

            if (!Activated) return false;
            if (Duration == Durations.Turn) {
                return _activatedTurn == GameCore.Instance.GameState.CurrentTurnNumber;
            }


            if (Duration == Durations.Round) {
                return _activatedRound == GameCore.Instance.GameState.CurrentRoundNumber;
            }

            return false;
        }

        public ModifierData Apply() {
            ModifierData data = new ModifierData(ModifierName, Source, Value, Duration) {
                Activated = true
            };
            return data;
        }
    }

    public interface IModifiers : IList<IModifierData> {
        IList<IModifierData> GetModifiersByName(IModifierName modifierName);
        IList<IModifierData> GetActiveModifiersByName(IModifierName modifierName);
    }

    public class Modifiers : List<IModifierData>, IModifiers {
        public static Modifiers Empty => new Modifiers();

        public IList<IModifierData> GetModifiersByName(IModifierName modifierName) {
            return FindAll(e => e.ModifierName == modifierName).ToList();
        }

        public IList<IModifierData> GetActiveModifiersByName(IModifierName modifierName) {
            return FindAll(e => e.ModifierName == modifierName && e.IsValid()).ToList();
        }
    }
}