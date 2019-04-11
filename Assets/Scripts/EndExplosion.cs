using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExplosion : MonoBehaviour
{

    //Simple script to destroy explosion animation and point effector 2d aber .5 seconds
    public float time = 0.5f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }
}
