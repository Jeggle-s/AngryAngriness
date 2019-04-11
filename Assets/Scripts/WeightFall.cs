using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightFall : MonoBehaviour
{
    //Script to give the weight in the scene force (only y direction -> drop)

    Vector2 startPos;
    public Rigidbody2D weight;
    public float force = 1300;

    private void FixedUpdate()
    {
        startPos = transform.position;
        weight = GetComponent<Rigidbody2D>();

        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        weight.AddForce(dir * force);
    }
}
