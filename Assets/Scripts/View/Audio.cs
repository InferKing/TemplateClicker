using UnityEngine;

[CreateAssetMenu(fileName = "audio.asset", menuName = "SO/Audio")]
public class Audio : ScriptableObject
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private SoundConstants type;
    public AudioClip Sound { get { return sound; } }
    public SoundConstants Type { get { return type; } }
}
