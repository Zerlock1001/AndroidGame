using UnityEngine;
using TMPro;
using System.Collections.Generic;
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
        CheckConditions();
        dialogueTextObject.GetComponent<TMP_Text>().text = currentDialogueContent.content;
        for(int i = 0; i < choiceButtons.Length; i++){
            choiceButtons[i].SetActive(false);
        }
        for(int i = 0; i < currentDialogueContent.choicesCount; i++){
            if(currentDialogueContent.choicesConditions.Count==0||CheckChoicesConditions(currentDialogueContent.choicesConditions[i])){
                choiceButtons[i].SetActive(true);
                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = currentDialogueContent.choices[i];
            }
            else{
                choiceButtons[i].SetActive(false);
            }
        }
    }
    public bool CheckChoicesConditions(DialogueContent.Conditions conditions){
        if(conditions==null||conditions.condition.Count==0){
            return true;
        }
        foreach(DialogueContent.Condition condition in conditions.condition){
            if(!CheckCondition(condition)){
                return false;
            }
        }
        return true;
    }
    public bool CheckCondition(DialogueContent.Condition condition){
        if(condition.isMood){
            if(condition.higherThan){
                if(GameData.Instance.MoodValue <= condition.compareValue){
                    return false;
                }
            }
            else{
                if(GameData.Instance.MoodValue >= condition.compareValue){
                    return false;
                }
            }
        }
        else{
            if(condition.higherThan){
                if(GameData.Instance.EvolutionValue <= condition.compareValue){
                    return false;
                }
            }
            else{
                if(GameData.Instance.EvolutionValue >= condition.compareValue){
                    return false;
                }
            }
        }
        return true;
    }
    public void CheckConditions(){
        for(int i = 0; i < currentDialogueContent.conditions.Count; i++){
            DialogueContent.Conditions conditions = currentDialogueContent.conditions[i];
            for(int j = 0; j < conditions.condition.Count; j++){
                DialogueContent.Condition condition = conditions.condition[j];
                if(condition.isMood){
                    if(condition.higherThan){
                        if(GameData.Instance.MoodValue <= condition.compareValue){
                            break;
                        }
                    }
                    else{
                        if(GameData.Instance.MoodValue > condition.compareValue){
                            break;
                        }
                    }
                }
                else{
                    if(condition.higherThan){
                        if(GameData.Instance.EvolutionValue <= condition.compareValue){
                            break;
                        }
                    }
                    else{
                        if(GameData.Instance.EvolutionValue > condition.compareValue){
                            break;
                        }
                    }
                }
            }
            currentDialogueContent = currentDialogueContent.conditionsTrueDialogues[i];
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
                if(DailyLifeGameManager.Instance!=null){
                    DailyLifeGameManager.Instance.EndDialogue();
                }
            }
        }
        else{
            if(GameManager.instance!=null){
                GameManager.instance.EndDialogue();
            }
            else{
                if(DailyLifeGameManager.Instance!=null){
                    DailyLifeGameManager.Instance.EndDialogue();
                }
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
            else if(DailyLifeGameManager.Instance!=null){
                Debug.Log("DailyLifeGameManager.Instance != null");

                DailyLifeGameManager.Instance.EndDialogue();
                if(DailyLifeGameManager.Instance.currentGameState != GameManager.GameState.Playing){
                    DailyLifeGameManager.Instance.NextStep();
                }
            }
            Debug.Log("DailyLifeGameManager.Instance == null");
        }
    }
}
}