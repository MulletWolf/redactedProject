using UnityEngine;
using InventorySystem;
using Narrative;
using NUnit.Framework;
using Scenes;

using UnityEngine.UI;

namespace InventorySystem
{
    public class ProgressBar2 : MonoBehaviour
    {
        public int currentProgress = 0;
        public int maxProgress;
        public ProgressBar2 instance;

        public Image progressFill;

        [UnityEngine.Range(0, 3)] public int completedTasks = 0;

        private int totalTasks = 3;

        //public int totalTasks { get; private set; } = 3;
        public int TotalTasks
        {
            get => totalTasks;
            private set => totalTasks = value; // 'value' is the new value being set
        }



        public void AddProgress()
        {
            completedTasks = Mathf.Clamp(completedTasks + 1, 0, totalTasks);
            UpdateProgressBar();

            if (completedTasks == totalTasks)
            {
                TriggerFinalDialogue();
            }
        }

        void UpdateProgressBar()
        {
            float fillPercent = Mathf.Clamp01((float)completedTasks / totalTasks);
            progressFill.fillAmount = fillPercent;
        }

        void TriggerFinalDialogue()
        {
            Debug.Log("All tasks complete! Time to start the cipher.");
            // You can plug your dialogue trigger here or call another script.
        }




        /*    void Start()
            {
                currentProgress = 0;
                maxProgress = 3;

            }
           void Awake()
           {
               currentProgress = 0;
               if (currentProgress >= maxProgress||currentProgress!=0)
               {
                   currentProgress = 0;
               }


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
        }*/
    }
}