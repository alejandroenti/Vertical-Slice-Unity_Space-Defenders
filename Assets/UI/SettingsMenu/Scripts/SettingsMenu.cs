using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetVolumeMusic(float volume)
    {
        Audio_Manager._AUDIO_MANAGER.SetVolumeMusic(volume);
    }

    public void SetVolumeFX(float volume)
    {
        Audio_Manager._AUDIO_MANAGER.SetVolumeFX(volume);
    }

    public void SetVolumeUI(float volume)
    {
        Audio_Manager._AUDIO_MANAGER.SetVolumeUI(volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
