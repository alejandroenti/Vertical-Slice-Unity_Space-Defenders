using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    public static Tutorial_Manager _TUTORIAL_MANAGER;

    [Header("Tutorial Texts")]
    [SerializeField] private List<GameObject> texts;

    private int currentText = 0;

    private void Awake()
    {
        _TUTORIAL_MANAGER = this;
    }

    public void PlayNextText()
    {
        if (texts.Count <= 0)
        {
            return;
        }

        UI_Manager._UI_MANAGER.PlayTutorialText(texts[currentText]);
        texts.RemoveAt(currentText);
    }
}