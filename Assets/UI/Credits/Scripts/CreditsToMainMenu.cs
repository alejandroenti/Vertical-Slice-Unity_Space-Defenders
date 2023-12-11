using UnityEngine;

public class CreditsToMainMenu : MonoBehaviour
{
    [Header("Credits Animation Duration")]
    [SerializeField] private float animDuration;

    [Header("Credits Music Scene")]
    [SerializeField] private AudioClip sceneMusic;

    public float animTimer = 0f;

    private void Start()
    {
        Audio_Manager._AUDIO_MANAGER.PlayMusicSound(sceneMusic);
    }

    private void Update()
    {
        animTimer += Time.deltaTime;

        if (animTimer > animDuration)
        {
            Scene_Manager._SCENE_MANAGER.LoadNextScene("001_Main_Menu");
        }
    }
}
