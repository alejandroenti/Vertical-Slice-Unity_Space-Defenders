using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager _AUDIO_MANAGER;

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
}
