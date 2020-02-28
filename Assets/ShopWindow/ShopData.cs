using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{

    private static ShopData instance;

    public static List<string> inventoryNames;
    public static string[] currentNames;
    public static List<int> inventoryCosts;
    public static int[] currentCosts;
    public static Sprite[] inventorySprites, currentSprites;
    public static int[] currentSpriteIndex;

    public static bool[] soldStatus;

    public static int[] inventoryIndices;
    public static int refreshTimer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        InvokeRepeating("EverySecond", 1.0f, 1.0f);

        //4 hours in seconds
        refreshTimer = 14400;

        inventorySprites = Resources.LoadAll<Sprite>("shop");
        inventoryNames = new List<string>();
        inventoryCosts = new List<int>();

        currentNames = new string[5];
        currentCosts = new int[5];
        currentSprites = new Sprite[5];
        currentSpriteIndex = new int[5];
        inventoryIndices = new int[5];
        soldStatus = new bool[5];

        inventoryNames.Add("Bean");
        inventoryCosts.Add(10);
        inventoryNames.Add("The Mighty Bean");
        inventoryCosts.Add(999999);

        inventoryNames.Add("Baby Ice Cream");
        inventoryCosts.Add(25);
        inventoryNames.Add("Summer Ice Cream");
        inventoryCosts.Add(250);
        inventoryNames.Add("Lich's Ice Cream");
        inventoryCosts.Add(500);
        inventoryNames.Add("Delicious Ice Cream");
        inventoryCosts.Add(600);
        inventoryNames.Add("Above Average Ice Cream");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Perfected Ice Cream");
        inventoryCosts.Add(9999);

        inventoryNames.Add("Common Bananas");
        inventoryCosts.Add(50);
        inventoryNames.Add("Misshapen Bananas");
        inventoryCosts.Add(100);
        inventoryNames.Add("Merchant's Bananas");
        inventoryCosts.Add(500);
        inventoryNames.Add("Ceremonial Bananas");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Ladylike Bananas");
        inventoryCosts.Add(2000);
        inventoryNames.Add("Ascended Bananas");
        inventoryCosts.Add(10000);
        inventoryNames.Add("Lewd Bananas");
        inventoryCosts.Add(49999);

        inventoryNames.Add("Suspicious Orange");
        inventoryCosts.Add(400);
        inventoryNames.Add("Chivalrous Orange");
        inventoryCosts.Add(500);
        inventoryNames.Add("Silent Orange");
        inventoryCosts.Add(600);
        inventoryNames.Add("Colossal Orange");
        inventoryCosts.Add(750);
        inventoryNames.Add("Rare Orange");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Heroic Orange");
        inventoryCosts.Add(60000);
        inventoryNames.Add("Somewhat Annoying Orange");
        inventoryCosts.Add(99999);

        inventoryNames.Add("Donut of Wrath");
        inventoryCosts.Add(49999);
        inventoryNames.Add("Donut of Truth");
        inventoryCosts.Add(49999);
        inventoryNames.Add("Sacred Donut");
        inventoryCosts.Add(49999);
        inventoryNames.Add("Godly Donut");
        inventoryCosts.Add(99999);

        inventoryNames.Add("Stinky Pizza");
        inventoryCosts.Add(10);
        inventoryNames.Add("Ordinary Pizza");
        inventoryCosts.Add(50);
        inventoryNames.Add("Strange Pizza");
        inventoryCosts.Add(100);
        inventoryNames.Add("Power Pizza");
        inventoryCosts.Add(250);
        inventoryNames.Add("Mega Pizza");
        inventoryCosts.Add(500);
        inventoryNames.Add("Magical Pizza");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Wild Pizza");
        inventoryCosts.Add(2500);
        inventoryNames.Add("Einstein's Pizza");
        inventoryCosts.Add(5000);
        inventoryNames.Add("16th Century Pizza");
        inventoryCosts.Add(6000);
        inventoryNames.Add("Mayan Pizza");
        inventoryCosts.Add(10000);

        inventoryNames.Add("Cursed Cheese");
        inventoryCosts.Add(50);
        inventoryNames.Add("Stinky Cheese");
        inventoryCosts.Add(60);
        inventoryNames.Add("Epic Cheese");
        inventoryCosts.Add(150);
        inventoryNames.Add("Old Cheese");
        inventoryCosts.Add(200);
        inventoryNames.Add("Zombie Cheese");
        inventoryCosts.Add(350);
        inventoryNames.Add("Healthy Cheese");
        inventoryCosts.Add(500);
        inventoryNames.Add("Superior Cheese");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Hearty Cheese");
        inventoryCosts.Add(1250);
        inventoryNames.Add("Peter's Cheese");
        inventoryCosts.Add(1800);
        inventoryNames.Add("Cheese of the Heavens");
        inventoryCosts.Add(300000);
        inventoryNames.Add("Legendary Cheese");
        inventoryCosts.Add(500000);

        inventoryNames.Add("Bad Apple");
        inventoryCosts.Add(100);
        inventoryNames.Add("Dusty Apple");
        inventoryCosts.Add(150);
        inventoryNames.Add("Average Apple");
        inventoryCosts.Add(250);
        inventoryNames.Add("Alright Apple");
        inventoryCosts.Add(300);
        inventoryNames.Add("Destiny Apple");
        inventoryCosts.Add(500);
        inventoryNames.Add("Yummy Apple");
        inventoryCosts.Add(750);
        inventoryNames.Add("Mysterious Apple");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Extremely Suspicious Apple");
        inventoryCosts.Add(1300);
        inventoryNames.Add("Serious Apple");
        inventoryCosts.Add(1800);
        inventoryNames.Add("Popular Apple");
        inventoryCosts.Add(2500);
        inventoryNames.Add("Angelic Apple");
        inventoryCosts.Add(6000);
        inventoryNames.Add("Adam's Apple");
        inventoryCosts.Add(9999);

        inventoryNames.Add("Hard Hot Dog");
        inventoryCosts.Add(25);
        inventoryNames.Add("Frozen Hot Dog");
        inventoryCosts.Add(300);
        inventoryNames.Add("Sweet Hot Dog");
        inventoryCosts.Add(305);
        inventoryNames.Add("Sour Hot Dog");
        inventoryCosts.Add(325);
        inventoryNames.Add("Forgettable Hot Dog");
        inventoryCosts.Add(565);
        inventoryNames.Add("Lovely Hot Dog");
        inventoryCosts.Add(765);
        inventoryNames.Add("Dreamy Hot Dog");
        inventoryCosts.Add(855);
        inventoryNames.Add("Best Friend");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Enchanting Hot Dog");
        inventoryCosts.Add(2500);

        inventoryNames.Add("Cool Chocolate");
        inventoryCosts.Add(100);
        inventoryNames.Add("Not-Cool Chocolate");
        inventoryCosts.Add(500);
        inventoryNames.Add("Funky Chocolate");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Chocolate of the Void");
        inventoryCosts.Add(1250);
        inventoryNames.Add("Pocket Chocolate");
        inventoryCosts.Add(1500);
        inventoryNames.Add("Funny Chocolate");
        inventoryCosts.Add(1750);
        inventoryNames.Add("King's Chocolate");
        inventoryCosts.Add(1900);
        inventoryNames.Add("Eternal Chocolate");
        inventoryCosts.Add(10000);
        inventoryNames.Add("Abyssal Chocolate");
        inventoryCosts.Add(15000);
        inventoryNames.Add("Dragon's Chocolate");
        inventoryCosts.Add(17500);

        inventoryNames.Add("Depressed Burger");
        inventoryCosts.Add(775);
        inventoryNames.Add("Quirky Burger");
        inventoryCosts.Add(831);
        inventoryNames.Add("Hairy Burger");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Disguised Burger");
        inventoryCosts.Add(2600);
        inventoryNames.Add("Environmental Burger");
        inventoryCosts.Add(3000);
        inventoryNames.Add("Flying Burger");
        inventoryCosts.Add(5000);
        inventoryNames.Add("Strong Burger");
        inventoryCosts.Add(6000);
        inventoryNames.Add("Wide Burger");
        inventoryCosts.Add(8000);
        inventoryNames.Add("Charming Burger");
        inventoryCosts.Add(10000);

        inventoryNames.Add("Light Dumbbell");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Huge Dumbbell");
        inventoryCosts.Add(2500);
        inventoryNames.Add("Heavy Dumbbell");
        inventoryCosts.Add(3500);
        inventoryNames.Add("Professional Dumbbell");
        inventoryCosts.Add(5000);
        inventoryNames.Add("Time Travelling Dumbbell");
        inventoryCosts.Add(35000);

        inventoryNames.Add("Small Protein Powder");
        inventoryCosts.Add(900);
        inventoryNames.Add("Dense Protein Powder");
        inventoryCosts.Add(1900);
        inventoryNames.Add("Smart Protein Powder");
        inventoryCosts.Add(5000);

        inventoryNames.Add("Old Newspaper");
        inventoryCosts.Add(500);
        inventoryNames.Add("Shiny Newspaper");
        inventoryCosts.Add(1250);
        inventoryNames.Add("Future Newspaper");
        inventoryCosts.Add(2000);
        inventoryNames.Add("Forgotten Newspaper");
        inventoryCosts.Add(2800);
        inventoryNames.Add("Torn Newspaper");
        inventoryCosts.Add(4000);
        inventoryNames.Add("Newspaper of God");
        inventoryCosts.Add(20000);

        inventoryNames.Add("Children's Textbook");
        inventoryCosts.Add(250);
        inventoryNames.Add("Intermediate Textbook");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Advanced Textbook");
        inventoryCosts.Add(1800);
        inventoryNames.Add("Textbook of Truth");
        inventoryCosts.Add(2500);
        inventoryNames.Add("Textbook of Eden");
        inventoryCosts.Add(5000);
        inventoryNames.Add("Textbook of Atlantis");
        inventoryCosts.Add(6100);
        inventoryNames.Add("Textbook of Zeus");
        inventoryCosts.Add(9000);

        inventoryNames.Add("Unlucky Charm");
        inventoryCosts.Add(400);
        inventoryNames.Add("Undead Charm");
        inventoryCosts.Add(900);
        inventoryNames.Add("Nostalgic Charm");
        inventoryCosts.Add(1900);
        inventoryNames.Add("Hero's Charm");
        inventoryCosts.Add(2850);
        inventoryNames.Add("Mystical Charm");
        inventoryCosts.Add(3750);
        inventoryNames.Add("Lucky Charm");
        inventoryCosts.Add(6000);
        inventoryNames.Add("Charming Charm");
        inventoryCosts.Add(9000);

        inventoryNames.Add("Four-Leaf Clover");
        inventoryCosts.Add(25000);

        inventoryNames.Add("Typical Wishbone");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Super Wishbone");
        inventoryCosts.Add(1950);
        inventoryNames.Add("Unleashed Wishbone");
        inventoryCosts.Add(3000);
        inventoryNames.Add("Reinforced Wishbone");
        inventoryCosts.Add(4000);
        inventoryNames.Add("Unique Wishbone");
        inventoryCosts.Add(5100);

        inventoryNames.Add("Small Mirror");
        inventoryCosts.Add(890);
        inventoryNames.Add("Dull Mirror");
        inventoryCosts.Add(1100);
        inventoryNames.Add("Cursed Mirror");
        inventoryCosts.Add(1200);
        inventoryNames.Add("Enchanted Mirror");
        inventoryCosts.Add(1900);
        inventoryNames.Add("Ice Mirror");
        inventoryCosts.Add(2100);
        inventoryNames.Add("Goblin's Mirror");
        inventoryCosts.Add(3500);
        inventoryNames.Add("Angel's Mirror");
        inventoryCosts.Add(5000);
        inventoryNames.Add("Talking Mirror");
        inventoryCosts.Add(9000);

        inventoryNames.Add("Cheap Make-up");
        inventoryCosts.Add(900);
        inventoryNames.Add("Smelly Make-up");
        inventoryCosts.Add(1100);
        inventoryNames.Add("Basic Make-up");
        inventoryCosts.Add(1500);
        inventoryNames.Add("Classic Make-up");
        inventoryCosts.Add(2000);
        inventoryNames.Add("Treasured Make-up");
        inventoryCosts.Add(3250);
        inventoryNames.Add("Princesses' Make-up");
        inventoryCosts.Add(8500);
        inventoryNames.Add("Queen's Make-up");
        inventoryCosts.Add(10000);
        inventoryNames.Add("Mermaid's Make-up");
        inventoryCosts.Add(12500);
        inventoryNames.Add("Goddess' Make-up");
        inventoryCosts.Add(69999);

        inventoryNames.Add("Mysterious Pill");
        inventoryCosts.Add(250);
        inventoryNames.Add("Suspicious Pill");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Weight Loss Pill");
        inventoryCosts.Add(1000);
        inventoryNames.Add("Chosen Pill");
        inventoryCosts.Add(1500);
        inventoryNames.Add("Camouflaged Pill");
        inventoryCosts.Add(1750);
        inventoryNames.Add("Peasant's Pill");
        inventoryCosts.Add(1800);
        inventoryNames.Add("Beauty Pill");
        inventoryCosts.Add(2000);
        inventoryNames.Add("Fullness Pill");
        inventoryCosts.Add(2500);
        inventoryNames.Add("Ancient Pill");
        inventoryCosts.Add(3000);
        inventoryNames.Add("Maiden's Pill");
        inventoryCosts.Add(3350);
        inventoryNames.Add("Cloud Pill");
        inventoryCosts.Add(3500);
        inventoryNames.Add("Earthly Pill");
        inventoryCosts.Add(3750);
        inventoryNames.Add("Spicy Pill");
        inventoryCosts.Add(4000);
        inventoryNames.Add("Pill of Nature");
        inventoryCosts.Add(4444);
        inventoryNames.Add("Sky Pill");
        inventoryCosts.Add(4500);
        inventoryNames.Add("Tribal Pill");
        inventoryCosts.Add(5000);
        inventoryNames.Add("The Equalizer");
        inventoryCosts.Add(5555);
        inventoryNames.Add("Knight's Pill");
        inventoryCosts.Add(6000);
        inventoryNames.Add("King's Pill");
        inventoryCosts.Add(9000);
        inventoryNames.Add("Ultimate Pill");
        inventoryCosts.Add(9999);
        inventoryNames.Add("Transcendent Pill");
        inventoryCosts.Add(1800);
        inventoryNames.Add("Pill of Death");
        inventoryCosts.Add(50000);
        inventoryNames.Add("Spiritual Pill");
        inventoryCosts.Add(66666);
        inventoryNames.Add("Forbidden Pill");
        inventoryCosts.Add(66666);
        inventoryNames.Add("Celestial Pill");
        inventoryCosts.Add(99999);
        inventoryNames.Add("Holy Pill");
        inventoryCosts.Add(199999);
        inventoryNames.Add("?????");
        inventoryCosts.Add(499999);
        inventoryNames.Add("Devil's Pill");
        inventoryCosts.Add(666666);
        inventoryNames.Add("God's Pill");
        inventoryCosts.Add(999999);

        inventoryNames.Add("Job Application");
        inventoryCosts.Add(100000);

        RefreshShop();
    }

    void EverySecond()
    {
        refreshTimer = getSecondsLeft();

        if(refreshTimer == 0)
        {
            RefreshShop();
        }
    }

    public static void RefreshShop()
    {
        for(int i = 0; i < 5; i++)
        {
            int itemIndex = UnityEngine.Random.Range(0, inventoryNames.Count);
            currentNames[i] = inventoryNames[itemIndex];
            currentCosts[i] = inventoryCosts[itemIndex];
            currentSprites[i] = returnSprite(itemIndex);
            currentSpriteIndex[i] = returnSpriteIndex(itemIndex);
            inventoryIndices[i] = itemIndex;
            soldStatus[i] = false;
        }
    }

    public static Sprite returnSprite(int itemIndex)
    {
        if (itemIndex <= 1)
            return inventorySprites[0];
        else if (itemIndex <= 7)
            return inventorySprites[1];
        else if (itemIndex <= 14)
            return inventorySprites[2];
        else if (itemIndex <= 21)
            return inventorySprites[3];
        else if (itemIndex <= 25)
            return inventorySprites[4];
        else if (itemIndex <= 35)
            return inventorySprites[5];
        else if (itemIndex <= 46)
            return inventorySprites[6];
        else if (itemIndex <= 58)
            return inventorySprites[7];
        else if (itemIndex <= 67)
            return inventorySprites[8];
        else if (itemIndex <= 77)
            return inventorySprites[9];
        else if (itemIndex <= 86)
            return inventorySprites[10];
        else if (itemIndex <= 91)
            return inventorySprites[11];
        else if (itemIndex <= 94)
            return inventorySprites[12];
        else if (itemIndex <= 100)
            return inventorySprites[13];
        else if (itemIndex <= 107)
            return inventorySprites[14];
        else if (itemIndex <= 114)
            return inventorySprites[15];
        else if (itemIndex == 115)
            return inventorySprites[16];
        else if (itemIndex <= 120)
            return inventorySprites[17];
        else if (itemIndex <= 128)
            return inventorySprites[18];
        else if (itemIndex <= 137)
            return inventorySprites[19];
        else if (itemIndex <= 166)
            return inventorySprites[20];
        else
            return inventorySprites[21];
    }

    public static int returnSpriteIndex(int itemIndex)
    {
        if (itemIndex <= 1)
            return 0;
        else if (itemIndex <= 7)
            return 1;
        else if (itemIndex <= 14)
            return 2;
        else if (itemIndex <= 21)
            return 3;
        else if (itemIndex <= 25)
            return 4;
        else if (itemIndex <= 35)
            return 5;
        else if (itemIndex <= 46)
            return 6;
        else if (itemIndex <= 58)
            return 7;
        else if (itemIndex <= 67)
            return 8;
        else if (itemIndex <= 77)
            return 9;
        else if (itemIndex <= 86)
            return 10;
        else if (itemIndex <= 91)
            return 11;
        else if (itemIndex <= 94)
            return 12;
        else if (itemIndex <= 100)
            return 13;
        else if (itemIndex <= 107)
            return 14;
        else if (itemIndex <= 114)
            return 15;
        else if (itemIndex == 115)
            return 16;
        else if (itemIndex <= 120)
            return 17;
        else if (itemIndex <= 128)
            return 18;
        else if (itemIndex <= 137)
            return 19;
        else if (itemIndex <= 166)
            return 20;
        else
            return 21;
    }

    //Returns time in seconds until the next 4th hour (0, 4, 8, 12, 16, 20, 24) (except 1 second before e.g. 3:59:59)
    public static int getSecondsLeft()
    {
        DateTime now = DateTime.Now;

        int targetSec = (((((DateTime.Now.Hour / 4) + 1) * 4) - 1) * 60 * 60) + 59 * 60 + 59;
        int nowSec = now.Hour * 60 * 60 + now.Minute * 60 + now.Second;

        return targetSec - nowSec;
    }
}
