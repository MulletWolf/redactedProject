using UnityEngine;
using InventorySystem;
using Narrative;
using NUnit.Framework;
using Scenes;

using UnityEngine.UI;

namespace InventorySystem
{
    public class ProgressBar2:MonoBehaviour
    {
        public int currentProgress=0;
        public int maxProgress;
        public  ProgressBar2 instance;
        
        
        
        
        void Start()
        {
            currentProgress = 0;
            maxProgress = 3;
           
        }
       void Awake()
        {
     

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // Make this object persistent
            }
        
            
        }
       

      public   void AddProgress()
        {
           // currentProgress += 1;
           if(currentProgress < maxProgress)
           {
               currentProgress = Mathf.Min(currentProgress + 1, maxProgress);
           }

           string progress=$"{currentProgress}/{maxProgress}";
           Debug.Log($"Progress : {progress}");

            if (currentProgress >= maxProgress)
            {
                
                Debug.Log($"Progress full: {progress}");
                
                
               // currentProgress = 0;
            }
        }
    }
}