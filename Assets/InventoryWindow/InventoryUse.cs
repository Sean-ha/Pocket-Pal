using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUse : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click"));
        if (!InventoryManager.empty)
        {
            int index = InventoryManager.current;
            string used = Data.itemInventory[index];

            if (used == "Light Dumbbell")
                Data.strength += 1;
            else if (used == "Huge Dumbbell")
                Data.strength += 4;
            else if (used == "Heavy Dumbbell")
                Data.strength += 5;
            else if (used == "Professional Dumbbell")
                Data.strength += 9;
            else if (used == "Time Travelling Dumbbell")
                Data.strength += 45;
            else if (used == "Small Protein Powder")
                Data.strength += 1;
            else if (used == "Dense Protein Powder")
                Data.strength += 3;
            else if (used == "Smart Protein Powder")
            {
                Data.strength += 3;
                Data.intelligence += 8;
            }
            else if (used == "Old Newspaper")
                Data.intelligence += 1;
            else if (used == "Shiny Newspaper")
                Data.intelligence += 1;
            else if (used == "Future Newspaper")
                Data.intelligence += 2;
            else if (used == "Forgotten Newspaper")
                Data.intelligence += 4;
            else if (used == "Torn Newspaper")
                Data.intelligence += 6;
            else if (used == "Newspaper of God")
                Data.intelligence += 50;
            else if (used == "Children's Textbook")
                Data.intelligence += 0;
            else if (used == "Intermediate Textbook")
                Data.intelligence += 1;
            else if (used == "Advanced Textbook")
                Data.intelligence += 2;
            else if (used == "Textbook of Truth")
                Data.intelligence += 5;
            else if (used == "Textbook of Eden")
                Data.intelligence += 7;
            else if (used == "Textbook of Atlantis")
                Data.intelligence += 9;
            else if (used == "Textbook of Zeus")
                Data.intelligence += 14;
            else if (used == "Unlucky Charm")
                Data.luck += 0;
            else if (used == "Undead Charm")
                Data.luck += 1;
            else if (used == "Nostalgic Charm")
                Data.luck += 2;
            else if (used == "Hero's Charm")
                Data.luck += 5;
            else if (used == "Mystical Charm")
                Data.luck += 4;
            else if (used == "Lucky Charm")
                Data.luck += 15;
            else if (used == "Charming Charm")
            {
                Data.luck += 5;
                Data.charisma += 10;
            }
            else if (used == "Four-Leaf Clover")
                Data.luck += 50;
            else if (used == "Typical Wishbone")
                Data.luck += 1;
            else if (used == "Super Wishbone")
                Data.luck += 2;
            else if (used == "Unleashed Wishbone")
                Data.luck += 5;
            else if (used == "Reinforced Wishbone")
            {
                Data.luck += 3;
                Data.strength += 3;
            }
            else if (used == "Unique Wishbone")
                Data.luck += 7;
            else if (used == "Small Mirror")
                Data.charisma += 1;
            else if (used == "Dull Mirror")
                Data.charisma += 1;
            else if (used == "Cursed Mirror")
                Data.charisma += 1;
            else if (used == "Enchanted Mirror")
                Data.charisma += 3;
            else if (used == "Ice Mirror")
                Data.charisma += 4;
            else if (used == "Goblin's Mirror")
                Data.charisma += 4;
            else if (used == "Angel's Mirror")
                Data.charisma += 10;
            else if (used == "Talking Mirror")
                Data.charisma += 15;
            else if (used == "Cheap Make-up")
                Data.charisma += 1;
            else if (used == "Smelly Make-up")
                Data.charisma += 1;
            else if (used == "Basic Make-up")
                Data.charisma += 2;
            else if (used == "Classic Make-up")
                Data.charisma += 2;
            else if (used == "Treasured Make-up")
                Data.charisma += 5;
            else if (used == "Princesses' Make-up")
                Data.charisma += 15;
            else if (used == "Queen's Make-up")
                Data.charisma += 19;
            else if (used == "Mermaid's Make-up")
                Data.charisma += 20;
            else if (used == "Goddess' Make-up")
                Data.charisma += 100;
            else if (used == "Mysterious Pill")
            {
                int random = Random.Range(0, 4);
                switch (random)
                {
                    case 0: Data.strength += 1; break;
                    case 1: Data.intelligence += 1; break;
                    case 2: Data.charisma += 1; break;
                    case 3: Data.luck += 2; break;
                }
            }
            else if (used == "Suspicious Pill")
            {
                Data.strength += 1;
                Data.intelligence += 1;
                Data.charisma += 1;
                Data.luck += 1;
                Data.hunger = 0;
            }
            else if (used == "Weight Loss Pill")
            {
                Data.weight = 0;
            }
            else if (used == "Chosen Pill")
            {
                Data.strength += 2;
                Data.intelligence += 2;
                Data.luck += 2;
            }
            else if (used == "Camouflaged Pill")
                Data.charisma += 3;
            else if (used == "Peasant's Pill")
                Data.strength += 2;
            else if (used == "Beauty Pill")
                Data.charisma += 4;
            else if (used == "Fullness Pill")
                Data.hunger = 100;
            else if (used == "Ancient Pill")
            {
                Data.strength += 1;
                Data.intelligence += 2;
                Data.charisma += 1;
                Data.luck += 2;
            }
            else if (used == "Maiden's Pill")
            {
                Data.intelligence += 3;
                Data.charisma += 3;
            }
            else if (used == "Cloud Pill")
            {
                Data.strength += 3;
                Data.luck += 3;
            }
            else if (used == "Earthly Pill")
                Data.charisma += 5;
            else if (used == "Spicy Pill")
                Data.intelligence += 5;
            else if (used == "Pill of Nature")
            {
                Data.strength += 4;
                Data.intelligence += 4;
                Data.charisma += 4;
                Data.luck += 4;
            }
            else if (used == "Sky Pill")
            {
                Data.strength += 3;
                Data.charisma += 3;
            }
            else if (used == "Tribal Pill")
                Data.strength += 8;
            else if (used == "Equivalence")
            {
                Data.hunger = 50;
                Data.weight = 50;
                Data.strength += 5;
                Data.intelligence += 5;
                Data.charisma += 5;
                Data.luck += 5;
            }
            else if (used == "Knight's Pill")
            {
                Data.strength += 6;
                Data.charisma += 3;
            }
            else if (used == "King's Pill")
            {
                Data.intelligence += 6;
                Data.strength += 6;
            }
            else if (used == "Ultimate Pill")
                Data.luck += 15;
            else if (used == "Transcendent Pill")
            {
                Data.strength += 6;
                Data.intelligence += 6;
                Data.charisma += 6;
                Data.luck += 6;
            }
            else if (used == "Pill of Death")
            {
                Data.hunger = 0;
                Data.weight = 0;
                Data.strength += 75;
            }
            else if (used == "Spiritual Pill")
            {
                Data.intelligence += 38;
                Data.charisma += 38;
            }
            else if (used == "Forbidden Pill")
            {
                Data.strength += 38;
                Data.luck += 38;
            }
            else if (used == "Celestial Pill")
                Data.intelligence += 135;
            else if (used == "Holy Pill")
            {
                Data.strength += 85;
                Data.intelligence += 85;
                Data.charisma += 85;
                Data.luck += 85;
            }
            else if (used == "?????")
            {
                int total = Data.strength + Data.intelligence + Data.charisma + Data.luck + 666;
                int average = Mathf.FloorToInt(total / 4);
                Data.strength = average;
                Data.intelligence = average;
                Data.luck = average;
                Data.charisma = average;
            }
            else if (used == "Devil's Pill")
            {
                for (int i = 0; i < 2; i++)
                {
                    int random = Random.Range(0, 4);
                    switch (random)
                    {
                        case 0:
                            Data.strength += 666;
                            break;
                        case 1:
                            Data.intelligence += 666;
                            break;
                        case 2:
                            Data.luck += 666;
                            break;
                        case 3:
                            Data.charisma += 666;
                            break;
                    }
                }
            }
            else if (used == "God's Pill")
            {
                Data.strength += 1000;
                Data.intelligence += 1000;
                Data.charisma += 1000;
                Data.luck += 1000;
            }
            else if (used == "\"HELP ME.\"")
            {
                Data.strength += 15000;
                Data.intelligence += 15000;
                Data.charisma += 15000;
                Data.luck += 15000;
            }
            else if (used == "Job Application")
                Data.CalculateProfession();
            else
                Debug.Log("Incorrect name");

            Data.itemQuantities[index]--;

            //if after using the item, the quantity of item is zero
            if (Data.itemQuantities[index] == 0)
            {
                Data.itemQuantities.RemoveAt(index);
                Data.itemInventory.RemoveAt(index);
                Data.itemSprites.RemoveAt(index);
                Data.itemSpriteIndex.RemoveAt(index);

                //if inventory is empty after using item
                if (Data.itemQuantities.Count == 0)
                {
                    InventoryManager.empty = true;
                }
            }

            if(InventoryManager.toBe > 0) 
                InventoryManager.toBe--;
            else
            {
                InventoryManager.current = 1;
                InventoryManager.toBe = 0;
            }
        }
    }
}
