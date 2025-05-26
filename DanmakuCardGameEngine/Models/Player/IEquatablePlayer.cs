using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IEquatablePlayer : IEquatable<IEquatablePlayer>, IEqualityComparer<IEquatablePlayer> {
        string Id { get; }
        string Name { get; }

        bool HasCharacter(ICharacterCard card);
    }
}