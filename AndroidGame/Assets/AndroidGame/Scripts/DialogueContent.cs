using UnityEngine;
using System.Collections.Generic;
namespace AndroidGame{
[CreateAssetMenu(fileName = "DialogueContent", menuName = "Scriptable Objects/DialogueContent")]
public class DialogueContent : ScriptableObject
{
    public string content;
    public int choicesCount = 0;
    public string[] choices;
    public DialogueContent[] followingDialogues;
    [SerializeField] public Effects[] effects;
    [System.Serializable] public class Effects{
        public List<ChoiceEffect> effect;
    }
    [System.Serializable] public class Conditions{
        public List<Condition> condition;
    }
    [System.Serializable] public class Condition{
        public bool isMood;
        public bool higherThan;
        public int compareValue;
    }
    public List<Conditions> conditions;
    public List<DialogueContent> conditionsTrueDialogues;
}
}