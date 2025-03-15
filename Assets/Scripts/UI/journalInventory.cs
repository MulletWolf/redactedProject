using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // For TextMeshPro (if used)

public class JournalUI : MonoBehaviour
{
    public GameObject journalPanel;   // Assign in Inspector
    public TextMeshProUGUI journalText;  // Text component for excerpts
    public Button prevPageButton, nextPageButton, closeButton;

    private List<string> journalEntries = new List<string>();  // Holds collected text
    private int currentPage = 0;

    void Start()
    {
        journalPanel.SetActive(false);  // Hide journal at start
        closeButton.onClick.AddListener(CloseJournal);
        prevPageButton.onClick.AddListener(PrevPage);
        nextPageButton.onClick.AddListener(NextPage);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))  // Press 'J' to open journal
        {
            ToggleJournal();
        }
    }

    public void ToggleJournal()
    {
        bool isActive = !journalPanel.activeSelf;
        journalPanel.SetActive(isActive);

        if (isActive) DisplayPage();  // Show current entry
    }

    void DisplayPage()
    {
        if (journalEntries.Count > 0)
        {
            journalText.text = journalEntries[currentPage];
        }

        // Enable/Disable navigation buttons based on page
        prevPageButton.interactable = (currentPage > 0);
        nextPageButton.interactable = (currentPage < journalEntries.Count - 1);
    }

    public void NextPage()
    {
        if (currentPage < journalEntries.Count - 1)
        {
            currentPage++;
            DisplayPage();
        }
    }

    public void PrevPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            DisplayPage();
        }
    }

    public void CloseJournal()
    {
        journalPanel.SetActive(false);
    }

    public void AddEntry(string entry)
    {
        journalEntries.Add(entry);
    }
}
