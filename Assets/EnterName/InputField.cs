using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    Button createPet;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        createPet = GameObject.Find("CreatePet").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text.text.Length > 0)
        {
            createPet.gameObject.SetActive(true);
        }
        else
        {
            createPet.gameObject.SetActive(false);
        }
    }
}
