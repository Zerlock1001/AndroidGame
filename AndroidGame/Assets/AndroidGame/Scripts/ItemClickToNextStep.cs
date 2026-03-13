using UnityEngine;
namespace AndroidGame{
public class ItemClickToNextStep : MonoBehaviour
{
    bool isClick = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (!isClick)
        {
            Debug.Log("ItemClickToNextStep");
            DailyLifeGameManager.Instance.NextStep();
            isClick = true;
        }
    }
}
}
