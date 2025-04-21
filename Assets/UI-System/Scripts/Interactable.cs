using UnityEngine;
//using LeanTween;
public class Interactable : MonoBehaviour {
    private ParticleSystem sparkles;

    void Start() {
        // Instantiate sparkle prefab
        GameObject sparkleObj = Instantiate(
            Resources.Load<GameObject>("SparkleFX"),
            transform
        );
        sparkles = sparkleObj.GetComponent<ParticleSystem>();
        sparkles.Stop(); // Start inactive
    }

    void OnMouseEnter() {
        // Play particles
        sparkles.Play();
        
        // Scale up object (visual feedback)
        //LeanTween.scale(gameObject, Vector3.one * 1.1f, 0.2f)
            //.setEase(LeanTweenType.easeOutBack);
    }

    void OnMouseExit() {
        // Stop particles
        sparkles.Stop();
        
        // Reset scale
        //LeanTween.scale(gameObject, Vector3.one, 0.15f);
    }
}