using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceCards : MonoBehaviour
{
    [Header("Card Prefab")]
    [SerializeField] private GameObject cardPrefab;

    private void Awake()
    {
        UI_Manager._UI_MANAGER.SetDeckContainerObject(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void PlaceCard(Card card, int position)
    {
        GameObject cardParent = this.transform.GetChild(position).gameObject;
        GameObject cardTemp = Instantiate(cardPrefab, cardParent.transform);

        cardTemp.transform.SetParent(cardParent.transform);
        cardTemp.name = card.name;
        cardTemp.transform.name = card.name;

        cardTemp.GetComponent<SelectHandler>().SetCurrentCard(card);

        MountCard(cardTemp, card);

        cardTemp.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void MountCard(GameObject prefab, Card card)
    {
        prefab.transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = card.GetCardArtwork();
        prefab.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card.GetCardName();
        prefab.transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = card.GetCardCost().ToString();
        prefab.transform.GetChild(4).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = card.GetCardEffectAmount().ToString();
    }
}
