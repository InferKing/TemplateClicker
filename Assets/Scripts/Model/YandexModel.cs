using System.Collections.Generic;
using YG;

public class YandexModel : BaseModel
{
    public override void Load()
    {
        YandexGame.LoadProgress();
        gameDetails = YandexGame.savesData.gameData;
        PlayerInfo pl = gameDetails.PlayerInfo;
        ShopInfo sh = gameDetails.ShopInfo;
        Dictionary<string, int> data = new()
        {
            {
                Constants.keyPerSecond,
                Constants.basePricePerSecond * (int)UnityEngine.Mathf.Pow(Constants.coefPricePerClick, pl.autoClick)
            },
            {
                Constants.keyPerClick,
                Constants.basePricePerClick * (int)UnityEngine.Mathf.Pow(Constants.coefPricePerClick, pl.perTap - 1)
            },
            {
                Constants.keyCensorship,
                Constants.basePriceCensorship * (int)UnityEngine.Mathf.Pow(Constants.coefPriceCensorship, sh.censorshipCount)
            },
            {
                Constants.keyAdvertisement,
                Constants.basePriceAdvertisement * (int)UnityEngine.Mathf.Pow(Constants.coefPriceAdvertisement, sh.censorshipCount)
            }
        };
        gameDetails.ShopInfo.prices = data;
#if UNITY_EDITOR
        UnityEngine.Debug.Log(gameDetails.PlayerInfo.ToString());
        UnityEngine.Debug.Log(gameDetails.ShopInfo.ToString());
#endif
    }

    public override void Save()
    {
        YandexGame.savesData.gameData = gameDetails;
        YandexGame.SaveProgress();
    }
    public override void UpdateGameDetails(GameDetails info)
    {
        base.UpdateGameDetails(info);
#if UNITY_EDITOR
        UnityEngine.Debug.Log(info.PlayerInfo.ToString());
        UnityEngine.Debug.Log(info.ShopInfo.ToString());
#endif
    }
}
