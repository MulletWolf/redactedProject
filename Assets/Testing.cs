using UnityEngine;
public class Testing : MonoBehaviour
{
    [SerializeField] private testScriptableObject testScriptableObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(testScriptableObject.itemName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}