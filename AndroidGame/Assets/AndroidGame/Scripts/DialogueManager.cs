using UnityEngine;
using TMPro;
namespace AndroidGame{
public class DialogueManager : MonoBehaviour
{
    public GameObject[] choiceButtons;
    public GameObject dialogueTextObject;
    public static DialogueManager Instance;
    DialogueContent currentDialogueContent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AwakeDialogue(DialogueContent dialogueContent){
        currentDialogueContent = dialogueContent;
        dialogueTextObject.GetComponent<TMP_Text>().text = currentDialogueContent.content;
        for(int i = 0; i < choiceButtons.Length; i++){
            choiceButtons[i].SetActive(false);
        }
        for(int i = 0; i < currentDialogueContent.choicesCount; i++){
            choiceButtons[i].SetActive(true);
            choiceButtons[i].GetComponentInChildren<TMP_Text>().text = currentDialogueContent.choices[i];
        }
    }
    public void ChoiceButtonClick(int choiceIndex){
        if(choiceIndex>=currentDialogueContent.effects.Length){
        }
        else if(currentDialogueContent.effects[choiceIndex].effect!=null){
            foreach(ChoiceEffect effect in currentDialogueContent.effects[choiceIndex].effect){
                effect.DoEffect();
            }
        }
        if(choiceIndex<currentDialogueContent.followingDialogues.Length){
            if(currentDialogueContent.followingDialogues[choiceIndex] != null){
             DialogueManager.Instance.AwakeDialogue(currentDialogueContent.followingDialogues[choiceIndex]);
            }
            else{
                if(GameManager.instance!=null){
                    GameManager.instance.EndDialogue();
                }
            }
        }
        else{
            if(GameManager.instance!=null){
                GameManager.instance.EndDialogue();
            }
        }
    }
    public void ClickAnyWhere(){
        if(currentDialogueContent.choicesCount>0){
            return;
        }
        else{
            if(GameManager.instance!=null){
                GameManager.instance.EndDialogue();
            }
        }
    }
}
}