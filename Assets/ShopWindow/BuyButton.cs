using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click"));
        int curr = ShopManager.toBe;
        if (!ShopData.soldStatus[curr] && Data.money >= ShopData.currentCosts[curr])
        {
            
            Data.money -= ShopData.currentCosts[curr];
            ShopData.soldStatus[curr] = true;

            //replaces sprite with "sold out" sprite
            ShopData.currentSprites[curr] = ShopData.inventorySprites[22];
            ShopManager.shopItem.GetComponent<SpriteRenderer>().sprite = ShopData.inventorySprites[22];
            ShopData.currentSpriteIndex[curr] = 22;

            string boughtItemName = ShopData.currentNames[curr];

            //totalIndex represents the position in the total inventory list that the item is in.
            int totalIndex = ShopData.inventoryIndices[curr];

            //add to proper inventory, corresponding with index number.
            //if the item is a food item
            if (totalIndex <= 86)
            {
                //if the player already has one of this item, add 1 to quantity.
                if(Data.foodInventory.Contains(boughtItemName))
                {
                    int index = Data.foodInventory.IndexOf(boughtItemName);
                    Data.foodQuantities[index]++;
                }
                //if player doesn't have it yet, add it.
                else
                {
                    Data.foodInventory.Add(boughtItemName);
                    Data.foodQuantities.Add(1);
                    Data.foodInventorySprites.Add(ShopData.returnSprite(totalIndex));
                    Data.foodSpriteIndex.Add(ShopData.returnSpriteIndex(totalIndex));
                }
            }
            //if the item is not food
            else
            {
                if (Data.itemInventory.Contains(boughtItemName))
                {
                    int index = Data.itemInventory.IndexOf(boughtItemName);
                    Data.itemQuantities[index]++;
                }
                else
                {
                    Data.itemInventory.Add(boughtItemName);
                    Data.itemQuantities.Add(1);
                    Data.itemSprites.Add(ShopData.returnSprite(totalIndex));
                    Data.itemSpriteIndex.Add(ShopData.returnSpriteIndex(totalIndex));
                }
            }
        }
    }
}
