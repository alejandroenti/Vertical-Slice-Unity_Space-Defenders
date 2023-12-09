using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;

    private InputSystem playerInputs;

    private Vector2 pmMovement = Vector2.zero;
    private bool pmPlace = false;
    private bool pmCancel = false;
    private bool pmMenu = false;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(gameObject);

            playerInputs = new InputSystem();
            playerInputs.PlaceModel.Enable();

            // Delegates
            playerInputs.PlaceModel.Navigate.performed += NavigateUpdate;
            playerInputs.PlaceModel.Place.performed += PlaceUpdate;
            playerInputs.PlaceModel.Cancel.performed += CancelUpdate;
            playerInputs.PlaceModel.Menu.performed += MenuUpdate;
        }
    }

    private void NavigateUpdate(InputAction.CallbackContext context)
    {
        this.pmMovement = context.ReadValue<Vector2>();
    }

    private void PlaceUpdate(InputAction.CallbackContext context)
    {
        this.pmPlace = context.ReadValue<bool>();
    }

    private void CancelUpdate(InputAction.CallbackContext context)
    {
        this.pmCancel = context.ReadValue<bool>();
    }

    private void MenuUpdate(InputAction.CallbackContext context)
    {
        this.pmMenu = context.ReadValue<bool>();
    }

    public void EnablePlaceModelActionMap() => playerInputs.PlaceModel.Enable();
    public void DisablePlaceModelActionMap() => playerInputs.PlaceModel.Disable();

    public Vector2 GetPMMovementValue() => pmMovement;
    public bool GetPMPlaceValue() => pmPlace;
    public bool GetPMCancelValue() => pmCancel;
    public bool GetPMMenuValue() => pmMenu;
}
