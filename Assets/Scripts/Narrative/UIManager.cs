using UnityEngine;
using UnityEngine.UI;

namespace Narrative
{
    public class UIManager: MonoBehaviour

    {
    public UnlockManager unlockManager;
    public Image paintingImage;
    public Text storyText;
    public Sprite paintingSprite;
    public string storyContent;

    void Start()
    {
        // Check unlock status and display accordingly
        if (unlockManager.CheckUnlockStatus("Painting 1"))
        {
            paintingImage.sprite = paintingSprite;
            paintingImage.gameObject.SetActive(true);
        }

        if (unlockManager.CheckUnlockStatus("Story Piece 1"))
        {
            storyText.text = storyContent;
            storyText.gameObject.SetActive(true);
        }
    }

    }
}