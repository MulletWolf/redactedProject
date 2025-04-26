using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Color normalColor = new Color(1, 1, 1, 0.5f); // 50% white
    [SerializeField] private Color hoverColor = Color.white; // 100% white
    private TMP_Text buttonText;

    void Start() {
        buttonText = GetComponent<TMP_Text>();
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        buttonText.color = normalColor;
    }
}