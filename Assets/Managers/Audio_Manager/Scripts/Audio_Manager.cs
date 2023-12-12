using UnityEngine;
using UnityEngine.Audio;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager _AUDIO_MANAGER;

    [Header("Audio Mixer")]
    [SerializeField] AudioMixer audioMixer;

    private AudioSource musicAudioSource;
    private AudioSource fxAudioSource;
    private AudioSource uiAudioSource;

    private void Awake()
    {
        if (_AUDIO_MANAGER != null && _AUDIO_MANAGER != this)
        {
            _AUDIO_MANAGER.OnLoadNewLevel();
            Destroy(gameObject);
        }
        else
        {
            _AUDIO_MANAGER = this;
            DontDestroyOnLoad(this);

            OnLoadNewLevel();
        }
    }

    private void OnLoadNewLevel()
    {
        GameObject audioSourcesContainer = GameObject.FindGameObjectWithTag("AudioSources");

        musicAudioSource = audioSourcesContainer.transform.GetChild(0).GetComponent<AudioSource>();
        fxAudioSource = audioSourcesContainer.transform.GetChild(1).GetComponent<AudioSource>();
        uiAudioSource = audioSourcesContainer.transform.GetChild(2).GetComponent<AudioSource>();
    }

    public float GetVolumeMusic()
    {
        float volume = 0f;
        audioMixer.GetFloat("musicVolume", out volume);
        return volume;
    }

    public float GetVolumeFX()
    {
        float volume = 0f;
        audioMixer.GetFloat("fxVolume", out volume);
        return volume;
    }

    public float GetVolumeUI()
    {
        float volume = 0f;
        audioMixer.GetFloat("uiVolume", out volume);
        return volume;
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetVolumeFX(float volume)
    {
        audioMixer.SetFloat("fxVolume", volume);
    }

    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("uiVolume", volume);
    }

    public void PlayMusicSound(AudioClip newClip)
    {
        musicAudioSource.clip = newClip;
        musicAudioSource.Play();
    }

    public void PlayFXSound(AudioClip newClip)
    {
        fxAudioSource.clip = newClip;
        fxAudioSource.Play();
    }

    public void PlayUISound(AudioClip newClip)
    {
        uiAudioSource.clip = newClip;
        uiAudioSource.Play();
    }

    public void StopAllAudioSources()
    {
        musicAudioSource.Stop();
        fxAudioSource.Stop();
        uiAudioSource.Stop();
    }
}
