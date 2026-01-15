using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Audio Clips")]
    public AudioClip[] sfxClips;
    public AudioClip[] musicClips;

    void Awake()
    {
        
    }

    // 🔊 PLAY SFX BY INDEX
    public void PlaySFX(int index)
    {
        if (index < 0 || index >= sfxClips.Length)
        {
            Debug.LogWarning("SFX index out of range: " + index);
            return;
        }

        sfxSource.PlayOneShot(sfxClips[index]);
    }

    // 🎵 PLAY MUSIC BY INDEX
    public void PlayMusic(int index, bool loop = true)
    {
        if (index < 0 || index >= musicClips.Length)
        {
            Debug.LogWarning("Music index out of range: " + index);
            return;
        }

        musicSource.clip = musicClips[index];
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // 🔈 Volume Controls
    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }
}
