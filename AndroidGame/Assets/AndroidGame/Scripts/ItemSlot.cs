using UnityEngine;
using System.Collections.Generic;

namespace AndroidGame{
public class ItemSlot : MonoBehaviour
{
    public List<string> itemNames;
    public GameObject itemInThisSlot = null;
    public int itemCount = 0;
    public int maxItemCount = 1;
    public bool usingOffSet = false;
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
            item.transform.position = transform.position;
        }
        //item.transform.parent = transform;
    }
}
}