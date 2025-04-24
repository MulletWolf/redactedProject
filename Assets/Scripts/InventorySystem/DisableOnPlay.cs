using UnityEngine;

namespace InventorySystem
{
    public class DisableOnPlay:MonoBehaviour
    {
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}