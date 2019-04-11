using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /*
     * Main class to controll Winning and losng conditions and get to next level
     */ 

    public static bool gameWon = false;
    //public string level;

    //Values to set winning condition 1/3 stars
    public GameObject GameWon1;
    public int maxProjectiles1;
    private bool GameWon1IsShowing;

    //Values to set winning condition 2/3 stars
    public GameObject GameWon2;
    public int maxProjectiles2;
    private bool GameWon2IsShowing;

    //Values to set winning condition 3/3 stars
    public GameObject GameWon3;
    public int maxProjectiles3;
    private bool GameWon3IsShowing;

    public GameObject GameLost;
    private bool GameLostShowing;

    //Values to check if game is finished or done
    private bool gameInProgress = true;
    private bool gameFinished = false;

    //Value to proceed to next Level (changed in each scene)
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    //Elements for countdown -> losing condition
    public Text countdownText;
    public float startTime;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    public AudioSource victorySound;
    public AudioSource lostSound;

    void Start()
    {
        //setting timer to fixed value.
        timer = startTime;
    }

    void FixedUpdate()
    {
        //Condition so EndGame() is only called once after game finished
        if (gameInProgress)
        {
        EndGame();
        }

        //stop the timer if game is over
        if(gameFinished == true)
        {
            canCount = false;
        }

        //let the counter count from startTime to 0
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            countdownText.text = timer.ToString("F");
        }
        //stop the counter/timer at 00.00 -> game lost
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            countdownText.text = "0.00";
            timer = 0.0f;
            GameLost1();
        }
    }

    //Contains all different states if the game has been won
    void EndGame()
    {
        // 1 of 3 stars -> check if all enemies are dead and how many projectiles are left over
        if (Enemy.Enemies <= 0 && Spawn.allProjectiles >= maxProjectiles1 && Spawn.allProjectiles < maxProjectiles2)
        {
            GameWon1IsShowing = !GameWon1IsShowing;
            GameWon1.SetActive(GameWon1IsShowing);
            victorySound.Play();
            gameInProgress = false;
            gameFinished = true;

            //If game is won the next level is unlocked -> stored on users system
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }

        // 2 of 3 stars
        if (Enemy.Enemies <= 0 && Spawn.allProjectiles >= maxProjectiles2 && Spawn.allProjectiles < maxProjectiles3)
        {
            GameWon2IsShowing = !GameWon2IsShowing;
            GameWon2.SetActive(GameWon2IsShowing);
            victorySound.Play();
            gameInProgress = false;
            gameFinished = true;

            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }

        // 3 of 3 stars
        if (Enemy.Enemies <= 0 && Spawn.allProjectiles >= maxProjectiles3)
        {
            GameWon3IsShowing = !GameWon3IsShowing;
            GameWon3.SetActive(GameWon3IsShowing);
            victorySound.Play();
            gameInProgress = false;
            gameFinished = true;

            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }

    //Show GameLost screen
    void GameLost1()
    {
        GameLostShowing = !GameLostShowing;
        GameLost.SetActive(GameLostShowing);
        lostSound.Play();
        gameInProgress = false;
        gameFinished = true;
        Time.timeScale = 0;
    }

}
