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
    public static int initialSalary;
    public static int salary;

    public static double saveTime;

    public static double hungerDecrement, weightDecrement;

    public static int timeAliveInSecs;
    public static double salarySecs;

    public static Sprite[] petSprites;
    public static int spriteNum;
    public static int bestFriendNum = 0;

    private int timesOpened = 0;

    public AudioClip[] songs;
    AudioSource soundtrack;

    private void Awake()
    {
        //Ensures that there is only one instance of "Data" at a time.
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
        //Initial values, necessary calls at the beginning.
        DontDestroyOnLoad(this.gameObject);
        hungerDecrement = 100.0 / 86400.0;
        weightDecrement = 1.0 / 3600.0;

        LoadGame();
        timesOpened++;
        InvokeRepeating("SaveGame", 1.0f, 1.0f);
        InvokeRepeating("EverySecond", 1.0f, 1.0f);

        songs = Resources.LoadAll<AudioClip>("sounds/songs");
        soundtrack = GetComponent<AudioSource>();
        PlayNextSong();

    }

    // Update is called once per frame
    void Update()
    {
        //Ensures certain values never go above/below a certain point.
        if (bestFriendNum < 0)
            bestFriendNum = 0;
        if (hunger > 100)
            hunger = 100;
    }

    //Plays a random song in the playlist. After the song finishes, do it again.
    void PlayNextSong()
    {
        soundtrack.clip = songs[UnityEngine.Random.Range(0, songs.Length)];
        soundtrack.Play();
        Invoke("PlayNextSong", soundtrack.clip.length);
    }

    //Adjusts stats every second (e.g. hunger decreases every second)
    void EverySecond()
    {
        if (hunger > 0)
        {
            hunger -= hungerDecrement;
            money += salarySecs;
            lifetimeMoney += salarySecs;
        }
        if (weight > 0)
            weight -= weightDecrement;
        timeAliveInSecs++;
        salary = initialSalary + ((strength + intelligence + luck + charisma) / 4) + bestFriendNum * 5;
        age = timeAliveInSecs / 86400;
    }

    //Simply saves the game. This is called every second and when the game is closed.
    public static void SaveGame()
    {
        saveTime = System.DateTime.Now.ToOADate();
        SaveSystem.SaveData();
    }

    //Loads the game. Called on start, and when app is brought to foreground.
    public static void LoadGame()
    {
        double loadTime = System.DateTime.Now.ToOADate();

        Database database = SaveSystem.LoadData();

        foodInventory = new List<string>();
        foodQuantities = new List<int>();
        foodInventorySprites = new List<Sprite>();
        foodSpriteIndex = new List<int>();
        itemInventory = new List<string>();
        itemQuantities = new List<int>();
        itemSprites = new List<Sprite>();
        itemSpriteIndex = new List<int>();

        foodSprites = Resources.LoadAll<Sprite>("food");

        //adds the bread sprite
        foodInventorySprites.Add(foodSprites[0]);

        foodInventory.Add("Bread");
        foodQuantities.Add(-1);

        //If this is the first time opening the game
        if (database == null)
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
            initialSalary = 100;
            timeAliveInSecs = 0;
            salarySecs = salary / 3600.0;
            bestFriendNum = 0;
            spriteNum = UnityEngine.Random.Range(1, 4);

            SceneManager.LoadScene("EnterName");
        }
        else
        {
            int elapsedTimeSecs = (int)((loadTime - database.saveTime) * 86400);
            int nowHour = System.DateTime.Now.Hour;

            //Loads all the stats from the saved file.
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
            initialSalary = database.initialSalary;
            salary = database.salary;
            timeAliveInSecs = database.timeAliveInSecs;
            salarySecs = salary / 3600.0;
            spriteNum = database.spriteNum;
            ShopData.refreshTimer = database.refreshTimer;
            bestFriendNum = database.bestFriendNum;

            foodInventory = database.foodInventory;
            foodQuantities = database.foodQuantities;
            foodSpriteIndex = database.foodSpriteIndex;

            ShopData.currentNames = database.currentNames;
            ShopData.currentCosts = database.currentCosts;
            ShopData.currentSpriteIndex = database.currentSpriteIndex;

            ShopData.soldStatus = database.soldStatus;
            ShopData.inventoryIndices = database.inventoryIndices;

            //Loads the purchased foods sprites
            foreach (int i in foodSpriteIndex)
                foodInventorySprites.Add(ShopData.inventorySprites[i]);

            for (int i = 0; i < ShopData.currentSpriteIndex.Length; i++)
                ShopData.currentSprites[i] = ShopData.inventorySprites[ShopData.currentSpriteIndex[i]];

            itemInventory = database.itemInventory;
            itemQuantities = database.itemQuantities;
            itemSpriteIndex = database.itemSpriteIndex;

            itemSprites.Clear();

            //Inserts sprites for purchased items
            foreach (int i in itemSpriteIndex)
                itemSprites.Add(ShopData.inventorySprites[i]);

            double hungerBeforeUpdate = hunger;
            double timeBeforeHungerReachedZero = elapsedTimeSecs;

            //Update stats based on offline time calculations:
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

            //If enough time has passed, then reset the shop.
            if(database.refreshTimer <= elapsedTimeSecs)
            {
                ShopData.RefreshShop();
            }

            ShopData.refreshTimer = ShopData.getSecondsLeft();
            

            //If the pet is old enough for evolution and has not yet evolved, then evolve and get a job
            if(age >= 5 && spriteNum <= 3)
            {
                spriteNum = UnityEngine.Random.Range(4, 10);
                CalculateProfession();
                SaveGame();
            }
        }
        //Loads pet sprites
        petSprites = Resources.LoadAll<Sprite>("pets/pet_" + spriteNum);
    }

    private void OnApplicationPause(bool pause)
    {
        //When user closes app
        if(pause)
        {
            SaveGame();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        //When the user opens the app
        if(focus && timesOpened != 0)
        {
            LoadGame();
        } else if(!focus)
        {
            SaveGame();
        }
    }

    //Calculates the pet's profession from their highest two stats.
    public static void CalculateProfession()
    {
        if (strength >= intelligence && strength >= luck && strength >= charisma)
        {
            if (intelligence >= luck && intelligence >= charisma)
            {
                //strength and intelligence
                profession = "Boss";
                initialSalary = 550;
            }
            else if (luck >= intelligence && luck >= charisma)
            {
                //strength and luck
                profession = "Pirate";
                initialSalary = 675;
            }
            else if (charisma >= intelligence && charisma >= luck)
            {
                //strength and charisma
                profession = "Athlete";
                initialSalary = 510;
            }
        }
        else if (intelligence >= strength && intelligence >= luck && intelligence >= charisma)
        {
            if (strength >= luck && strength >= charisma)
            {
                //intelligence and strength
                profession = "Captain";
                initialSalary = 560;
            }
            else if (luck >= strength && luck >= charisma)
            {
                //intelligence and luck
                profession = "Scientist";
                initialSalary = 525;
            }
            else if (charisma >= strength && charisma >= luck)
            {
                //intelligence and charisma
                profession = "King";
                initialSalary = 650;
            }
        }
        else if (luck >= strength && luck >= intelligence && luck >= charisma)
        {
            if (strength >= intelligence && strength >= charisma)
            {
                //luck and strength
                profession = "Rogue";
                initialSalary = 515;
            }
            else if (intelligence >= strength && intelligence >= charisma)
            {
                //luck and intelligence
                profession = "Gambler";
                initialSalary = 625;
            }
            else if (charisma >= strength && charisma >= luck)
            {
                //luck and charisma
                profession = "Idol";
                initialSalary = 590;
            }
        }
        else if (charisma >= strength && charisma >= intelligence && charisma >= luck)
        {
            if (strength >= intelligence && strength >= luck)
            {
                //charisma and strength
                profession = "Wrestler";
                initialSalary = 500;
            }
            else if (intelligence >= strength && intelligence >= luck)
            {
                //charisma and intelligence
                profession = "Spy";
                initialSalary = 535;
            }
            else if (luck >= strength && luck >= intelligence)
            {
                //charisma and luck
                profession = "Celebrity";
                initialSalary = 575;
            }
        }
        //Pet's salary is increased based on their stats.
        salary = initialSalary + ((strength + intelligence + luck + charisma) / 4);
    }
}
