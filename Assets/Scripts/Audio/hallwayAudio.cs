using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clasgalleryAudio : MonoBehaviour
{
    public AudioClip mainMusic;
    public AudioClip stoneFootsteps;
    public AudioClip torch;
    

    private AudioSource mainMusicSource;
    private AudioSource stoneFootstepsSource;
    private AudioSource torchSource;

  


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
        stoneFootstepsSource = stoneFootstepsSource ?? gameObject.AddComponent<AudioSource>();
        torchSource = torchSource ?? gameObject.AddComponent<AudioSource>();

        //properties
        SetupAudioSource(mainMusicSource, mainMusic, 1f, true); 
        SetupAudioSource(stoneFootstepsSource, stoneFootsteps, 0.8f, true);
        SetupAudioSource(torchSource, torch, 0.6f, true); 
        
        // play !
        mainMusicSource.Play();
        stoneFootstepsSource.Play();
        torchSource.Play();
        
    }
}


// need to add code for once painting is clicked stoneFootsteps will work
