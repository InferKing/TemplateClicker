using UnityEngine;

public class CensorshipController: ReceiverDataController
{
    [SerializeField] private Censorship[] _cens;
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        UpdateStartCensorship();
    }
    protected override void OnModelUpdated(ModelUpdatedSignal signal)
    {
        base.OnModelUpdated(signal);
        UpdateCensorship();
    }
    private void UpdateStartCensorship()
    {
        for (int i = 0; i < _cens.Length; i++)
        {
            _cens[i].StartState(i < _gameDetails.ShopInfo.censorshipCount);
        }
    }
    private void UpdateCensorship()
    {
        for (int i = 0; i < _gameDetails.ShopInfo.censorshipCount && i < _cens.Length; i++)
        {
            _cens[i].AnimateHide();
        }
    }
}
