using UnityEngine;
using System.Collections.Generic;

namespace AndroidGame{
public class ItemSlot : MonoBehaviour
{
    public List<string> itemNames;
    public GameObject itemInThisSlot = null;
    public int itemCount = 0;
    public int maxItemCount = 1;
    [Header("物体偏移")]
    public bool usingOffSet = false;
    public Vector3 itemOffset = Vector3.zero;

    [Header("物体旋转")]
    public bool isItemRotated = false;
    public Vector3 itemRotation = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanPlaceItem(string itemName){
        if(itemCount >= maxItemCount){
            Debug.Log("Item slot is full");
            return false;
        }
        foreach(string name in itemNames){
            if(name.Equals(itemName)){
                return true;
            }
        }
        return false;
    }
    public void PlaceItem(GameObject item){
        itemInThisSlot = item;
        itemCount++;
        if(usingOffSet){
            //item.transform.position = transform.position;
        }
        else{
            item.transform.position = transform.position + itemOffset;
        }
        if(isItemRotated){
            item.transform.rotation = Quaternion.Euler(itemRotation);
        }
        //item.transform.parent = transform;
    }
    public void PreviewItem(GameObject item){
        if(usingOffSet){
            //item.transform.position = transform.position;
        }
        else{
            item.transform.position = transform.position + itemOffset;
        }
        if(isItemRotated){
            item.transform.rotation = Quaternion.Euler(itemRotation);
        }
    }
}
}