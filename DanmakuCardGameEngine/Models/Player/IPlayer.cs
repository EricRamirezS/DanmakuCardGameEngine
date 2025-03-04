using System;
using System.Collections.Generic;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IPlayer : IReadOnlyPlayer, IEquatable<IReadOnlyPlayer> {
        new string Id { get; }
        new string Name { get; set; }
        new int Life { get; set; }
        new bool IsSpellCardUsed { get; set; }
        new bool IsDefeated { get; set; }
        new int DanmakuEffectiveCount { get; set; }
        new int DanmakuCount { get; set; }
        new int DanmakuLimit { get; }
        new ICharacterCard MainCharacterCard { get; set; }
        new IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
        new bool IsRoleRevealed { get; set; }
        new IRoleCard RoleCard { get; set; }
        new int Range { get; }
        new int DistanceBonus { get; }
        
        void DrawCard(IDeck<ICard> deck);
        void PlayCard(ICard card);
        void Attack(IReadOnlyPlayer player);
        void TakeDamage(int damage);
        object MakeChoice(params object[] choices);
        void ChooseCharacter(IList<ICharacterCard> characters);

        void InitStats(IDefaultData defaultData);

        IReadOnlyPlayer ToReadOnlyPlayer();
    }
}