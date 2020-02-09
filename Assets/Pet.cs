using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{

    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 11);
        InvokeRepeating("EverySecond", 0, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EverySecond()
    {
        switch(i)
        {
            case 0: transform.position = new Vector3(-2.15f, 1, 0); break;
            case 1: transform.position = new Vector3(-1.24f, -1, 0); break;
            case 2: transform.position = new Vector3(-0.22f, -0.12f, 0); break;
            case 3: transform.position = new Vector3(0.40f, 1.05f, 0); break;
            case 4: transform.position = new Vector3(0.7f, -1.68f, 0); break;
            case 5: transform.position = new Vector3(2.2f, 0, 0); break;
            case 6: transform.position = new Vector3(1.1f, 2.05f, 0); break;
            case 7: transform.position = new Vector3(1.72f, -0.9f, 0); break;
            case 8: transform.position = new Vector3(-0.8f, -1.3f, 0); break;
            case 9: transform.position = new Vector3(-1.65f, 1.2f, 0); break;
            case 10: transform.position = new Vector3(); break;
        }
        i++;
        i %= 11;
    }
}
