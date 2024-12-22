using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace Urdveil.Helpers.Manifestments
{
    public class ManifestmentOfAnxiety : CustomCurrencySingleCoin
    {
        public ManifestmentOfAnxiety(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
        {
            this.CurrencyTextKey = CurrencyTextKey;
            CurrencyTextColor = Color.LightGoldenrodYellow;
        }


    }
}