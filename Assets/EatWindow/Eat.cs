using UnityEngine;

public class Eat : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click"));
        int index = EatMenuManager.current;
        string eaten = Data.foodInventory[index];

        if(eaten == "Bread")
        {
            Data.hunger += 12;
            Data.weight += 2;
        }
        else if (eaten == "Bean")
            Data.hunger += 5;
        else if (eaten == "The Mighty Bean")
        {
            Data.hunger = 100;
            Data.weight = 5;
            Data.strength += 999;
        }
        else if (eaten == "Baby Ice Cream")
        {
            Data.hunger += 10;
            Data.weight += 0.5f;
        }
        else if (eaten == "Summer Ice Cream")
        {
            Data.hunger += 20;
            Data.weight += 1;
        }
        else if (eaten == "Lich's Ice Cream")
        {
            Data.hunger += 45;
            Data.weight += 1.5f;
        }
        else if (eaten == "Delicious Ice Cream")
        {
            Data.hunger += 50;
            Data.weight += 2;
            Data.charisma += 1;
        }
        else if (eaten == "Above Average Ice Cream")
        {
            Data.hunger += 75;
            Data.weight += 4;
            Data.intelligence += 5;
        }
        else if (eaten == "Perfected Ice Cream")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.strength += 3;
            Data.intelligence += 3;
            Data.charisma += 3;
            Data.luck += 3;
        }
        else if (eaten == "Common Bananas")
        {
            Data.hunger += 15;
            Data.weight += 0.5f;
        }
        else if (eaten == "Misshapen Bananas")
            Data.hunger += 25;
        else if (eaten == "Merchant's Bananas")
        {
            Data.hunger += 25;
            Data.weight += 0.5f;
            Data.intelligence += 1;
        }
        else if (eaten == "Ceremonial Bananas")
        {
            Data.hunger += 35;
            Data.weight += 0.5f;
            Data.luck += 1;
        }
        else if (eaten == "Ladylike Bananas")
        {
            Data.hunger += 50;
            Data.weight += 1;
            Data.charisma += 3;
        }
        else if (eaten == "Ascended Bananas")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.intelligence += 3;
            Data.luck += 3;
        }
        else if (eaten == "Lewd Bananas")
        {
            Data.hunger = 100;
            Data.weight += 0.5f;
            Data.charisma += 50;
        }
        else if (eaten == "Suspicious Orange")
        {
            Data.hunger += 35;
            Data.weight += 0.7f;
            Data.luck += 1;
        }
        else if (eaten == "Chivalrous Orange")
        {
            Data.hunger += 35;
            Data.weight += 0.1f;
            Data.charisma += 1;
        }
        else if (eaten == "Silent Orange")
        {
            Data.hunger += 50;
            Data.weight += 0.5f;
            Data.luck += 1;
        }
        else if (eaten == "Colossal Orange")
        {
            Data.hunger += 80;
            Data.weight += 0.6f;
            Data.strength += 1;
        }
        else if (eaten == "Rare Orange")
        {
            Data.hunger += 85;
            Data.weight += 1;
            Data.luck += 4;
        }
        else if (eaten == "Heroic Orange")
        {
            Data.hunger = 100;
            Data.weight += 1.2f;
            Data.strength += 30;
            Data.intelligence += 30;
            Data.luck += 1;
            Data.charisma += 1;
        }
        else if (eaten == "Somewhat Annoying Orange")
        {
            Data.hunger += 25;
            Data.strength += 25;
            Data.intelligence += 25;
            Data.charisma += 25;
            Data.luck += 25;
        }
        else if (eaten == "Donut of Wrath")
        {
            Data.hunger += 50;
            Data.weight += 0.1f;
            Data.strength += 52;
        }
        else if (eaten == "Donut of Truth")
        {
            Data.hunger += 50;
            Data.weight += 0.1f;
            Data.intelligence += 52;
        }
        else if (eaten == "Donut Grapes")
        {
            Data.hunger = 75;
            Data.weight += 0.7f;
            Data.luck += 53;
        }
        else if (eaten == "Donut Grapes")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.strength += 50;
            Data.luck += 50;
            Data.intelligence += 2;
        }
        else if (eaten == "Stinky Pizza")
        {
            Data.hunger = 100;
            Data.weight += 1;
        }
        else if (eaten == "Ordinary Pizza")
        {
            Data.hunger += 25;
            Data.weight += 0.5f;
        }
        else if (eaten == "Strange Pizza")
        {
            Data.hunger += 50;
            Data.weight += 1;
            Data.luck += 1;
        }
        else if (eaten == "Power Pizza")
        {
            Data.hunger += 25;
            Data.weight += 1;
            Data.strength += 1;
        }
        else if (eaten == "Mega Pizza")
        {
            Data.hunger += 50;
            Data.weight += 0.7f;
            Data.strength += 1;
        }
        else if (eaten == "Magical Pizza")
        {
            Data.hunger = 100;
            Data.intelligence += 1;
        }
        else if (eaten == "Wild Pizza")
        {
            Data.hunger += 75;
            Data.weight += 0.3f;
            Data.strength += 2;
        }
        else if (eaten == "Einstein's Pizza")
        {
            Data.hunger += 40;
            Data.weight += 1;
            Data.intelligence += 5;
        }
        else if (eaten == "16th Century Pizza")
        {
            Data.hunger = 100;
            Data.weight += 0.1f;
            Data.strength += 5;
        }
        else if (eaten == "Mayan Pizza")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.strength += 6;
            Data.charisma += 5;
        }
        else if (eaten == "Cursed Cheese")
        {
            Data.hunger += 25;
            Data.weight += 1;
        }
        else if (eaten == "Stinky Cheese")
        {
            Data.hunger = 100;
            Data.weight += 1;
        }
        else if (eaten == "Epic Cheese")
        {
            Data.hunger += 50;
            Data.weight += 0.3f;
        }
        else if (eaten == "Old Cheese")
        {
            Data.hunger += 55;
            Data.weight += 0.2f;
        }
        else if (eaten == "Zombie Cheese")
        {
            Data.hunger += 70;
            Data.weight += 1;
            Data.strength += 1;
        }
        else if (eaten == "Healthy Cheese")
        {
            Data.hunger += 90;
            Data.weight += 0.5f;
            Data.charisma += 1;
        }
        else if (eaten == "Superior Cheese")
        {
            Data.hunger += 95;
            Data.weight += 1;
            Data.charisma += 1;
        }
        else if (eaten == "Hearty Cheese")
        {
            Data.hunger = 100;
            Data.weight += 1.2f;
            Data.strength += 1;
            Data.charisma += 1;
        }
        else if (eaten == "Peter's Cheese")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.strength += 2;
            Data.intelligence += 2;
            Data.charisma += 2;
            Data.luck += 2;
        }
        else if (eaten == "Cheese of the Heavens")
        {
            Data.hunger = 100;
            Data.weight += 0.5f;
            Data.intelligence += 200;
            Data.charisma += 200;
            Data.luck += 200;
        }
        else if (eaten == "Legendary Cheese")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.strength += 500;
            Data.luck += 250;
        }
        else if (eaten == "Bad Apple")
        {
            Data.hunger += 25;
            Data.weight += 0.7f;
        }
        else if (eaten == "Dusty Apple")
        {
            Data.hunger += 30;
            Data.weight += 0.7f;
        }
        else if (eaten == "Average Apple")
        {
            Data.hunger += 40;
            Data.weight += 0.5f;
        }
        else if (eaten == "Destiny Apple")
        {
            Data.hunger += 50;
            Data.weight += 0.7f;
            Data.luck += 2;
        }
        else if (eaten == "Yummy Apple")
        {
            Data.hunger += 65;
            Data.weight += 0.6f;
            Data.charisma += 2;
        }
        else if (eaten == "Mysterious Apple")
        {
            Data.hunger = 100;
            Data.weight += 1.5f;
            Data.luck += 3;
        }
        else if (eaten == "Extremely Suspicious Apple")
        {
            Data.hunger += 10;
            Data.weight += 0.5f;
            Data.strength += 2;
            Data.intelligence += 2;
        }
        else if (eaten == "Serious Apple")
        {
            Data.hunger += 50;
            Data.weight += 1;
            Data.luck += 3;
        }
        else if (eaten == "Popular Apple")
        {
            Data.hunger += 90;
            Data.weight += 2;
            Data.charisma += 4;
        }
        else if (eaten == "Angelic Apple")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.charisma += 3;
            Data.luck += 3;
        }
        else if (eaten == "Adam's Apple")
        {
            Data.hunger += 50;
            Data.weight += 0.3f;
            Data.strength += 5;
            Data.charisma += 5;
            Data.luck += 2;
        }
        else if (eaten == "Hard Hot Dog")
        {
            Data.hunger += 25;
            Data.weight += 1;
        }
        else if (eaten == "Frozen Hot Dog")
        {
            Data.hunger += 35;
            Data.weight += 0.8f;
        }
        else if (eaten == "Sweet Hot Dog")
        {
            Data.hunger += 40;
            Data.weight += 2;
            Data.charisma += 1;
        }
        else if (eaten == "Sour Hot Dog")
        {
            Data.hunger += 40;
            Data.weight += 2;
            Data.intelligence += 1;
        }
        else if (eaten == "Forgettable Hot Dog")
            Data.hunger = 100;
        else if (eaten == "Lovely Hot Dog")
        {
            Data.hunger += 70;
            Data.weight += 1;
            Data.charisma += 1;
        }
        else if (eaten == "Dreamy Hot Dog")
        {
            Data.hunger += 70;
            Data.weight += 1;
            Data.charisma += 2;
        }
        else if (eaten == "Best Friend")
        {
            Data.charisma += 2;
            Data.luck += 2;
        }
        else if (eaten == "Enchanting Hot Dog")
        {
            Data.hunger = 100;
            Data.weight += 1.5f;
            Data.strength += 1;
            Data.charisma += 3;
        }
        else if (eaten == "Cool Chocolate")
        {
            Data.hunger += 25;
            Data.weight += 1;
        }
        else if (eaten == "Not-Cool Chocolate")
        {
            Data.hunger += 10;
            Data.weight += 10;
            Data.intelligence += 10;
        }
        else if (eaten == "Funky Chocolate")
        {
            Data.hunger += 40;
            Data.weight += 1;
            Data.charisma += 2;
        }
        else if (eaten == "Chocolate of the Void")
        {
            Data.hunger += 60;
            Data.weight += 1;
            Data.strength += 2;
        }
        else if (eaten == "Pocket Chocolate")
        {
            Data.hunger += 60;
            Data.weight += 0.7f;
            Data.luck += 2;
        }
        else if (eaten == "Funny Chocolate")
        {
            Data.hunger += 10;
            Data.weight += 0.1f;
            Data.charisma += 3;
        }
        else if (eaten == "King's Chocolate")
        {
            Data.hunger += 75;
            Data.weight += 0.6f;
            Data.strength += 2;
            Data.charisma += 1;
        }
        else if (eaten == "Eternal Chocolate")
        {
            Data.hunger = 100;
            Data.weight += 1;
            Data.intelligence += 4;
            Data.luck += 7;
        }
        else if (eaten == "Abyssal Chocolate")
        {
            Data.hunger = 100;
            Data.weight += 0.7f;
            Data.strength += 15;
            Data.luck += 1;
        }
        else if (eaten == "Dragon's Chocolate")
        {
            Data.hunger = 100;
            Data.weight += 5;
            Data.strength += 20;
        }
        else if (eaten == "Depressed Burger")
        {
            Data.hunger += 10;
            Data.weight += 0.2f;
            Data.intelligence += 1;
        }
        else if (eaten == "Quirky Burger")
        {
            Data.hunger += 33;
            Data.weight += 0.87f;
            Data.charisma += 1;
            Data.strength += 1;
        }
        else if (eaten == "Hairy Burger")
        {
            Data.hunger += 40;
            Data.weight += 0.1f;
        }
        else if (eaten == "Disguised Burger")
        {
            Data.hunger += 50;
            Data.weight += 1;
            Data.intelligence += 2;
            Data.charisma += 1;
            Data.luck += 1;
        }
        else if (eaten == "Environmental Burger")
        {
            Data.hunger += 55;
            Data.weight += 0.9f;
            Data.intelligence += 3;
        }
        else if (eaten == "Flying Burger")
        {
            Data.hunger += 70;
            Data.weight += 2;
            Data.strength += 5;
            Data.luck += 1;
        }
        else if (eaten == "Strong Burger")
        {
            Data.hunger += 70;
            Data.weight += 3;
            Data.strength += 7;
        }
        else if (eaten == "Charming Burger")
        {
            Data.hunger += 40;
            Data.weight += 0.2f;
            Data.charisma += 10;
        }
        
        //if the eaten food is not an infinite quantity food
        if (Data.foodQuantities[index] != -1)
        {
            Data.foodQuantities[index]--;

            //if the food quantity is zero after eating it
            if (Data.foodQuantities[index] == 0)
            {
                Data.foodQuantities.RemoveAt(index);
                Data.foodInventory.RemoveAt(index);
                Data.foodInventorySprites.RemoveAt(index);
                Data.foodSpriteIndex.RemoveAt(index);
            }
            EatMenuManager.toBe--;
        }
    }
}
