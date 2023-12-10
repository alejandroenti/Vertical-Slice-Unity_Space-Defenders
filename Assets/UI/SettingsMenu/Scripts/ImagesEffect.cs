using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImagesEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Buttons Sounds")]
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickedSound;
    [SerializeField] private AudioClip exitdSound;

    // Text Colors Variables
    private Color mainColor = new Color(224f / 255f, 224f / 255f, 224f / 255f);
    private Color hoverColor = new Color(1f, 1f, 1f);
    private Color clickedColor = new Color(106f / 106f, 224f / 255f, 106f / 255f, 0.9f);

    // Components
    Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.color = mainColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(hoverSound);

        imageComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(exitdSound);

        imageComponent.color = mainColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(clickedSound);

        imageComponent.color = clickedColor;
    }
}
