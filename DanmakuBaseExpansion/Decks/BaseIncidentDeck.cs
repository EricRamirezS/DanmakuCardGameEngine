using DanmakuBaseExpansion.Cards.IncidentDeck;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuBaseExpansion.Decks {
    internal static class BaseIncidentDeck {
        public static IIncidentDeck Get() => new IncidentDeck() {
            new CrisisOfFaith(),
            new CrossingToHigan(),
            new EndlessParty(),
            new EternalNight(),
            new FiveImpossibleRequests(),
            new GreatBarrierWeakening(),
            new GreatFairyWars(),
            new LilyWhite(),
            new Overdrive(),
            new RekindleBlazingHell(),
            new SaigyouAyakashiBlooming(),
            new ScarletWeatherRhapsody(),
            new SpringSnow(),
            new UndefinedFantasticObject(),
            new VoyageToMakai(),
            new WorldlyDesires(),
        };
    }
}