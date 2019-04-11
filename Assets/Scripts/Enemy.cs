using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    /*
     * Script to handle enemies
     */

    // force needed to eliminate enemy
    public float maxVel = 4f;
    public GameObject feathers;

    public static int Enemies;

    void Start()
    {
        //Every Enemy increases this number -> we know how many enemies are currently in the scene
        Enemies++;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check the velocity the gameobject is hit with
        if(col.relativeVelocity.magnitude > maxVel)
        {
            DespawnEnemy();
        }
    }

    void DespawnEnemy()
    {
        Instantiate(feathers, transform.position, Quaternion.identity);

        //Decrease amount of enemy -> wo know the object no longer exists
        Enemies--;
        Destroy(gameObject);
    }
}
