using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIController : ReceiverDataController
{
    [SerializeField] private TMP_Text 
        _moneyText, 
        _perClickText, 
        _autoClickText,
        _pricePerClick,
        _priceAutoClick,
        _priceCensorship,
        _priceAdvertisement;
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        UpdateView(signal.data);
    }
    protected override void OnModelUpdated(ModelUpdatedSignal signal)
    {
        base.OnModelUpdated(signal);
        UpdateView(signal.data);
    }
    private void UpdateView(GameDetails dt)
    {
        _moneyText.text = dt.PlayerInfo.money.ToString();
        _perClickText.text = dt.PlayerInfo.perTap.ToString();
        _autoClickText.text = dt.PlayerInfo.autoClick.ToString();
        _pricePerClick.text = dt.ShopInfo.prices.GetValueOrDefault(Constants.keyPerClick).ToString();
        _priceAutoClick.text = dt.ShopInfo.prices.GetValueOrDefault(Constants.keyPerSecond).ToString();
        _priceCensorship.text = dt.ShopInfo.prices.GetValueOrDefault(Constants.keyCensorship).ToString();
        _priceAdvertisement.text = dt.ShopInfo.prices.GetValueOrDefault(Constants.keyAdvertisement).ToString();
    }
}
