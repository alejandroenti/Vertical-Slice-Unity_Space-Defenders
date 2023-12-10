using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Buttons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Buttons Alternative Images")]
    [SerializeField] private Sprite hoverImage;
    [SerializeField] private Sprite clickedImage;

    [Header("Button Hover Scale")]
    [SerializeField, Range(1f, 2f)] private float scaleAmount;

    private Sprite mainImage;

    // Scale Variables
    private Vector3 initialScale;
    private Vector3 hoverScale;

    // Text Colors Variables
    private Color mainColor = new Color(224f / 255f, 224f / 255f, 224f / 255f);
    private Color hoverColor = new Color(1f, 1f, 1f);
    private Color clickedColor = new Color(106f / 106f, 224f / 255f, 106f / 255f, 0.9f);

    // Components
    Image imageComponent;
    TextMeshProUGUI textComponent;

    private void Awake()
    {
        imageComponent = this.transform.GetChild(0).GetComponent<Image>();
        textComponent = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        mainImage = imageComponent.sprite;

        initialScale = this.transform.localScale;
        hoverScale = this.transform.localScale * scaleAmount;

        imageComponent.color = mainColor;
        textComponent.color = mainColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        imageComponent.sprite = clickedImage;

        imageComponent.color = clickedColor;
        textComponent.color = clickedColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        imageComponent.sprite = hoverImage;

        imageComponent.transform.localScale = hoverScale;
        textComponent.transform.localScale = hoverScale;

        imageComponent.color = hoverColor;
        textComponent.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageComponent.sprite = mainImage;

        imageComponent.transform.localScale = initialScale;
        textComponent.transform.localScale = initialScale;

        imageComponent.color = mainColor;
        textComponent.color = mainColor;
    }
}
