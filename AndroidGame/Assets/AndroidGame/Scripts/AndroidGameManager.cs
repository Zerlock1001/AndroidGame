using UnityEngine;
using UnityEngine.UI;

public class AndroidGameManager : MonoBehaviour
{
    public GameObject cleanValueUI;
    public GameObject winUI;
    public GameObject loseUI;
    static float currentCleanValue = 0;
    public static int maxCleanValue = 100;
    public static float cleanSpeed = 10f;//float, 浮点数
    public static AndroidGameState currentGameState = AndroidGameState.Playing;
    public static float gameTime = 0f;
    public float maxGameTime = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(currentGameState){
            case AndroidGameState.Playing:
                gameTime += Time.deltaTime;
                if(gameTime >= maxGameTime){
                    SetGameState(AndroidGameState.Lose);
                }
                UpdateUI();
                break;
            case AndroidGameState.Win:
                winUI.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    ResetGame();
                }
                break;
            case AndroidGameState.Lose:
                loseUI.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space)){
                    ResetGame();
                }
                break;
        }
    }
    public static void AddCleanValue()
    {
        currentCleanValue = currentCleanValue + cleanSpeed * Time.deltaTime;//每次增加清洁值，每秒增加cleanSpeed的值
    }
    public static void AddCleanValue(float value){
        currentCleanValue = currentCleanValue + value;
    }
    public void UpdateUI(){
        if(currentCleanValue >= maxCleanValue){
            cleanValueUI.GetComponent<Text>().text = "Clean Value: " + maxCleanValue + "/" + maxCleanValue + " \nTime: " + (int)gameTime + "/" + (int)maxGameTime;
            Debug.Log("Clean is finished");
            SetGameState(AndroidGameState.Win);
            return;
        }
        cleanValueUI.GetComponent<Text>().text = "Clean Value: " + (int)currentCleanValue + "/" + maxCleanValue+ " \nTime: " + (int)gameTime + "/" + (int)maxGameTime;
    }
    public enum AndroidGameState{
        Playing,
        Win,
        Lose,
        Pause,
    }
    public static void SetGameState(AndroidGameState state){
        currentGameState = state;
    }
    public void ResetGame(){
        currentCleanValue = 0;
        SetGameState(AndroidGameState.Playing);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        BrushController.ResetBalance();
        gameTime = 0f;
    }

}
