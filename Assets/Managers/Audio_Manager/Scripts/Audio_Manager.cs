using UnityEngine;
using UnityEngine.Animations;
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
            Destroy(gameObject);
        }
        else
        {
            _AUDIO_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        OnLoadNewLevel();
    }

    public void OnLoadNewLevel()
    {
        GameObject audioSourcesContainer = GameObject.FindGameObjectWithTag("AudioSources");

        musicAudioSource = audioSourcesContainer.transform.GetChild(0).GetComponent<AudioSource>();
        fxAudioSource = audioSourcesContainer.transform.GetChild(1).GetComponent<AudioSource>();
        uiAudioSource = audioSourcesContainer.transform.GetChild(2).GetComponent<AudioSource>();
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

    public void PlayUISound(AudioClip newClip)
    {
        uiAudioSource.clip = newClip;
        uiAudioSource.Play();
    }
}
