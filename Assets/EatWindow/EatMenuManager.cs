using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatMenuManager : MonoBehaviour
{

    public static int current, toBe;
    public static List<Sprite> foodSprites;
    GameObject foodObject;
    public static int maxSize;
    Text foodName, pageNumber, foodQuantity;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        toBe = 0;
        foodSprites = Data.foodInventorySprites;

        maxSize = Data.foodInventory.Count;

        //foodObject is the game object that will have its sprite changed as user presses buttons.
        foodObject = new GameObject();
        foodObject.AddComponent<SpriteRenderer>();
        //start at first food object (which should always be bread)
        foodObject.GetComponent<SpriteRenderer>().sprite = foodSprites[0];

        //This script is attached to the object representing the "name of food" text.
        foodName = GetComponent<Text>();
        foodName.text = Data.foodInventory[0];

        pageNumber = GameObject.Find("PageNumber").GetComponent<Text>();
        pageNumber.text = "1 / " + maxSize;

        foodQuantity = GameObject.Find("FoodQuantity").GetComponent<Text>();
        foodQuantity.text = "Quantity: \u221E";
    }

    // Update is called once per frame
    void Update()
    {
        //only performs action when a button is pressed
        if (current != toBe)
        {
            maxSize = Data.foodInventory.Count;

            //handles wrapping around
            if (toBe < 0)
                toBe = maxSize - 1;
            if (toBe > maxSize - 1)
                toBe = 0;

            foodObject.GetComponent<SpriteRenderer>().sprite = foodSprites[toBe];
            foodName.text = Data.foodInventory[toBe];
            pageNumber.text = toBe + 1 + " / " + maxSize;

            if (Data.foodQuantities[toBe] == -1)
                foodQuantity.text = "Quantity: \u221E";
            else
                foodQuantity.text = "Quantity: " + Data.foodQuantities[toBe].ToString("n0");

            current = toBe;
        }
    }
}
