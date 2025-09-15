using System;
using DanmakuBaseExpansion.Cards.MainDeck.BaseImplementation;
using DanmakuCardGameEngine.Enums.Object;
using DanmakuCardGameEngine.Models.Cards.Timing;

namespace DanmakuBaseExpansion.Cards.MainDeck {
    /// <summary>
    /// Represents the "Borrow" card from the Main deck.
    /// </summary>
    /// <remarks>
    /// <para><b>Card Name:</b> “Borrow”</para>
    /// <para><b>Deck:</b> Main deck</para>
    /// <para><b>Point Value:</b> 2</para>
    /// <para><b>Card Types:</b> <see cref="DanmakuCardGameEngine.Enums.CardTimings.Action"/></para>
    /// <para><b>Text:</b></para>
    /// <para>Choose any Item in play.</para>
    /// <para>You gain control of that Item.</para>
    /// <para><b>Card FAQ and Errata:</b></para>
    /// <list type="bullet">
    /// <item>If you use “Borrow” to gain control of an <see cref="DanmakuCardGameEngine.Enums.CardSubtypes.Artifact"/> card 
    /// when you already control an Artifact, you must then immediately choose one of them to keep and discard the other. 
    /// You can choose to discard the Artifact you gained with “Borrow.”</item>
    /// <item>Gaining control of an Item does not count as it entering play, 
    /// so you will not immediately draw a card off of <see cref="SorcerersSutraScroll"/> if you take control of it using “Borrow.”</item>
    /// </list>
    /// </remarks>
    [Serializable]
    public class Borrow : SingleModeBaseMainCard, IActionMainTiming {
        public Borrow(int id, ISeason season) : base(
            id,
            "\"Borrow\"",
            season,
            2,
            new ActionBorrow()) { }
    }
}