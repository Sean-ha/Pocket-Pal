using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRight : MonoBehaviour
{
    private void OnMouseUp()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("sounds/click2"));
        InventoryManager.toBe++;
    }
}
