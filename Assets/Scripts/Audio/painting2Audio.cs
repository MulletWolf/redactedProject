using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.UI;
using UnityEngine.Audio;





public class painting2Audio : MonoBehaviour
{
    public AudioClip mainMusic;
    public AudioClip bookNoise1;
    public AudioClip bookNoise2;
    public AudioClip bookNoise3;
   

    private AudioSource mainMusicSource;
    private AudioSource bookNoise1Source;
    private AudioSource bookNoise2Source;
    private AudioSource bookNoise3Source;


    // insert name of scene here

   
    private string targetSceneName = "Library";  


    void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
       
    }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //checks if its the right scene
        if (scene.name == targetSceneName)
        {
            // Initialize and play audio
            PlayAllAudio();
        }
    }

    // set up audioSources links to properties
    private void SetupAudioSource(AudioSource audioSource, AudioClip clip, float volume, bool loop)
    {
        if (clip != null)
        {
            audioSource.clip = clip;  
            audioSource.volume = volume;  
            audioSource.loop = loop; 
        }
        else
        {
            Debug.LogWarning("AudioClip is null for " + audioSource.name);
        }
    }

    // plays all sound together
    private void PlayAllAudio()
    {
        // adds audio source if it hasnt already
        mainMusicSource = mainMusicSource ?? gameObject.AddComponent<AudioSource>();
        bookNoise1Source = bookNoise1Source ?? gameObject.AddComponent<AudioSource>();
        bookNoise2Source = bookNoise2Source ?? gameObject.AddComponent<AudioSource>();
        bookNoise3Source = bookNoise3Source ?? gameObject.AddComponent<AudioSource>();

        //properties
        SetupAudioSource(mainMusicSource, mainMusic, 1f, true); // Looping main music
        SetupAudioSource(bookNoise1Source, bookNoise1, 0.8f, false); 
        SetupAudioSource(bookNoise2Source, bookNoise2, 0.08f, false);
        SetupAudioSource(bookNoise3Source, bookNoise3, 0.08f, false); 
       
        // play !

        mainMusicSource.Play();
        bookNoise1Source.Play();
        bookNoise2Source.Play();
       bookNoise3Source.Play();

        //mainMusicSource.Play();
        //bookNoise1.Play();
        //bookNoise2.Play();
       //bookNoise3.Play();

    }

    
    ////CODE FOR WHEN BOOKS ARE MOVED / CLICKED ON
    /////
    ////
    ///
    //Input this segmengt of code in 

    private  void bookTask()
	{ 
		//Random rnd = new Random(); errors 
        int num  = Random.Range(1, 4);

        switch (num)
        {
            case 1:
                //booknoise1
                bookNoise1Source.Play();
                break;
            case 2:
                bookNoise2Source.Play();
                break;
            case 3:
                bookNoise3Source.Play();
                break;
            default:
                Debug.Log("no other book noise accepted");
                break;
        }
        
      /*  if (num == 1){
            //play bookNoise1 
        }
        if (num == 2){
            //you get the idea
        }
        if (num == 3){
            //im so sleep deprived
        }
*/
	} 






}



