using UnityEngine;

public class MusicButton : ReceiverDataController
{
    [SerializeField] private UnityEngine.UI.Image _buttonImg;
    [SerializeField] private Sprite[] _musicSprites;
    protected override void OnModelLoaded(ModelLoadedSignal signal)
    {
        base.OnModelLoaded(signal);
        UpdateSprite();
    }
    protected override void OnModelUpdated(ModelUpdatedSignal signal)
    {
        base.OnModelUpdated(signal);
        UpdateSprite();
    }
    public void ToggleMusic()
    {
        AudioListener.volume = GetVolume();
        UpdateSprite(true);
        _gameDetails.PlayerInfo.musicEnabled = !_gameDetails.PlayerInfo.musicEnabled;
        _bus.Invoke(new UpdateModelSignal(_gameDetails));
        _bus.Invoke(new PlaySoundSignal(SoundConstants.Button));
    }
    private void UpdateSprite(bool invert = false)
    {
        int res = invert ? 1 - GetVolume() : GetVolume();
        _buttonImg.sprite = _musicSprites[res];
    }
    private int GetVolume() => _gameDetails.PlayerInfo.musicEnabled ? 0 : 1;
}
