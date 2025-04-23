using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GalleryController : MonoBehaviour
{ 
    public GameObject GreenDoor; // Assign in inspector

    public void OnGreenDoorClicked()
    {
        SceneManager.LoadScene("GalleryScene");
    }
}
