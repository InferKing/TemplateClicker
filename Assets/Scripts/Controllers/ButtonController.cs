using UnityEngine;
using UnityEngine.UI;

public class ButtonController : ReceiverDataController
{
    [SerializeField] private Button _perClick, _autoClick, _censorship, _ad;
    private Advertisement _advertisement;
    public override void Initialize()
    {
        base.Initialize();
        _advertisement = ServiceLocator.Instance.Get<Advertisement>();
    }
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        UpdateInteractBtns();
    }
    protected override void OnModelUpdated(ModelUpdatedSignal signal)
    {
        base.OnModelUpdated(signal);
        UpdateInteractBtns();
    }
    private void UpdateInteractBtns()
    {
        _perClick.interactable = _gameDetails.PlayerInfo.money >= _gameDetails.ShopInfo.prices[Constants.keyPerClick];
        _autoClick.interactable = _gameDetails.PlayerInfo.money >= _gameDetails.ShopInfo.prices[Constants.keyPerSecond];
        _censorship.interactable = _gameDetails.PlayerInfo.money >= _gameDetails.ShopInfo.prices[Constants.keyCensorship];
        _ad.interactable = _advertisement.CanShowAd;
    }
    public void PlayerClick()
    {
        _gameDetails.PlayerInfo.money += _gameDetails.PlayerInfo.perTap;
        _bus.Invoke(new UpdateModelSignal(_gameDetails));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Click));
    }
    public void AdClick()
    {
        _bus.Invoke(new StartAdSignal());
    }
    public void PerTapClick()
    {
        _bus.Invoke(new ShopInteractSignal(Constants.keyPerClick));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Button));
    }
    public void AutoTapClick()
    {
        _bus.Invoke(new ShopInteractSignal(Constants.keyPerSecond));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Button));
    }
    public void CensorshipClick()
    {
        _bus.Invoke(new ShopInteractSignal(Constants.keyCensorship));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Censorship));
    }
}
