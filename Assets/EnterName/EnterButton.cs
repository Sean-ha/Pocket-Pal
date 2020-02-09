using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour
{

    Button createPet;
    Text petsName;

    // Start is called before the first frame update
    void Start()
    {
        createPet = GetComponent<Button>();
        createPet.onClick.AddListener(TaskOnClick);

        petsName = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("MainScreen");
        Data.petName = petsName.text;
    }
}
