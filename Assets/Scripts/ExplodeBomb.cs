using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour
{
    //Class to handel explosion animation 
    bool hasExploded = false;
    //Causes the expolsion through a point effector 2 in the inspector
    public GameObject explosion;

    // Update is called once per frame -> check each frame if spacebar has been hit
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !hasExploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        //destroy bomb prefab after explosion
        Destroy(gameObject);
    }
}
