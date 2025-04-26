using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour {
    public GameObject secretPanel;
    void Start()
    {
        secretPanel.SetActive(false); // Reveal the panel
    }

    public void onClickSectretRoom()
    {
        secretPanel.SetActive(true);
    }
}


