using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player.Components;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IPlayer : IReadOnlyPlayer, IDecisionMaker {
        new string Id { get; }
        new string Name { get; set; }
        new int Life { get; set; }
        new bool IsSpellCardUsed { get; set; }
        new bool IsDefeated { get; set; }
        new int DanmakuEffectiveCount { get; set; }
        new int DanmakuCount { get; set; }
        new int DanmakuLimit { get; }
        new bool IsRoleRevealed { get; set; }
        new IHand Hand { get; }
        new ICharacterCard MainCharacterCard { get; set; }
        new IReadOnlyList<ICharacterCard> ExtraCharacterCards { get; }
        new IRoleCard RoleCard { get; set; }
        new int Range { get; }
        new int DistanceBonus { get; }
        
        IDefaultData DefaultData { get; set; }

        Task DrawCard<TCard>(IDeck<TCard> deck) where TCard : ICard;
        Task DrawCards<TCard>(IDeck<TCard> deck, int quantity) where TCard : ICard;
        Task PlayCard(ICard card);
        Task Attack(IReadOnlyPlayer player);
        Task TakeDamage(int damage);
        Task ChooseCharacter(IList<ICharacterCard> characters);

        void InitStats();

        IReadOnlyPlayer ToReadOnlyPlayer();
    }
    
    public interface IDecisionMaker {
        Task<T> ChooseAsync<T>(IReadOnlyList<T> options, IReadOnlyGameState gameState);
    }
}