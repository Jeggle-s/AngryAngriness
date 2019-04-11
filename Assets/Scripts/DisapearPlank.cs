using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearPlank : MonoBehaviour
{
    public GameObject[] plank;

    // Destroy gameobject and remove all children so they don't get destroyed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < plank.Length; i++)
        {

        plank[i].transform.DetachChildren();
        Destroy(plank[i]);
        }
    }
}
