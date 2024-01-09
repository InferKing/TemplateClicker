using System.Collections;
using UnityEngine;

public class Advertisement : ReceiverDataController, IService
{
    public bool CanShowAd { get; private set; } = true;
    private WaitForSeconds _sleep;
    public override void Initialize()
    {
        base.Initialize();
        ServiceLocator.Instance.Register(this);
        _bus.Subscribe<StartAdSignal>(OnStartAd);
    }
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        _sleep = new WaitForSeconds(65);
    }
    private void OnStartAd(StartAdSignal signal)
    {
        if (!CanShowAd) return;
        CanShowAd = false;
        YG.YandexGame.RewVideoShow(0);
        StartCoroutine(DelayVideoAd());
    }
    public void OnRewardVideoAd()
    {
        _gameDetails.PlayerInfo.money += _gameDetails.ShopInfo.prices[Constants.keyAdvertisement];
        _bus.Invoke(new UpdateModelSignal(_gameDetails));
    }
    private IEnumerator DelayVideoAd()
    {
        yield return _sleep;
        CanShowAd = true;
    }
    public override bool TryDispose()
    {
        if (!base.TryDispose()) return false;
        _bus.Unsubscribe<StartAdSignal>(OnStartAd);
        ServiceLocator.Instance.Unregister<Advertisement>();
        return true;
    }
}
