using JetBrains.Annotations;
using UnityEngine;
[CreateAssetMenu]
public class ItemData : ScriptableObject
{//to eb added to inventory
    [Header("Gameplay")]
    public string itemName;
    public Sprite image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
