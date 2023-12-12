using UnityEngine;
using UnityEngine.EventSystems;

public class SelectHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler
{
    [Header("Animation Settings")]
    [SerializeField] private float verticalAmount = 25f;
    [SerializeField] private float moveTime = 0.1f;
    [SerializeField, Range(1f, 2f)] private float scaleAmount = 1.1f;

    private Card currentCard;

    // Variables que guardan la posición y la escala inicial
    private Vector3 initialPosition;
    private Vector3 initialScale;

    // Variables que guardaran la posición y la escala final
    private Vector3 finalPosition;
    private Vector3 finalScale;

    private bool isAnimating = false;
    private bool animationStarting = false;
    float animationTimer = 0f;

    private void Awake()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (isAnimating)
        {
            ExecuteAnimation();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        eventData.selectedObject = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        StartAnimation(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        StartAnimation(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UI_Manager._UI_MANAGER.HideDeckContainer();
        Grid_Manager._Grid_Manager.GenerateGrid();
        Game_Manager._Game_Manager.SetCurrentCard(currentCard, Game_Manager._Game_Manager.GetCardPosition());
        Game_Manager._Game_Manager.SetModelInCursor(gameObject);

        eventData.selectedObject = null;
    }

    public void SetCurrentCard(Card newCard) => currentCard = newCard;

    private void StartAnimation(bool isStartingAnimation)
    {
        isAnimating = true;
        animationStarting = isStartingAnimation;

        if (animationStarting)
        {
            finalPosition = initialPosition + new Vector3(0f, verticalAmount, 0f);
            finalScale = initialScale * scaleAmount;
        }
        else
        {
            finalPosition = initialPosition;
            finalScale = initialScale;
        }
    }

    private void ExecuteAnimation()
    {
        animationTimer = Time.deltaTime;

        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, (animationTimer / moveTime));
        Vector3 lerpScale = Vector3.Lerp(transform.localScale, finalScale, (animationTimer / moveTime));

        transform.position = lerpPosition;
        transform.localScale = lerpScale;

        if (animationTimer >= moveTime)
        {
            isAnimating = false;
            animationTimer = 0f;
        }
    }
}
