using DanmakuBaseExpansion.Cards.CharacterDeck;
using DanmakuCardGameEngine.Models.Deck;

namespace DanmakuBaseExpansion.Decks {
    internal static class BaseCharacterDeck {
        public static ICharacterDeck Get() => new CharacterDeck {
            // new AliceMargatroid(),
            new Cirno(),
            // new HakureiReimu(),
            // new HijiriByakuren(),
            // new HinanawiTenshi(),
            new HongMeiling(),
            new IbukiSuika(),
            new IzayoiSakuya(),
            // new KamishirasawaKeine(),
            new KawashiroNitori(),
            // new KazamiYuuka(),
            // new KirisameMarisa(),
            // new KochiyaSanae(),
            // new KomeijiSatori(),
            // new KonpakuYoumu(),
            // new MononobeNoFuto(),
            new PatchouliKnowledge(),
            // new ReisenUdongeinInaba(),
            // new ReiujiUtsuho(),
            // new RemiliaScarlet(),
            // new ToyosatomimiNoMiko(),
            new YagokoroEirin(),
            // new YakumoYukari(),
        };
    }
}