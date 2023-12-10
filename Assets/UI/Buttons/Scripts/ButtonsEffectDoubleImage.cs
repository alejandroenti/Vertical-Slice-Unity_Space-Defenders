using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsEffectDoubleImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Buttons Alternative Images")]
    [SerializeField] private Sprite hoverImage;
    [SerializeField] private Sprite clickedImage;

    [Header("Button Hover Scale")]
    [SerializeField, Range(1f, 2f)] private float scaleAmount;

    [Header("Buttons Sounds")]
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickedSound;
    [SerializeField] private AudioClip exitdSound;

    private Sprite mainImage;

    // Text Colors Variables
    private Color mainColor = new Color(224f / 255f, 224f / 255f, 224f / 255f);
    private Color hoverColor = new Color(1f, 1f, 1f);
    private Color clickedColor = new Color(106f / 106f, 224f / 255f, 106f / 255f, 0.9f);

    // Components
    Image imageComponent;
    Image iconComponent;

    private void Awake()
    {
        imageComponent = this.transform.GetChild(0).GetComponent<Image>();
        iconComponent = this.transform.GetChild(1).GetComponent<Image>();

        mainImage = imageComponent.sprite;

        imageComponent.color = mainColor;
        iconComponent.color = mainColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(clickedSound);

        imageComponent.sprite = clickedImage;

        imageComponent.color = clickedColor;
        iconComponent.color = clickedColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(hoverSound);

        imageComponent.sprite = hoverImage;

        imageComponent.color = hoverColor;
        iconComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Audio_Manager._AUDIO_MANAGER.PlayUISound(exitdSound);

        imageComponent.sprite = mainImage;

        imageComponent.color = mainColor;
        iconComponent.color = mainColor;
    }
}
