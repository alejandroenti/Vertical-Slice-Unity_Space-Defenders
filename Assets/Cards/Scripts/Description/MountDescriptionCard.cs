using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MountDescriptionCard : MonoBehaviour
{
    public void MountCard(Card cardSelected)
    {
        // Cogemos el prefab de la carta y cambiamos todos los campos necesarios
        GameObject cardTemp = this.transform.GetChild(0).gameObject;

        cardTemp.transform.GetChild(0).transform.GetChild(1).GetComponent<Image>().sprite = cardSelected.GetCardArtwork();
        cardTemp.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardSelected.GetCardName();
        cardTemp.transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardSelected.GetCardCost().ToString();
        cardTemp.transform.GetChild(4).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardSelected.GetCardEffectAmount().ToString();

        // Cambiamos la descripción de la carta
        this.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = cardSelected.GetCardDescription();
    }
}
