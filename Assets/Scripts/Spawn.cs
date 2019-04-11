using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    /*
     * Main script to handle behaviour of all projectiles and spawn
     */

    //Gameobjects
    public GameObject ballPrefab;
    public GameObject bowlingPrefab;
    public GameObject bombPrefab;
    public Transform spawnHere;
    //public GameObject cloneBall;

    public GameObject lockedBall;
    public GameObject lockedBowling;
    public GameObject lockedBomb;

    //Values to change
    public  int maxAmount;
    public  int maxBowling;
    public  int maxBomb;
    public static int allProjectiles;

    //UI Canvas Elements
    public Button ballButton;
    public Button bowlingButton;
    public Button bombButton;
    
    

    //Value to check if catapult is occupied by projectile
    bool occupied = false;

    void Start()
    {
        //Set UI Text of projectiles equal to given amaounts
        ballButton.GetComponentsInChildren<Text>()[0].text = maxAmount.ToString();
        bowlingButton.GetComponentsInChildren<Text>()[0].text = maxBowling.ToString();
        bombButton.GetComponentsInChildren<Text>()[0].text = maxBomb.ToString();

        //Disable buttons if the projectile cannot be used in this level
        if(maxAmount == 0)
        {
            ballButton.interactable = false;
            lockedBall.SetActive(true);
        }

        if (maxBowling == 0)
        {
            bowlingButton.interactable = false;
            lockedBowling.SetActive(true);
        }

        if (maxBomb == 0)
        {
            bombButton.interactable = false;
            lockedBomb.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        //Get current amount of al projectiles -> used in gamecontroller to check win/lost state
        allProjectiles = maxAmount + maxBomb + maxBowling;

    }

    public void SpawnElement()
    {
        //check which button in the UI has been selected
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (!SceneMoving() && !occupied)
        {
            if(name == "Ball")
            {
                SelectBall();

            }

            if (name == "Bowling")
            {
                SelectBowling();
            }   
            
            if(name == "Bomb")
            {
                SelectBomb();
            }

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //if no projectile in catapult, the next projectile can be spawned
        occupied = false;
    }

    bool SceneMoving()
    {
        //check if projectile in the scene is still moving, if it is then you cannot spawn another projectile -> avoid spam
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach(Rigidbody2D rb in bodies)
        {
            if(rb.velocity.sqrMagnitude > 5)
            {
                return true;
                
            }
        }
        return false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Spawn clicked projectile and decrease maximum Amount of the projectile
    public void SelectBall()
    {        
        maxAmount--;

        if ( maxAmount >= 0)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            occupied = true;
            ballButton.GetComponentsInChildren<Text>()[0].text = maxAmount.ToString();
        }

    }

    public void SelectBowling()
    {
        maxBowling--;

        if (maxBowling >= 0)
        {
            Instantiate(bowlingPrefab, transform.position, Quaternion.identity);
            occupied = true;
            bowlingButton.GetComponentsInChildren<Text>()[0].text = maxBowling.ToString();
        }
    }

    public void SelectBomb()
    {
        maxBomb--;

        if (maxBomb >= 0)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            occupied = true;
            bombButton.GetComponentsInChildren<Text>()[0].text = maxBomb.ToString();
        }
    }

}
