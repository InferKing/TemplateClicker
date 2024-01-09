using System.Collections.Generic;
public enum SoundConstants
{
    Music,
    Click,
    Button,
    Censorship
}
public class Constants
{
    public const string
        keyPerClick = "PerClick",
        keyPerSecond = "PerSecond",
        keyCensorship = "Censorship",
        keyAdvertisement = "Advertisement",
        animatorParameterToggle = "Toggle";
    public const int
        basePricePerClick = 50,
        basePricePerSecond = 10,
        basePriceCensorship = 500,
        basePriceAdvertisement = 700,
        coefPricePerClick = 2,
        coefPricePerSecond = 2,
        coefPriceCensorship = 4,
        coefPriceAdvertisement = 3;
}
