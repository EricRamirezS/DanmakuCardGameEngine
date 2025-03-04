using System.Collections.Generic;
using System.Linq;
using DanmakuCardGameEngine.Enums;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Game;
using DanmakuCardGameEngine.Models.Cards;
using DanmakuCardGameEngine.Models.Deck;
using DanmakuCardGameEngine.Models.Player;

namespace DanmakuCardGameEngine.Core {
    public partial class GameCore {
        private readonly IExpansionData[] _expansions;
        private readonly IDefaultData _defaultData;

        public IList<IState> GamePhases { get; }
        public IReadOnlyGameState GameState => _gameState.AsReadOnly();
        private readonly IGameState _gameState = new GameState();

        private GameCore(IList<IPlayer> players, IExpansionData[] expansions, IDefaultData defaultData) {
            _expansions = expansions;
            _defaultData = defaultData;
            _gameState.State = States.InitialSetup;
            GamePhases = new List<IState>();
            _gameState.DeckManager = new DecksManager();
            _gameState.Players = players;
        }

        internal void Init() {
            SetUpDecks(_expansions);
            RunValidations();
            ShuffleDecks();
            DealRoles();
            AssignCharacter();
            InitializeStats();
        }

        private void SetUpDecks(IExpansionData[] expansions) {
            _gameState.State = States.SetUpDecks;
            foreach (IExpansionData expansion in expansions) {
                RegisterOrUpdateDeck((MainDeck)expansion.MainDeck);
                RegisterOrUpdateDeck((IncidentDeck)expansion.IncidentDeck);
                RegisterOrUpdateDeck((RoleDeck)expansion.RoleDeck);
                RegisterOrUpdateDeck((CharacterDeck)expansion.CharacterDeck);

                expansion.RegisterOtherDecks(_gameState.DeckManager);
            }
        }

        private void RunValidations() {
            GameValidator.ValidateNumberOfPlayers(_gameState.Players.Count);
            GameValidator.ValidateRoles(_gameState.DeckManager.GetDeck<IRoleCard>(), _gameState.Players.Count);
        }

        private void ShuffleDecks() {
            _gameState.DeckManager.ShuffleAllDecks();
        }


        private void DealRoles() {
            _gameState.State = States.DetermineRoles;
            Deck<IRoleCard> fullDeck = _gameState.DeckManager.GetDeck<IRoleCard>();
            IList<IRoleCard> usableDeck = fullDeck.Where(c => c.RequiredPlayers <= _gameState.Players.Count).ToList();
            IReadOnlyDictionary<IRoleType, int> requiredRoles =
                GameValidator._roleDistribution[_gameState.Players.Count];
            RoleDeck tempDeck = new RoleDeck();

            tempDeck.AddRange(usableDeck.Where(c => c.RoleType == RoleTypes.Heroine)
                .Take(requiredRoles[RoleTypes.Heroine]));
            tempDeck.AddRange(usableDeck.Where(c => c.RoleType == RoleTypes.Partner)
                .Take(requiredRoles[RoleTypes.Partner]));
            tempDeck.AddRange(usableDeck.Where(c => c.RoleType == RoleTypes.StageBoss)
                .Take(requiredRoles[RoleTypes.StageBoss]));
            tempDeck.AddRange(usableDeck.Where(c => c.RoleType == RoleTypes.ExtraBoss)
                .Take(requiredRoles[RoleTypes.ExtraBoss]));

            tempDeck.Shuffle();

            foreach (IPlayer player in _gameState.Players) {
                player.RoleCard = tempDeck.Draw();
            }
        }

        private void AssignCharacter() {
            _gameState.State = States.AssignCharacter;
            Deck<ICharacterCard> deck = _gameState.DeckManager.GetDeck<ICharacterCard>();
            int i = 0;
            foreach (IPlayer player in _gameState.Players) {
                player.ChooseCharacter(deck.Skip(i++ * 2).Take(2).ToList());
            }
        }

        private void RegisterOrUpdateDeck<TCard>(Deck<TCard> deck) where TCard : ICard {
            if (deck == null) return;
            if (_gameState.DeckManager.ContainsDeck<TCard>()) _gameState.DeckManager.AddToDeck(deck);
            else _gameState.DeckManager.RegisterDeck(deck);
        }


        private void InitializeStats() {
            foreach (IPlayer player in _gameState.Players) {
                player.InitStats(_defaultData);
            }
        }
    }
}