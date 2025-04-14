public class DialogueManager : MonoBehaviour {
    public TMP_Text dialogueText;
    public TMP_Text speakerNameText;
    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(string[] lines, string speaker) {
        speakerNameText.text = speaker;
        sentences.Clear();
        foreach (string line in lines) {
            sentences.Enqueue(line);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) return;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray()) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f); // Adjust speed
        }
    }
}
