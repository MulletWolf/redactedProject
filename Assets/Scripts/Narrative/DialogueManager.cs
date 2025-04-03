/*namespace Narrative
{
   using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private DialogueNode currentNode;



    public Text dialogueText;
    public Button continueButton;
    public Transform choicesContainer;
    public Button choiceButtonPrefab;

    void Start()
    {
        sentences = new Queue<string>();
        continueButton.gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueNode startNode)
    {
        Debug.Log("Starting conversation with " + startNode.name);

        currentNode = startNode;
        sentences.Clear();
        DisplayNode(currentNode);
    }

    public void DisplayNode(DialogueNode node)
    {
        // Destroy any previous choice buttons
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        // Set the dialogue text
        dialogueText.text = node.dialogueText;

        // If there are choices, display them
        if (node.choices != null && node.choices.Length > 0)
        {
            continueButton.gameObject.SetActive(false); // Hide continue button if there are choices
            foreach (var choice in node.choices)
            {
                Button choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
                choiceButton.GetComponentInChildren<Text>().text = choice.choiceText;
                choiceButton.onClick.AddListener(() => OnChoiceSelected(choice));
            }
        }
        else
        {
            // If no choices, show the continue button
            continueButton.gameObject.SetActive(true);
            continueButton.onClick.AddListener(DisplayNextSentence);
        }
    }
private void OnChoiceSelected(DialogueChoice choice)
    {
        // When a choice is selected, move to the next node
        DisplayNode(choice.nextNode);
    }

    public void DisplayNextSentence()
    {
        if (currentNode == null)
            return;

        if (currentNode.nextNode != null)
        {
            DisplayNode(currentNode.nextNode);
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        dialogueText.text = "Dialogue finished.";
        continueButton.gameObject.SetActive(false);
    }
}
}
*/