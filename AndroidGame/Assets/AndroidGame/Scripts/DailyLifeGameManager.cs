using UnityEngine;
using System.Collections.Generic;
using AndroidGame;
namespace AndroidGame{
public class DailyLifeGameManager : GameManager
{
    public DialogueContent currentDialogueContent;
    public DailyLifeStep currentStep;
    public List<DailyLifeStep> gameSteps;
    int currentStepIndex = 0;
    public static DailyLifeGameManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        Instance = this;
        if(gameSteps.Count > 0){
            currentStep = gameSteps[0];
        }
        /*if(currentDialogueContent != null){
            base.AwakeDialogue(currentDialogueContent);
        }*/
    }

    // Update is called once per frame
    public override void Update()
    {
        if(currentStepIndex >= gameSteps.Count){
            return;
        }
        if(currentStep != null){
            DailyLifeStep tempStep = currentStep;
            currentStep = null;
            tempStep.DoEffect();
            Debug.Log("currentStep: " + tempStep);
        }
    }
    public void Test(){
        Debug.Log("Test");
    }
    public enum DailyLifeGameStep{
        None,
        BlackScreenFadeIn,
        BlackScreenFadeOut,
        ShowDialogue,
        GameObjectMove,
        ShowGameObject,
    }
    public void NextStep(){
        //Debug.Log("NextStep");
        currentStepIndex++;
        if(currentStepIndex < gameSteps.Count){
            currentStep = gameSteps[currentStepIndex];
        }
    }
    public DailyLifeStep CurrentStep(){
        return gameSteps[currentStepIndex];
    }
}
}