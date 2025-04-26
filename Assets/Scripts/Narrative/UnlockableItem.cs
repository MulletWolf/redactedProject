using UnityEngine;
//using UnityEngineUI;


namespace Narrative
{
    [CreateAssetMenu(fileName = "NewUnlockable", menuName = "ScriptableObjects/Unlockable/CiphersAndPaintings")]
    public class UnlockableItem: ScriptableObject
    {
        
        public string itemName;
        public bool isUnlocked;
        
    }
    
}