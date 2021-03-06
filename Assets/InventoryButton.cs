﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("InventoryWindow");
    }
}
