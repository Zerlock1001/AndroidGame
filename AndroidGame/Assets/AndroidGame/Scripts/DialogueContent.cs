using UnityEngine;
namespace AndroidGame{
[CreateAssetMenu(fileName = "DialogueContent", menuName = "Scriptable Objects/DialogueContent")]
public class DialogueContent : ScriptableObject
{
    public string content;
    public int choicesCount = 0;
    public string[] choices;
    public DialogueContent[] followingDialogues;
    public int[] moodChanges;
}
}