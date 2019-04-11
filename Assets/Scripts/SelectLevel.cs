using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    /*
     * Script to select Levels in Menu
     * It also handels all UI inputs (reload, next scene etc.)
     */

    //All Levels as one array
    public Button[] levelButtons;
    public GameObject pauseMenu;

    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;

    void Start()
    {
        //PlayerPref to save progress -> get each level which is finished
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        //iterate through all buttons and check if level is finished
        for (int i = 0; i < levelButtons.Length; i++)
        {
            //if level ins't finished turn the button non interactable
            if(i + 1 > levelReached)
            {
            levelButtons[i].interactable = false;
            }

            if(levelButtons[i].interactable == false)
            {
                levelButtons[i].GetComponentInChildren<Text>().enabled = false;
            }

        }
    }

    //select scene which is loaded on button click (level select)
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //Method to be called on button click
    public void LoadScreen(string nextLevel)
    {
        StartCoroutine(LoadingScreen(nextLevel));
    }

    //Asynchronous loading of a scene
    //Enables to show correct loading screen
    IEnumerator LoadingScreen(string level)
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(level);
        async.allowSceneActivation = false;

        //change slider value as long as scene is not ready
        while (async.isDone == false)
        {
            slider.value = async.progress;
            //Slider value is equal to progress of the loading scene in the background
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                //show scene
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

        //Reset stored progress (delete PlayerPrefs)
        public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //Quit application
    public void ExitGame()
    {
        Application.Quit();
    }

    //Restart the scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Set timescale to 1 as it is set to 0 when game is paused -> timescale doesn't reset automatically
        Time.timeScale = 1;
    }

    //Display pause menu and "freeze" scene in the background
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Back()
    {
        pauseMenu.SetActive(false);
    }
}
