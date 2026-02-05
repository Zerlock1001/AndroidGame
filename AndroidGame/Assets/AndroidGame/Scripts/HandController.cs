using UnityEngine;

namespace AndroidGame{
public class HandController : MonoBehaviour
{
    public static HandController instance;
    public DraggableItems currentItem;
    public bool isDragging = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentGameState == GameManager.GameState.Playing){
            DragItem();
            PutDownItem();
        }
    }
    public void DragItem(){
        if(Input.GetMouseButtonDown(0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
            if(hit.collider != null){
                DraggableItems item = hit.collider.GetComponent<DraggableItems>();
                if(item != null && !item.isPlaced){
                    DragItem(item);
                }
            }
        }
    }
    public void DragItem(DraggableItems item){
        currentItem = item;
        currentItem.isBeingHeld = true;
        isDragging = true;
    }
    public void PutDownItem(){
        if(Input.GetMouseButtonUp(0)){
            if(currentItem != null){
                currentItem.PutDown();
                currentItem = null;
                isDragging = false;
            }
        }
    }
}
}