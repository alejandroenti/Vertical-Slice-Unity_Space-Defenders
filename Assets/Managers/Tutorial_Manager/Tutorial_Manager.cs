using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    public static Tutorial_Manager _TUTORIAL_MANAGER;



    private void Awake()
    {
        _TUTORIAL_MANAGER = this;
    }
}
