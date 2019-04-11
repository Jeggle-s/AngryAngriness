using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_And_Release : MonoBehaviour
{
    //Ability to pull on the catapult and shoot projectiles

    Vector2 startPos;
    public Rigidbody2D ball;
    public float force = 1300;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        ball = GetComponent<Rigidbody2D>();
        
    }

    void OnMouseUp()
    {
        //Release the projectile with given force
        GetComponent<Rigidbody2D>().isKinematic = false;
        Vector2 dir = startPos - (Vector2)transform.position;
        ball.AddForce(dir * force);
        Destroy(this);
    }

    void OnMouseDrag()
    {
        //direction where to shoot (curr. mouse position) is set to worldpoint 
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float radius = 1.8f;
        Vector2 dir = p - startPos;
        if(dir.sqrMagnitude > radius)
        {
            dir = dir.normalized * radius;
        }
        transform.position = startPos + dir;
    }
}
