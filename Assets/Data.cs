using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    private static Data instance;
    public static int age, strength, intelligence, luck, charisma;
    public static string petName;
    public static double hunger, weight, money, lifetimeMoney;

    public static List<string> foodInventory;
    public static List<int> foodQuantities;
    public static List<Sprite> foodInventorySprites;
    public static List<int> foodSpriteIndex;

    public static Sprite[] foodSprites;

    public static List<string> itemInventory;
    public static List<int> itemQuantities;
    public static List<Sprite> itemSprites;
    public static List<int> itemSpriteIndex;
    

    public static string profession;
    public static int salary;

    public static double saveTime;

    public static double hungerDecrement, weightDecrement;

    public static int timeAliveInSecs;
    public static double salarySecs;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MobileAds.Initialize("ca-app-pub-4949264892672058~1613393366");
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //InvokeRepeating("SaveGame", 1.0f, 1.0f);
        InvokeRepeating("EverySecond", 1.0f, 1.0f);
        foodInventory = new List<string>();
        foodQuantities = new List<int>();
        foodInventorySprites = new List<Sprite>();
        foodSpriteIndex = new List<int>();

        foodSprites = Resources.LoadAll<Sprite>("food");

        //the default infinite quantity foods
        foreach (Sprite s in foodSprites)
        {
            foodInventorySprites.Add(s);
        }

        itemInventory = new List<string>();
        itemQuantities = new List<int>();
        itemSprites = new List<Sprite>();
        itemSpriteIndex = new List<int>();

        //temporary stats merely for testing purpoes.
