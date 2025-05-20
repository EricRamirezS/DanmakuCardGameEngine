using System;
using DanmakuCardGameEngine.Models.Cards;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IEquatablePlayer : IEquatable<IEquatablePlayer> {
        string Id { get; }
        string Name { get; }

        bool HasCharacter(ICharacterCard card);
    }
}