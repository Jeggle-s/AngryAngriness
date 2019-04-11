using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float TTL;

    void Awake()
    {
        Destroy(gameObject, TTL);
    }
}
