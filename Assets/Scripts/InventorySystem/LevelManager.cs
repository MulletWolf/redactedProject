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
        
        private readonly string[] scenes = { "IntroSequence", "TitleScreen",  "UI_Overlay", "TowerZoomIn", "DoorShutScene", "EyesOpenScene", "MainRoomScene","GalleryScene" ,"TheBanquet","GalleryScene2","LibraryScene","EndCreditsScene"};
      
        public float fadeDuration = 1f;
       
       public CrossFade crossFade;

      
        public int currentSceneIndex = 0; 
     

        public string sceneName;
        public const int BanquetSceneIndex = 8;
       public string Scenes 
       {
           get => scenes[currentSceneIndex];
           set
           {
               if (currentSceneIndex >= 0 && currentSceneIndex < scenes.Length)
                   scenes[currentSceneIndex] = value;
           } // 'value' is the new value being set
       }

        private void Awake()
        {
            VerifyScenesInBuildSettings();
          if (scenes.Length <= BanquetSceneIndex)
            {
                Debug.LogError($"Scenes array must have at least {BanquetSceneIndex + 1} elements!");
            }
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("SceneLoader Awake");
                
                if (scenes.Length <= BanquetSceneIndex)
                {
                    Debug.LogError($"Scenes array must have at least {BanquetSceneIndex + 1} elements!");
                }
            }
            else  
            {
                Destroy(gameObject);
               // Debug.Log("SceneLoader destroyed");
            }
            

           
        }
        private void VerifyScenesInBuildSettings()
        {
            Debug.Log("Starting scene verification...");
            Debug.Log($"Scenes in array: {scenes.Length}");
            Debug.Log($"Scenes in build: {SceneManager.sceneCountInBuildSettings}");

            // First log all scenes in build settings
            for (int j = 0; j < SceneManager.sceneCountInBuildSettings; j++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(j);
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
                Debug.Log($"Build Index {j}: {sceneName} (Path: {scenePath})");
            }

            // Now verify each expected scene
            for (int i = 0; i < scenes.Length; i++)
            {
                bool sceneExists = false;
                string expectedScene = scenes[i];
        
                for (int j = 0; j < SceneManager.sceneCountInBuildSettings; j++)
                {
                    string scenePath = SceneUtility.GetScenePathByBuildIndex(j);
                    string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            
                    if (sceneName == expectedScene)
                    {
                        sceneExists = true;
                        Debug.Log($"✓ Found scene: {expectedScene} at index {j}");
                        break;
                    }
                }

                if (!sceneExists)
                {
                    Debug.LogError($"✗ MISSING FROM BUILD: {expectedScene} (array index {i})");
                }
            }
        }
        public bool IsSceneInArray(string sceneName)
        {
            // Case-sensitive comparison
            return System.Array.Exists(scenes, s => s == sceneName);
        }

        void Start()
        {
            sceneName = scenes[currentSceneIndex];
        }

        void Update()
        {
         
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // currentSceneIndex ++;

                    Debug.Log("Space pressed! Loading next scene...");
                    StartCoroutine(LoadSceneAsync());
                }
            
           

        }

        public bool IsCurrentSceneBanquet()
        {
            if (scenes == null || scenes.Length <= BanquetSceneIndex)
            {
                Debug.LogError("Scenes array not properly initialized!");
                return false;
            }

            // Then get current scene safely
            Scene currentScene = SceneManager.GetActiveScene();
            if (!currentScene.IsValid())
            {
                Debug.LogError("Current scene is not valid!");
                return false;
            }

            // Finally compare
            return currentScene.name.Equals(scenes[BanquetSceneIndex], 
                System.StringComparison.Ordinal);
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
