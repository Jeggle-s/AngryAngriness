using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public GameObject[] trails;
    int next = 0;

    void Start()
    {
        //Unity eigene Funktion zum verzögerten Aufruf einer Funktion
        InvokeRepeating("spawnTrail", 0.1f, 0.1f);
    }

    void spawnTrail()
    {
        if(GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25)
        {
            Instantiate(trails[next], transform.position, Quaternion.identity);
            next = (next + 1) % trails.Length;
        }
    }

}
