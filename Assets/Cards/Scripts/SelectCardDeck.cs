using UnityEngine;
using UnityEngine.EventSystems;

public class SelectCardDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private void Start()
    {
        Debug.Log("STARTING!");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("MOUSE ENTERED!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("MOUSE EXITED!");
    }
}
