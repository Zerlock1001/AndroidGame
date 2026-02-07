using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
namespace AndroidGame{
public class UnpackingGameManager : GameManager
{

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    public override void AwakeDialogue(DialogueContent dialogueContent){
        currentGameState = GameState.Dialogue;
        dialoguePanel.SetActive(true);
        DialogueManager.Instance.AwakeDialogue(dialogueContent);
    }
    public override void EndDialogue(){
        currentGameState = GameState.Playing;
        dialoguePanel.SetActive(false);
    }
    public override void AddMoodValue(int moodValue){
        GameData.Instance.MoodValue += moodValue;
    }
    public override bool CheckAllItemsBoxesFinished(){
        foreach(ItemsBox itemsBox in itemsBoxes){
            if(!itemsBox.Finished()){
                return false;
            }
        }
        Debug.Log("All items boxes finished");
        return true;
    }
}
}
