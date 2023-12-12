using UnityEngine;
using UnityEngine.EventSystems;

public class ResetLevel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Scene_Manager._SCENE_MANAGER.LoadNextScene(Scene_Manager._SCENE_MANAGER.GetCurrentSceneName());
    }
}
