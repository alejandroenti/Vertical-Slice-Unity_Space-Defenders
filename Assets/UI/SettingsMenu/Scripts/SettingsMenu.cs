using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Graphics and Volumes Objects")]
    [SerializeField] private GameObject graphicObject;
    [SerializeField] private GameObject musicVolumObject;
    [SerializeField] private GameObject fxVolumObject;
    [SerializeField] private GameObject uiVolumObject;

    private void Awake()
    {
        graphicObject.transform.GetChild(1).GetComponent<TMPro.TMP_Dropdown>().value = QualitySettings.GetQualityLevel();

        musicVolumObject.transform.GetChild(1).GetComponent<Slider>().value = Audio_Manager._AUDIO_MANAGER.GetVolumeMusic();
        fxVolumObject.transform.GetChild(1).GetComponent<Slider>().value = Audio_Manager._AUDIO_MANAGER.GetVolumeFX();
        uiVolumObject.transform.GetChild(1).GetComponent<Slider>().value = Audio_Manager._AUDIO_MANAGER.GetVolumeUI();
    }
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
