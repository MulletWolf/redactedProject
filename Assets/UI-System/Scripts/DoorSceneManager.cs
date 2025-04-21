using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DoorSceneManager : MonoBehaviour {
    void Start() {
        StartCoroutine(NextSceneAfterDelay(4f)); // 4 seconds
    }

    IEnumerator NextSceneAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("EyesOpenScene");
    }
}