/*        petName = "name";
        hunger = 100;
        age = 0;
        weight = 5;
        money = 100000;
        lifetimeMoney = 0;
        profession = "None";
        salary = 0;
        strength = 0;
        intelligence = 0;
        luck = 0;
        charisma = 0;
        timeAliveInSecs = 0;*/

        salarySecs = salary / 3600.0;

        foodInventory.Add("Bread");
        foodQuantities.Add(-1);

        hungerDecrement = 100.0 / 86400.0;
        weightDecrement = 1.0 / 3600.0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger > 100)
            hunger = 100;
    }

    void EverySecond()
    {
        if (hunger > 0)
        {
            hunger -= hungerDecrement;
            money += salarySecs;
            lifetimeMoney += salary / 3600.0;
        }
        if (weight > 0)
            weight -= weightDecrement;
        timeAliveInSecs++;
        age = timeAliveInSecs / 86400;
    }

    public static void SaveGame()
    {
        saveTime = System.DateTime.Now.ToOADate();
        SaveSystem.SaveData();
    }

    public static void LoadGame()
    {
        double loadTime = System.DateTime.Now.ToOADate();

        Database database = SaveSystem.LoadData();

        if(database == null)
        {
            age = 0;
            strength = 0;
            intelligence = 0;
            luck = 0;
            charisma = 0;
            petName = "temporary";
            hunger = 100;
            weight = 0;
            money = 5000;
            lifetimeMoney = 5000;
            profession = "Baby";
            salary = 100;
            timeAliveInSecs = 0;
            salarySecs = salary / 3600.0;
            SceneManager.LoadScene("EnterName");
        }
        else
        {
            int elapsedTimeSecs = (int)((loadTime - database.saveTime) * 86400);

            age = database.age;
            strength = database.strength;
            intelligence = database.intelligence;
            luck = database.luck;
            charisma = database.charisma;
            petName = database.petName;
            hunger = database.hunger;
            weight = database.weight;
            money = database.money;
            lifetimeMoney = database.lifetimeMoney;
            profession = database.profession;
            salary = database.salary;
            timeAliveInSecs = database.timeAliveInSecs;
            salarySecs = salary / 3600.0;
            ShopData.refreshTimer = database.refreshTimer;

            foodInventory = database.foodInventory;
            foodQuantities = database.foodQuantities;
            foodSpriteIndex = database.foodSpriteIndex;

            ShopData.currentNames = database.currentNames;
            ShopData.currentCosts = database.currentCosts;
            ShopData.currentSpriteIndex = database.currentSpriteIndex;

            ShopData.soldStatus = database.soldStatus;
            ShopData.inventoryIndices = database.inventoryIndices;

            foodInventorySprites.Clear();
            foodInventorySprites.Add(foodSprites[0]);

            //the purchased foods sprites
            foreach (int i in foodSpriteIndex)
                foodInventorySprites.Add(ShopData.inventorySprites[i]);

            for (int i = 0; i < ShopData.currentSpriteIndex.Length; i++)
                ShopData.currentSprites[i] = ShopData.inventorySprites[ShopData.currentSpriteIndex[i]];

            itemInventory = database.itemInventory;
            itemQuantities = database.itemQuantities;
            itemSpriteIndex = database.itemSpriteIndex;

            itemSprites.Clear();

            //inserts sprites for purchased items
            foreach (int i in itemSpriteIndex)
                itemSprites.Add(ShopData.inventorySprites[i]);


            double hungerBeforeUpdate = hunger;
            double timeBeforeHungerReachedZero = elapsedTimeSecs;

            //update stats based on offline time calculations:
            timeAliveInSecs += elapsedTimeSecs;

            hunger -= hungerDecrement * elapsedTimeSecs;
            if (hunger < 0)
            {
                hunger = 0;
                timeBeforeHungerReachedZero = hungerBeforeUpdate / hungerDecrement;
            }

            double moneyToAdd = (salary / 3600.0) * timeBeforeHungerReachedZero;
            money += moneyToAdd;
            lifetimeMoney += moneyToAdd;

            weight -= weightDecrement * elapsedTimeSecs;
            if (weight < 0)
                weight = 0;

            ShopData.refreshTimer -= elapsedTimeSecs;
            if (ShopData.refreshTimer <= 0)
            {
                ShopData.refreshTimer = 14400;
                ShopData.RefreshShop();
            }
        }
    }

    private void OnApplicationPause()
    {

    }

    private void OnApplicationFocus(bool focus)
    {

    }

    public static void CalculateProfession()
    {
        if (strength >= intelligence && strength >= luck && strength >= charisma)
        {
            if (intelligence >= luck && intelligence >= charisma)
            {
                //strength and intelligence
                profession = "Boss";
                salary = 550;
            }
            else if (luck >= intelligence && luck >= charisma)
            {
                //strength and luck
                profession = "Pirate";
                salary = 675;
            }
            else if (charisma >= intelligence && charisma >= luck)
            {
                //strength and charisma
                profession = "Athlete";
                salary = 510;
            }
        }
        else if (intelligence >= strength && intelligence >= luck && intelligence >= charisma)
        {
            if (strength >= luck && strength >= charisma)
            {
                //intelligence and strength
                profession = "Captain";
                salary = 560;
            }
            else if (luck >= strength && luck >= charisma)
            {
                //intelligence and luck
                profession = "Scientist";
                salary = 525;
            }
            else if (charisma >= strength && charisma >= luck)
            {
                //intelligence and charisma
                profession = "King";
                salary = 650;
            }
        }
        else if (luck >= strength && luck >= intelligence && luck >= charisma)
        {
            if (strength >= intelligence && strength >= charisma)
            {
                //luck and strength
                profession = "Rogue";
                salary = 515;
            }
            else if (intelligence >= strength && intelligence >= charisma)
            {
                //luck and intelligence
                profession = "Gambler";
                salary = 625;
            }
            else if (charisma >= strength && charisma >= luck)
            {
                //luck and charisma
                profession = "Idol";
                salary = 590;
            }
        }
        else if (charisma >= strength && charisma >= intelligence && charisma >= luck)
        {
            if (strength >= intelligence && strength >= luck)
            {
                //charisma and strength
                profession = "Wrestler";
                salary = 500;
            }
            else if (intelligence >= strength && intelligence >= luck)
            {
                //charisma and intelligence
                profession = "Spy";
                salary = 535;
            }
            else if (luck >= strength && luck >= intelligence)
            {
                //charisma and luck
                profession = "Celebrity";
                salary = 575;
            }
        }
        salary += (strength + intelligence + luck + charisma) / 4;
    }
}
