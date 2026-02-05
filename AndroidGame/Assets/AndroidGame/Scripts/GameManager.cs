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
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        FindItemsBoxes();
    }
    public void FindItemsBoxes(){
        itemsBoxes = FindObjectsByType<ItemsBox>(FindObjectsSortMode.None).ToList();
    }

    // Update is called once per frame
    void Update()
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
    public void AwakeDialogue(DialogueContent dialogueContent){
        currentGameState = GameState.Dialogue;
        dialoguePanel.SetActive(true);
        DialogueManager.Instance.AwakeDialogue(dialogueContent);
    }
    public void EndDialogue(){
        currentGameState = GameState.Playing;
        dialoguePanel.SetActive(false);
    }
    public void AddMoodValue(int moodValue){
        GameData.Instance.MoodValue += moodValue;
    }
    public bool CheckAllItemsBoxesFinished(){
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
