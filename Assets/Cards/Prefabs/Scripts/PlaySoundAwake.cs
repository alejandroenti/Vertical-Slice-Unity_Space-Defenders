using UnityEngine;

public class PlaySoundAwake : MonoBehaviour
{
    [Header("Construction Sound")]
    [SerializeField] private AudioClip awakeClip;

    private void Awake()
    {
        Audio_Manager._AUDIO_MANAGER.PlayFXSound(awakeClip);
    }
}
