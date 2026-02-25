using UnityEngine;
namespace AndroidGame{
public class DraggableItems : MonoBehaviour
{
    public Vector3 startPosition;
    public Quaternion startRotation;
    public bool isBeingHeld = false;
    public string itemName;
    public bool isPlaced = false;
    public ItemsBox belongItemsBox;

    [Header("对话")]
    public bool isDialogue = false;
    public DialogueContent dialogueContent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public enum ItemType{
        //Bottle,
    }
    public void Move(){
        if(isBeingHeld){
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if(!PutDownPreview()){
                Reset();
            }
        }
    }
    public void Reset(){
        transform.rotation = startRotation;
    }
    public void PutDown(){
        isBeingHeld = false;
        //Debug.Log("PutDown");
        //TO-DO: 需要添加放下的逻辑
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ItemSlot"));
        if(hit.collider != null){
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.GetComponent<ItemSlot>() != null){
                ItemSlot itemSlot = hit.collider.gameObject.GetComponent<ItemSlot>();
                if(itemSlot.CanPlaceItem(itemName)){
                    //成功放下
                    //transform.position = hit.collider.gameObject.transform.position;
                    PutDownOnCertainSlot(itemSlot);
                    if(belongItemsBox != null){
                        belongItemsBox.NextItem();
                    }
                }
                else{
                    //放下失败
                    transform.position = startPosition;
                }
                //Debug.Log("ItemSlot found");
                
            }
            else{
                //没有找到ItemSlot
                Debug.Log("没有找到ItemSlot");
                transform.position = startPosition;
            }
        }
        else{
            //没有找到ItemSlot
            Debug.Log("ItemSlot not found");
            transform.position = startPosition;
        }
    }
    public bool PutDownPreview(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("ItemSlot"));
        if(hit.collider != null){
            if(hit.collider.gameObject.GetComponent<ItemSlot>() != null){
                ItemSlot itemSlot = hit.collider.gameObject.GetComponent<ItemSlot>();
                if(itemSlot.CanPlaceItem(itemName)){
                    itemSlot.PreviewItem(gameObject);
                    return true;
                }
            }
        }
        return false;
    }
    public void PutDownOnCertainSlot(ItemSlot itemSlot){
        itemSlot.PlaceItem(gameObject);
        isPlaced = true;
        //Debug.Log("放置成功，触发对应事件");
        if(isDialogue){
            if(GameManager.instance != null){
                GameManager.instance.AwakeDialogue(dialogueContent);
            }
            else if(DailyLifeGameManager.Instance != null){
                DailyLifeGameManager.Instance.NextStep();
            }
        }
    }
}
}
