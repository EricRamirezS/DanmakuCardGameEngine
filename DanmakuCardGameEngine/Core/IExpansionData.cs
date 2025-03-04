using System.Collections.Generic;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuCardGameEngine.Core {
    public interface IExpansionData : INamedObject {
        IRoleDeck RoleDeck { get; }
        IMainDeck MainDeck { get; }
        ICharacterDeck CharacterDeck { get; }
        IIncidentDeck IncidentDeck { get; }

        Expansion Expansion { get; }

        void RegisterOtherDecks(IDecksManager decksManager);
    }
}