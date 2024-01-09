using System.Collections.Generic;

public class ShopConfiguration : ReceiverDataController
{
    private Dictionary<string, int> _prices;
    public override void Initialize()
    {
        base.Initialize();
        _bus.Subscribe<ShopInteractSignal>(OnShopInteract);
    }
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        _prices = _gameDetails.ShopInfo.prices;
    }
    private void OnShopInteract(ShopInteractSignal signal)
    {
        if (!_prices.ContainsKey(signal.data) || signal.data == Constants.keyAdvertisement) return;
        int price = _prices[signal.data];
        if (_gameDetails.PlayerInfo.money >= price)
        {
            _gameDetails.PlayerInfo.money -= price;
            UpdateShopPrices(signal.data);
            switch (signal.data)
            {
                case Constants.keyPerClick:
                    _gameDetails.PlayerInfo.perTap += 1;
                    break;
                case Constants.keyPerSecond:
                    _gameDetails.PlayerInfo.autoClick += 1;
                    break;
                case Constants.keyCensorship:
                    _gameDetails.ShopInfo.censorshipCount += 1;
                    break;
            }
            _bus.Invoke(new UpdateModelSignal(_gameDetails));
        }
    }
    private void UpdateShopPrices(string key)
    {
        if (!_prices.ContainsKey(key)) return;
        switch (key)
        {
            case Constants.keyPerClick:
                _prices[key] *= Constants.coefPricePerClick;
                break;
            case Constants.keyPerSecond:
                _prices[key] *= Constants.coefPricePerSecond;
                break;
            case Constants.keyCensorship:
                _prices[key] *= Constants.coefPriceCensorship;
                _prices[Constants.keyAdvertisement] *= Constants.coefPriceAdvertisement;
                break;
        }
        _gameDetails.ShopInfo.prices = _prices;
    }
    public override bool TryDispose()
    {
        if (!base.TryDispose()) return false;
        _bus.Unsubscribe<ShopInteractSignal>(OnShopInteract);
        return true;
    }
}
