using System.Collections.Generic;
using System.Threading.Tasks;
using DanmakuCardGameEngine.Core;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Commons;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player.Components;
using DanmakuCardGameEngine.Tools;

namespace DanmakuCardGameEngine.Models.Player {
    public interface IPlayer : IDecisionMaker, IReadOnlyConverter<IReadOnlyPlayer>, IEquatablePlayer {
        int Life { get; set; }
        int MaxLife { get; }
        bool IsSpellCardUsed { get; set; }
        bool IsDefeated { get; set; }
        int DanmakuEffectiveCount { get; set; }
        int DanmakuCount { get; set; }
        int DanmakuLimit { get; }
        int MaxHandSize { get; }
        bool IsRoleRevealed { get; set; }
        int Range { get; }
        int DistanceBonus { get; }
        IHand Hand { get; }
        ICharacterCard MainCharacterCard { get; set; }
        IRoleCard RoleCard { get; set; }
        IItemField ItemField { get; }
        IModifiers Modifiers { get; }

        IDefaultData DefaultData { get; set; }

        Task DrawCard<TCard>(IDeck<TCard> deck) where TCard : ICard;
        Task DrawCards<TCard>(IDeck<TCard> deck, int quantity) where TCard : ICard;
        Task PlayCard(ICard card);
        Task Attack(IReadOnlyPlayer player);
        Task TakeDamage(int damage);
        Task ChooseCharacter(IList<ICharacterCard> characters);

        void InitStats();
    }

}