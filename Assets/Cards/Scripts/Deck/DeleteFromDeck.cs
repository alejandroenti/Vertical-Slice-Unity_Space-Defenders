using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteFromDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Card cardToDelete;

    // Scale Variables
    private Vector3 initialScale;
    private Vector3 amplifiedScale = new Vector3(1.2f, 1.2f, 1.2f);

    // Color variables
    private Color initalColor = new Color(1f, 1f, 1f, 1f);
    private Color darkColor = new Color(0.25f, 0.25f, 0.25f, 0.95f);


    private void Awake()
    {
        initialScale = this.transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Deck_Controller._Deck_Controller.RemoveCardFromDeck(cardToDelete);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = amplifiedScale;
        SetSiblingsColor(darkColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = initialScale;
        SetSiblingsColor(initalColor);
    }

    public void SetCardToDelete(Card newCard) => cardToDelete = newCard;

    private void SetSiblingsColor(Color newColor)
    {
        this.transform.parent.GetChild(0).GetComponent<Image>().color = newColor;
        this.transform.parent.GetChild(1).GetComponent<Image>().color = newColor;
        this.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().color = newColor;
        this.transform.parent.GetChild(3).GetComponent<TextMeshProUGUI>().color = newColor;
    }
}
