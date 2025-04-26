using UnityEngine;

public class SceneLoadInit : MonoBehaviour
{
    public GameObject sceneloaderprefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(sceneloaderprefab==null)
        {
            Instantiate(sceneloaderprefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
