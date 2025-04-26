using UnityEngine;

public class Intro2Dialogue : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public  string currentDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDialogue="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do " +
                        "eiusmod tempor incididunt ut labore et dolore magna aliqua";
        dialogueSystem.ShowDialogue(currentDialogue);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
