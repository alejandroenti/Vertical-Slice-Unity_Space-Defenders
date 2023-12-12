using UnityEngine;

public class TxtShow : MonoBehaviour
{
    [Header("Text timer")]
    [SerializeField] private float textTime;

    public float textTimer = 0f;

    private void Update()
    {
        textTimer += Time.unscaledDeltaTime;

        if (textTimer >= textTime)
        {
            UI_Manager._UI_MANAGER.HideTutorialText(this.gameObject);
        }
    }
}
