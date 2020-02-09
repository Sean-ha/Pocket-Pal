using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //displays stats
        Text text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //displays stats
        Text text = GetComponent<Text>();
        text.text = Data.petName + "\n" +
            "Profession: " + Data.profession + "\n" +
            "Hunger: " + System.Math.Ceiling(Data.hunger) + "/100\n" +
            "Money: $" + System.Math.Floor(Data.money).ToString("n0") + "\n" +
            "Age: " + Data.age + " days\n" +
            "Weight: " + System.Math.Ceiling(Data.weight) + " lbs\n";

        text.text += "<color=red>Strength: " + Data.strength + "</color>\n";
        text.text += "<color=blue>Intelligence: " + Data.intelligence + "</color>\n";
        text.text += "<color=green>Luck: " + Data.luck + "</color>\n";
        text.text += "<color=magenta>Charisma: " + Data.charisma + "</color>\n";

        text.text += "Salary: $" + Data.salary.ToString("n0") + " / hour\n" +
            "Lifetime Earnings: $" + System.Math.Floor(Data.lifetimeMoney).ToString("n0");
    }
}
