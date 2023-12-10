using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager _SCENE_MANAGER;

    private string currentSceneName;

    private void Awake()
    {
        if (_SCENE_MANAGER != null && _SCENE_MANAGER != this)
        {
            _SCENE_MANAGER.currentSceneName = SceneManager.GetActiveScene().name;
            Game_Manager._Game_Manager.SetCurrentScene(currentSceneName);
            Destroy(gameObject);
        }
        else
        {
            _SCENE_MANAGER = this;
            DontDestroyOnLoad(this);
            
            _SCENE_MANAGER.currentSceneName = SceneManager.GetActiveScene().name;
            Game_Manager._Game_Manager.SetCurrentScene(currentSceneName);
        }
    }

    public string GetCurrentSceneName() => currentSceneName;

    public void LoadNextScene(string sceneName)
    {
        Audio_Manager._AUDIO_MANAGER.StopAllAudioSources();
        SceneManager.LoadScene(sceneName);
    }
}