using UnityEngine;
using System.Collections.Generic;
namespace AndroidGame{
public class ItemsBox : MonoBehaviour
{
    public List<GameObject> items;
    public int currentItemIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject item in items){
            item.GetComponent<DraggableItems>().belongItemsBox = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if(DailyLifeGameManager.Instance.currentGameState != GameManager.GameState.Playing){
            return;
        }
        if(HandController.instance.currentItem == null && !Finished()){
            DraggableItems item = items[currentItemIndex].GetComponent<DraggableItems>();
            HandController.instance.DragItem(item);
            item.gameObject.GetComponent<Animator>().SetTrigger("PopUp");
        }
    }
    public void NextItem(){
        currentItemIndex++;
    }
    public bool Finished(){
        return currentItemIndex >= items.Count;
    }
}
}