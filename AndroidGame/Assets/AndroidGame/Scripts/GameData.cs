using UnityEngine;
namespace AndroidGame{
public class GameData : MonoBehaviour
{
    private int currentDay = 1;
    public int moodValue = 50;
    public static GameData Instance;
    public int CurrentDay { 
        get { return currentDay; }
        set { currentDay = value; }
    }
    public int MoodValue{
        get { return moodValue; }
        set { 
            if (value < 0) {
                moodValue = 0;
            } else if (value > 100) {
                moodValue = 100;
            } else {
                moodValue = value;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}