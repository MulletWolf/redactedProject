using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueChoice", menuName = "Dialogue/Dialogue Choice")]
public class DialogueChoice : ScriptableObject
{
    [System.Serializable]
    public class Choice
    {
        public string choiceText;
        public DialogueLine nextLine; // or another DialogueChoice
    }

    public string questionText;
    public Choice[] choices;
}
