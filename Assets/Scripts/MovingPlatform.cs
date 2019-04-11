using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    /*
     * Script to move a platform horizontally
     */
    public GameObject platform;
    private Vector2 startPosition;
    private Vector2 newPosition;

    [SerializeField]  private int speed = 3;
    [SerializeField]  private int maxDistance = 1;

    // Both values got the same value, so the current position (spawned pos.) is stored
    void Start()
    {
        startPosition = platform.transform.position;
        newPosition = platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move gameobject only on x axis based on startpos and distance value
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        platform.transform.position = newPosition;
    }
}
