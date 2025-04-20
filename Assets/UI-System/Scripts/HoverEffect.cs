using UnityEngine;
public class HoverEffect : MonoBehaviour {
    [SerializeField] private GameObject sparklePrefab;
    private ParticleSystem sparkles;

    void Start() {
        // Instantiate as child
        GameObject sparkleObj = Instantiate(sparklePrefab, transform);
        sparkles = sparkleObj.GetComponent<ParticleSystem>();
        sparkles.Stop();
    }

    void OnMouseEnter() {
        sparkles.Play();
    }
}

