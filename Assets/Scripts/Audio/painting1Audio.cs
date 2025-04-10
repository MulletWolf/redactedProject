using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class painting1Audio : MonoBehaviour
{
    public AudioClip mainMusic;
    public AudioClip backgroundChatter;
    public AudioClip glassesClink;
    public AudioClip cutlery;
    public AudioClip chandelierScrew;

    private AudioSource mainMusicSource;
    private AudioSource backgroundChatterSource;
    private AudioSource glassesClinkSource;
    private AudioSource cutlerySource;
    private AudioSource chandelierScrewSource;


    // insert name of scene here
    private string targetSceneName = "testScene";  

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
        backgroundChatterSource = backgroundChatterSource ?? gameObject.AddComponent<AudioSource>();
        glassesClinkSource = glassesClinkSource ?? gameObject.AddComponent<AudioSource>();
        cutlerySource = cutlerySource ?? gameObject.AddComponent<AudioSource>();
        chandelierScrewSource = chandelierScrewSource ?? gameObject.AddComponent<AudioSource>();

        //properties
        SetupAudioSource(mainMusicSource, mainMusic, 1f, true); // Looping main music
        SetupAudioSource(backgroundChatterSource, backgroundChatter, 0.8f, true); 
        SetupAudioSource(glassesClinkSource, glassesClink, 0.08f, true); 
        SetupAudioSource(cutlerySource, cutlery, 0.08f, true); 
        SetupAudioSource(chandelierScrewSource, chandelierScrew, 0.7f, false);

        // play !
        mainMusicSource.Play();
        backgroundChatterSource.Play();
        glassesClinkSource.Play();
        cutlerySource.Play();
        chandelierScrewSource.Play();
    }
}
