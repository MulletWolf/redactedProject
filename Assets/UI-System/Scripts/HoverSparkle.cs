using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSparkle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject sparkleEffect;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (sparkleEffect != null) sparkleEffect.SetActive(true);
        Debug.Log("Hovering!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (sparkleEffect != null) sparkleEffect.SetActive(false);
        Debug.Log("No longer hovering.");
    }
}
