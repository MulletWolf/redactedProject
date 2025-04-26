using UnityEngine;

public class JournalController : MonoBehaviour
{
    public GameObject journalPanel; // Assign in inspector
    public GameObject journalObject; // The clickable journal in scene

    void Start()
    {
        journalPanel.SetActive(false);
    }

    public void OnJournalClicked()
    {
        journalPanel.SetActive(true);
    }

    public void OnCloseJournal()
    {
        journalPanel.SetActive(false);
    }
}