using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public GameObject effect;
    public GameObject ball;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Trigger collision effect of projectiles
        if(collision.gameObject.tag != "Ground")
        {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(this);
        }
    }
}
