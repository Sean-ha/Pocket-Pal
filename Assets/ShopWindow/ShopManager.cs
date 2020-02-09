using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public static GameObject shopItem;
    public static int current, toBe;
    Text itemName, itemCost, pageNumber, balance, refreshTime;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        toBe = 0;

        //shopItem represents the gameObject that changes as user scrolls thru shop
        shopItem = new GameObject();
        shopItem.AddComponent<SpriteRenderer>();
        shopItem.GetComponent<SpriteRenderer>().sprite = ShopData.currentSprites[0];

        itemName = GameObject.Find("ItemName").GetComponent<Text>();
        itemCost = GameObject.Find("ItemCost").GetComponent<Text>();
        pageNumber = GameObject.Find("PageNumber").GetComponent<Text>();
        balance = GameObject.Find("Balance").GetComponent<Text>();
        refreshTime = GameObject.Find("RefreshTime").GetComponent<Text>();

        itemName.text = ShopData.currentNames[0];
        itemCost.text = "Cost: $" + ShopData.currentCosts[0].ToString("n0");
        pageNumber.text = "1 / 5";
    }

    // Update is called once per frame
    void Update()
    {
        //only performs action when a button is pressed
        if (current != toBe)
        {
            //handles wrapping around
            if (toBe < 0)
                toBe = 4;
            if (toBe > 4)
                toBe = 0;

            shopItem.GetComponent<SpriteRenderer>().sprite = ShopData.currentSprites[toBe];
            itemName.text = ShopData.currentNames[toBe];
            itemCost.text = "Cost: $" + ShopData.currentCosts[toBe].ToString("n0");
            pageNumber.text = toBe + 1 + " / 5";

            current = toBe;
        }
        refreshTime.text = (ShopData.refreshTimer / 3600).ToString("00")
                    + " : " + ((ShopData.refreshTimer % 3600) / 60).ToString("00")
                    + " : " + ((ShopData.refreshTimer % 3600) % 60).ToString("00");

        balance.text = "Balance: $" + System.Math.Floor(Data.money).ToString("n0");
    }
}
