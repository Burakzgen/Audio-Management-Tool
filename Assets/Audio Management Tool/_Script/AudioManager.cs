using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip audioClip;
    public string audioName;
    [Range(0f, 1f)] public float volume = 0.3f;
    [Range(0f, 1f)] public float pitch = 1f;
    [HideInInspector] public AudioSource audioSource;
    public bool clipLoop;
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        Installation();

    }
    private void Installation()
    {
        foreach (var soundItem in sounds)
        {
            soundItem.audioSource = gameObject.AddComponent<AudioSource>();
            soundItem.audioSource.clip = soundItem.audioClip;
            soundItem.audioSource.volume = soundItem.volume;
            soundItem.audioSource.pitch = soundItem.pitch;
            soundItem.audioSource.loop = soundItem.clipLoop;
            soundItem.audioSource.playOnAwake = false;
        }
    }
    public void PlayClip(string soundName)
    {
        Sound _sound = System.Array.Find(sounds, sound => sound.audioName == soundName);
        if (_sound == null) { Debug.Log($"SOUND : {soundName} NOT FOUNDED!"); return; }

        _sound.audioSource.Play();
    }
    public void StopClip(string soundName)
    {
        Sound _sound = System.Array.Find(sounds, sound => sound.audioName == soundName);
        if (_sound == null) { Debug.Log($"SOUND : {soundName} NOT FOUNDED!"); return; }

        _sound.audioSource.Stop();
    }
}
