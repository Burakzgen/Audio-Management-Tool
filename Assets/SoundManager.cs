using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundSource;
    public Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddSound(string name, AudioClip clip)
    {
        if (!sounds.ContainsKey(name))
        {
            sounds.Add(name, clip);
        }
    }

    public void RemoveSound(string name)
    {
        if (sounds.ContainsKey(name))
        {
            sounds.Remove(name);
        }
    }

    public void PlaySound(string name)
    {
        if (sounds.ContainsKey(name))
        {
            soundSource.clip = sounds[name];
            soundSource.Play();
        }
    }

    public void StopSound()
    {
        soundSource.Stop();
    }

    public void SetSoundVolume(float volume)
    {
        soundSource.volume = volume;
    }
}
