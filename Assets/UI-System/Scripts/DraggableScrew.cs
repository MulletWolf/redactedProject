using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableScrew : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform targetHole; // The hole it's supposed to go to
    public GameObject topViewVersion; // The "correct" top view PNG to switch to
    public float snapDistance = 50f; // distance in px or units

    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float dist = Vector2.Distance(rectTransform.position, targetHole.position);
        if (dist <= snapDistance)
        {
            // Snap to target
            rectTransform.position = targetHole.position;

            // Show top view
            topViewVersion.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            // Start fail timer
            GetComponent<ScrewFailHandler>().StartFailCountdown();
        }
    }
}
