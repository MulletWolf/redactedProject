using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableScrew : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 originalPosition;

    public string correctHoleTag;
    public GameObject topViewScrewPrefab;
    private GameObject overlappingHole;
    private float overlapTimer = 0f;
    private bool isOverWrongHole = false;
    private bool timerRunning = false;

    public float failDelay = 2.5f;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isOverWrongHole = false;
        overlapTimer = 0f;
        timerRunning = false;
        Debug.Log("Begin Drag!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out localPoint
        );
        rectTransform.localPosition = localPoint;
        Debug.Log("Dragging...");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (overlappingHole != null && overlappingHole.CompareTag(correctHoleTag))
        {
            // Instantiate top-view screw at this position and destroy current
            Instantiate(topViewScrewPrefab, rectTransform.position, Quaternion.identity, canvas.transform);
            Destroy(gameObject);

            ChandelierGameController controller = FindFirstObjectByType<ChandelierGameController>();
        }
        else
        {
            // Return to original position if dropped wrong
            rectTransform.anchoredPosition = originalPosition;
        }
        Debug.Log("End Drag!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        overlappingHole = other.gameObject;
        Debug.Log("Entered trigger with: " + other.gameObject.name);
        Debug.Log("Trigger entered: " + overlappingHole.name);

        if (!other.CompareTag(correctHoleTag))
        {
            Debug.Log("Wrong hole detected");
            isOverWrongHole = true;
            timerRunning = true;
        }
        else
        {
            Debug.Log("Correct hole detected");
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == overlappingHole)
        {
            isOverWrongHole = false;
            timerRunning = false;
            overlapTimer = 0f;
        }
    }

    void Update()
    {
        if (timerRunning && isOverWrongHole)
        {
            overlapTimer += Time.deltaTime;
            if (overlapTimer >= failDelay)
            {
                GetComponent<ScrewFailHandler>().StartFailCountdown();
                timerRunning = false;
            }
        }
    }
}
