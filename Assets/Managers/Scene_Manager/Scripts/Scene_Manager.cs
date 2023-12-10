using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager _SCENE_MANAGER;

    private void Awake()
    {
        if (_SCENE_MANAGER != null && _SCENE_MANAGER != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _SCENE_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadNextScene(string sceneName)
    {
        Audio_Manager._AUDIO_MANAGER.StopAllAudioSources();
        SceneManager.LoadScene(sceneName);
    }
}