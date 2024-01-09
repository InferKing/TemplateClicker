using UnityEngine;

public class AutoClicker : ReceiverDataController
{
    private WaitForSeconds _sleep;
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        _sleep = new WaitForSeconds(1f);
        StartCoroutine(AutoClick());
        
    }
    private System.Collections.IEnumerator AutoClick()
    {
        while (Application.isPlaying)
        {
            if (_gameDetails.PlayerInfo.autoClick != 0)
            {
                _gameDetails.PlayerInfo.money += _gameDetails.PlayerInfo.autoClick;
                _bus.Invoke(new UpdateModelSignal(_gameDetails));
            }
            yield return _sleep;
        }
    }
}
