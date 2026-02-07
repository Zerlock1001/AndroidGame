using UnityEngine;
namespace AndroidGame{
public class DailyLifeGameManager : GameManager
{
    public DialogueContent currentDialogueContent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        if(currentDialogueContent != null){
            base.AwakeDialogue(currentDialogueContent);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    public void Test(){
        Debug.Log("Test");
    }
}
}