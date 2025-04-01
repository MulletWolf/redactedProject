using System.Collections;
//using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Linq;
using UnityEngine.UI;

namespace Scenes
{
   
    public class LevelManager1:MonoBehaviour
    {
      //  public static LevelManager1 instance;
        public GameObject transitionsContainer;
        private SceneTransition[] transitions;
     //   public string[] scenes = {"towerScene","DoorFocus","Fall_Transition","BlackScreen","Main_Menu","Hub_Scene","Gallery" };
        public float secondsDelay = 2f;
        public AsyncOperation asyncload;
        public SceneTransition transition;
        public Slider progressBar;
        public int currentSceneIndex = 0;
        
      /*  private void Awake()
        {
            if (instance==null) //if it has no referenc eto LevelManager then dnt destroy the gameobject
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }*/

        /*void Update()
        {
            Debug.Log("Current Scene Index: " + currentSceneIndex); // Debugging
            if (Input.GetKeyDown(KeyCode.Space))//when mouse down is pressed then go to next level
            {
                Debug.Log("Space key pressed!");
                LoadScene(currentSceneIndex,"CrossFade");
                
              
        
            }

        }*/

        private void Start()
        {
            transitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
            //used to get the transition component of the gameobject transitionConainer
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(0))//whe key pressed load next scene
        //     {
        //        
        //     }
        //      StartCoroutine(LoadScene(sceneName,transitionName));
        // }

        public void LoadScene(int currentSceneIndex, string transitionName)
        {
           // string sceneName = scenes[currentSceneIndex];
           
            StartCoroutine(LoadSceneAsync(currentSceneIndex,  transitionName));
        }

        private IEnumerator LoadSceneAsync(int currentSceneIndex, string transitionName)

        {
           // string sceneName = currentSceneIndex];
            // SceneTransition transition = transitions.First(t => t.name==transitionName);
            // SceneTransition transition = null;
            for (int t = 0; t < transitions.Length; t++)
            {
                //getting very first element only

                if (transitions[t].name == transitionName)
                {
                    transition = transitions[t];
                    break; //exit loop
                }

                transitions[t].name = transitionName;
            }




        //    asyncload = SceneManager.LoadSceneAsync(sceneName); //loading scene asynchrously
            asyncload.allowSceneActivation = false;
            //Set it to false to only load 90% used
            //to give ui updates etc/ to wiat fr
            //player to click smth tie to laid before next scene


            yield return new WaitForSeconds(secondsDelay); //wiat
            yield return transition.AnimateTransitionIn(); //returns the transition and wiats for it to finish before going to next line

            // progressBar.gameObject.SetActive(true); //visible
            while( currentSceneIndex <0 /*scenes.Length&&currentSceneIndex>=0*/)
            {
                // LoadScene(scenes[currentSceneIndex], "CrossFade");
                // currentSceneIndex++;
                asyncload = SceneManager.LoadSceneAsync(currentSceneIndex); //loading scene asynchrously
                asyncload.allowSceneActivation = false;
              //  yield return new WaitForSeconds(secondsDelay);

            


            
            
                //when u wnat to spawn things init tings do it here
                

              /*  while (asyncload.progress < 0.9)
                {
                    progressBar.value = asyncload.progress; //update progressbar
                    yield return null;
                     } 
                    //while the sceneload <90%then increase progresssbar value

                    asyncload.allowSceneActivation = true; //nextscene
                    progressBar.gameObject.SetActive(false);
                    
                    */

                    yield return transition.AnimateTransitionOut();

                    currentSceneIndex++;




            }
    }
        
    }
}