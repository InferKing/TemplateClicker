using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : BaseController
{
    [SerializeField] private AudioSource _fx, _music;
    [SerializeField] private List<Audio> _audios;
    public override void Initialize()
    {
        base.Initialize();
        _bus.Subscribe<PlaySoundSignal>(OnPlaySound);
    }
    private void OnPlaySound(PlaySoundSignal signal)
    {
        Audio audio = GetMatchAudio(signal.data);
        if (audio == null) return;
        if (signal.data == SoundConstants.Music)
        {
            _music.clip = audio.Sound;
            _music.Play();
            return;
        }
        _fx.PlayOneShot(audio.Sound);
    }
    private Audio GetMatchAudio(SoundConstants sound)
    {
        Audio result = _audios.Find(item => item.Type == sound);
        if (result == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"Audio with type **{sound}** not in Audios.");
#endif
            return null;
        }
        return result;
    }
    public override bool TryDispose()
    {
        if (!base.TryDispose()) return false;
        _bus.Unsubscribe<PlaySoundSignal>(OnPlaySound);
        return true;
    }
}
