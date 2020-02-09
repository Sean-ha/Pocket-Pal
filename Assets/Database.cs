using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Database
{

    public int age, strength, intelligence, luck, charisma;
    public string petName;
    public double hunger, weight, money, lifetimeMoney;

    public List<string> foodInventory;
    public List<int> foodQuantities;
    public List<int> foodSpriteIndex;

    public List<string> itemInventory;
    public List<int> itemQuantities;
    public List<int> itemSpriteIndex;

    public string profession;
    public int salary;

    public string[] currentNames;
    public int[] currentCosts;
    public int[] currentSpriteIndex;
    public bool[] soldStatus;

    public int[] inventoryIndices;

    public double saveTime;
    public int timeAliveInSecs;
    public int refreshTimer;

    public Database()
    {
        age = Data.age;
        strength = Data.strength;
        intelligence = Data.intelligence;
        luck = Data.luck;
        charisma = Data.charisma;
        petName = Data.petName;
        hunger = Data.hunger;
        weight = Data.weight;
        money = Data.money;
        lifetimeMoney = Data.lifetimeMoney;
        profession = Data.profession;
        salary = Data.salary;

        foodInventory = Data.foodInventory;
        foodQuantities = Data.foodQuantities;
        foodSpriteIndex = Data.foodSpriteIndex;

        itemInventory = Data.itemInventory;
        itemQuantities = Data.itemQuantities;
        itemSpriteIndex = Data.itemSpriteIndex;

        currentNames = ShopData.currentNames;
        currentCosts = ShopData.currentCosts;
        currentSpriteIndex = ShopData.currentSpriteIndex;
        soldStatus = ShopData.soldStatus;
        inventoryIndices = ShopData.inventoryIndices;

        saveTime = Data.saveTime;
        timeAliveInSecs = Data.timeAliveInSecs;
        refreshTimer = ShopData.refreshTimer;
    }
}
