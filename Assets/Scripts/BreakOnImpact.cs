using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{
    public float maxVel;
    public float time = 0.5f;

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check the velocity the gameobject is hit with
        if (col.relativeVelocity.magnitude > maxVel && col.gameObject.tag != "Bomb") 
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Bowling")
        {
            Destroy(col.gameObject, time);
        }
    }
}
