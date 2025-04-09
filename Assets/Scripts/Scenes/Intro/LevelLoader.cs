using System.Collections;
using InventorySystem;
using Narrative;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
   // public string[] scenes = {"towerScene","DoorFocus","Fall_Transition","BlackScreen","Main_Menu","Hub_Scene","Gallery" };
    //holds scene names
    public LevelLoader instance;
    //reference to leveloader class
    public int currentSceneIndex ;//start of loop
    public Animator transition;
    public float secondsDelay=1f;
    public AsyncOperation asyncload;
    public ProgressManager sceneProgressManager;

   // public UnlockManager unlockMananger;
   // public Animation animator;

    // Update is called once per frame

    void Start()
    {
     //   Awake();
      //  LODCrossFadeDitheringType.
     ///DontDestroyOnLoad(gameObject);
      //  StartCoroutine(LoadSceneInLoop());
      
      //LoadNextLevel();


    }

    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   /* void Update()
    {
        if (Input.GetMouseButtonDown(0))//when mouse down is pressed then go to next level
        {
             LoadNextLevel();
        
        }
        
    }*/

    public void LoadNextLevel()
       {
          // StartCoroutine(LoadSceneInLoop(SceneManager.GetActiveScene().buildIndex+1));
           
           int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

           if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
           {
               StartCoroutine(LoadSceneInLoop(nextSceneIndex));
           }
           else
           {
               Debug.Log("No more scenes to load!");
           }
           
         /*  if(currentSceneIndex<scenes.Length)
           {
               StartCoroutine(LoadSceneInLoop());
               
           }
           */
       }

    
        IEnumerator LoadSceneInLoop(int levelIndex)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(secondsDelay);
            SceneManager.LoadScene(levelIndex);






            // function is a coroutine that sequentially loads scenes with a delay between each transition
            // currentSceneIndex = 0;
            //    while(currentSceneIndex<scenes.Length)//loaded 1 by 1
            // {


            /* 1.   Debug.Log("Current Scene Index: " + currentSceneIndex);

                if (sceneProgressManager != null)
                {
                    if (currentSceneIndex==6&&sceneProgressManager.CheckProgressAndUnlock("Painting 1"))
                    {

                       SceneManager.LoadScene(scenes[currentSceneIndex+1]);

                    }

                }

             asyncload= SceneManager.LoadSceneAsync((scenes[currentSceneIndex]));//load each scene until its done

             asyncload.allowSceneActivation = true;1.




             Debug.Log("Scene "+currentSceneIndex+"loaded");
               yield return new WaitUntil(() =>asyncload.isDone);//waits until the scene is fully loaded
                 yield return new WaitForSeconds(secondsDelay);//delay before next
               currentSceneIndex++;//next scene

           /
               Debug.Log("Next scene index "+currentSceneIndex);

               if (currentSceneIndex >= scenes.Length)
               {
                   Debug.Log("All scenes loaded. Stopping transition.");
                   yield break;  // Stops coroutine
               }
            }
            Debug.Log("All scenes loaded.");
            */
        }
    

   
}
