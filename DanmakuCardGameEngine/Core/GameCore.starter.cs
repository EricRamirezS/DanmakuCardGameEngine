using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEventManager EventManager { get; }
        private readonly IGameState _gameState;
        private bool _initialized = false;
        private readonly IList<IPlayer> _players;
        public IList<IComparablePlayer> Players => _gameState.Players.Cast<IComparablePlayer>().ToList();

        public IComparablePlayer PlayerInTurn => _gameState.PlayerInTurn;
        public IState CurrentPhase => _gameState.State;
        private GameCore(IList<IPlayer> players, IExpansionData[] expansions, IDefaultData defaultData) {
            EventManager = new EventManager();
            _expansions = expansions;
            _defaultData = defaultData;
            _gameState = new GameState(this);
            GamePhases = new List<IState>();
            _gameState.DeckManager = new DecksManager();
            _players = players;
            foreach (IPlayer player in players) {
                player.DefaultData = _defaultData;
            }
        }

        public async Task Init() {
            if (_initialized) {
                throw new Exception("Game is already initialized");
            }
            _gameState.State = States.InitialSetup;
            SetUpDecks(_expansions);
            RunValidations();
            ShuffleDecks();
            _gameState.Players = _players;
            DealRoles();
            await AssignCharacter();
            InitializeStats();
            SetUpTurns();
            DealInitialHand();
            _gameState.State = States.StartOfTheGame;
            _initialized = true;
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
            GameValidator.ValidateNumberOfPlayers(_players.Count);
            GameValidator.ValidateRoles(_gameState.DeckManager.GetDeck<IRoleCard>(), _players.Count);
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

        private async Task AssignCharacter() {
            _gameState.State = States.AssignCharacter;
            Deck<ICharacterCard> deck = _gameState.DeckManager.GetDeck<ICharacterCard>();

            int i = 0;

            List<Task> tasks = (from player in _gameState.Players
                let characterOptions = deck.Skip(i++ * 2).Take(2).ToList()
                select player.ChooseCharacter(characterOptions)).ToList();

            await Task.WhenAll(tasks);
        }

        private void RegisterOrUpdateDeck<TCard>(Deck<TCard> deck) where TCard : ICard {
            if (deck == null) return;
            if (_gameState.DeckManager.ContainsDeck<TCard>()) _gameState.DeckManager.AddToDeck(deck);
            else _gameState.DeckManager.RegisterDeck(deck);
        }


        private void InitializeStats() {
            _gameState.State = States.InitializeStats;

            foreach (IPlayer player in _gameState.Players) {
                player.InitStats();
            }
        }

        private void SetUpTurns() {
            int offset = 0;
            foreach (IPlayer player in _gameState.Players) {
                if (player.IsRoleRevealed) {
                    _gameState.PlayerInTurn = player;
                    _gameState.TurnOffSet = offset;
                    break;
                }
                offset++;
            }
        }

        private void DealInitialHand() {
            _gameState.State = States.DealInitialHand;
            int count = _gameState.Players.Count;
            for (int i = 0; i < _gameState.Players.Count(); i++) {
                IPlayer player = _gameState.Players[(i + _gameState.TurnOffSet) % count];
                Deck<IMainCard> mainCards = _gameState.DeckManager.GetDeck<IMainCard>();
                player.Hand.Cards.AddRange(mainCards.Draw(player.MaxHandSize + AdditionalCards(i)));
            }
        }

        private static int AdditionalCards(int i) {
            switch (i) {
                case 4:
                case 5:
                    return 1;
                case 6:
                case 7:
                    return 2;
                case 8:
                    return 3;
                default:
                    return 0;
            }
        }
    }
}