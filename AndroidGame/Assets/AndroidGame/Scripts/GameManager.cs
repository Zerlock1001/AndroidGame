using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
namespace AndroidGame{
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Playing;
    public Bool isDialogue = Bool.FALSE;
    public TMP_Text dialogueTextObject;
    public GameObject dialoguePanel;
    public static GameManager instance;
    public List<ItemsBox> itemsBoxes;
    //public int 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);
        FindItemsBoxes();
    }
    public virtual void FindItemsBoxes(){
        itemsBoxes = FindObjectsByType<ItemsBox>(FindObjectsSortMode.None).ToList();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CheckAllItemsBoxesFinished();
    }
    public enum GameState{
        Playing,
        Dialogue,
        Finished,
    }
    public enum Bool{
        TRUE,
        FALSE,
    }
    public virtual void AwakeDialogue(DialogueContent dialogueContent){
        currentGameState = GameState.Dialogue;
        dialoguePanel.SetActive(true);
        DialogueManager.Instance.AwakeDialogue(dialogueContent);
    }
    public virtual void EndDialogue(){
        currentGameState = GameState.Playing;
        dialoguePanel.SetActive(false);
    }
    public virtual void AddMoodValue(int moodValue){
        GameData.Instance.MoodValue += moodValue;
    }
    public virtual bool CheckAllItemsBoxesFinished(){
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
