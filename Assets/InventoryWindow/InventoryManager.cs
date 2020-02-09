using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static GameObject inventoryItem;
    public static int current, toBe, maxSize;
    Text itemName, itemQuantity, pageNumber;
    public static bool empty;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        toBe = 0;
        maxSize = Data.itemInventory.Count;

        inventoryItem = new GameObject();
        inventoryItem.AddComponent<SpriteRenderer>();

        itemName = GameObject.Find("InventoryName").GetComponent<Text>();
        itemQuantity = GameObject.Find("ItemQuantity").GetComponent<Text>();
        pageNumber = GameObject.Find("PageNumber").GetComponent<Text>();

        //if player's inventory is empty
        if (Data.itemInventory.Count == 0)
        {
            itemName.text = "You have no items.";
            empty = true;
        }
        else
        {
            itemName.text = Data.itemInventory[0];
            itemQuantity.text = "Quantity: " + Data.itemQuantities[0];
            pageNumber.text = "1 / " + maxSize;
            inventoryItem.GetComponent<SpriteRenderer>().sprite = Data.itemSprites[0];
            empty = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //only performs action when a button is pressed
        if (current != toBe)
        {
            maxSize = Data.itemInventory.Count;
            if (!empty)
            {
                //handles wrapping around
                if (toBe < 0)
                    toBe = maxSize - 1;
                if (toBe > maxSize - 1)
                    toBe = 0;

                inventoryItem.GetComponent<SpriteRenderer>().sprite = Data.itemSprites[toBe];
                itemName.text = Data.itemInventory[toBe];
                itemQuantity.text = "Quantity: " + Data.itemQuantities[toBe].ToString("n0");
                pageNumber.text = toBe + 1 + " / " + maxSize;
            }
            else
            {
                inventoryItem.GetComponent<SpriteRenderer>().sprite = null;
                itemName.text = "You have no items.";
                itemQuantity.text = "";
                pageNumber.text = "";
            }
            current = toBe;
        }
    }
}
