using System.Collections;
//using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//using System.Linq;
//using UnityEngine.UI;

namespace InventorySystem{
//{// transition.SetTrigger("Start");

    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        //public GameObject transitionsContainer;
        //  private SceneTransition[] transitions;
        public string[] scenes = { "IntroSequence", "TitleScreen",  "UI_Overlay", "TowerZoomIn", "DoorShutScene", "EyesOpenScene", "MainRoomScene","GalleryScene" ,"TheBanquet","LibraryScene"};
        public float fadeDuration = 1f;
       // public AsyncOperation asyncload;
       public CrossFade crossFade;

       // public SceneTransition transition;
       
     //   public Animator transition;

        //   public Slider progressBar;
        public int currentSceneIndex = 0; 
        public bool isdebug = true;

        public string sceneName;
       // int currentSceneIndex = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("SceneLoader Awake");
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                Debug.Log("SceneLoader destroyed");
            }

            if (scenes.Length == 0 || scenes==null)
            {
                Debug.Log("Scene not found");
                scenes = new string[10];
             //   return;
            }
           
        }

        void Start()
        {
            sceneName = scenes[currentSceneIndex];
        }

        void Update()
        {
            // if (isdebug)
            // {
            //     //Debug.Log("debug mode activates,sceneloading cancelld");
            //
            // }
            // else
            // {


                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // currentSceneIndex ++;

                    Debug.Log("Space pressed! Loading next scene...");
                    StartCoroutine(LoadSceneAsync());
                }
            
            /* if (Input.GetKeyDown(KeyCode.Space))
             {
                 transition.SetTrigger("End");
                 Debug.Log($"Loading: {scenes[currentSceneIndex]}"); // Verify in Console
                 SceneManager.LoadScene(scenes[currentSceneIndex]);
                 currentSceneIndex = (currentSceneIndex + 1) % scenes.Length;
                 transition.SetTrigger("Start");
             }*/



            /*  private IEnumerator Transition()
               {

                //   transition.SetTrigger("End");
                   yield return StartCoroutine(LoadSceneAsync());
                   //   crossFade.FaidIn();
                 //   transition.SetTrigger("Start");
               }*/

        }

        private IEnumerator LoadSceneAsync()
            {

                Debug.Log("Coroutine started!");
               
               
               // yield return new WaitForSeconds(fadeDuration);

               // currentSceneIndex = (currentSceneIndex + 1) % scenes.Length;
            //    yield return  StartCoroutine(crossFade.FadeOut());
               currentSceneIndex = (currentSceneIndex + 1) % scenes.Length;

          // Debug.Log("Fade Out");
          yield return new WaitForSeconds(fadeDuration);
          // currentSceneIndex = (currentSceneIndex + 1) % scenes.Length;
                 sceneName = scenes[currentSceneIndex];
                Debug.Log("Loading next scene..."+sceneName);

                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
                asyncLoad.allowSceneActivation = false;

                // Wait until 90% loaded
                while (asyncLoad.progress < 0.9f)
                {

                    yield return null;
                    
                }
               yield return new WaitForSeconds(fadeDuration);
              // yield return new WaitForSeconds(0.1f);

        
                asyncLoad.allowSceneActivation = true;
                // yield return StartCoroutine(crossFade.FadeIn());
                 Debug.Log("Fade in");

            }
        }
   }
