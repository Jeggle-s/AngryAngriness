using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScenes : MonoBehaviour
{
    //Method to play music in multiple scenes
    void Awake()
    {
        GameObject[] sound = GameObject.FindGameObjectsWithTag("Music");

        //Make sure, only one Element with Tag "Music" is in the scene
        if(sound.Length > 1)
        {
            //Destroy object if there is one than more
            Destroy(this.gameObject);
        }
        //Play music in every scene once it's loaded
        DontDestroyOnLoad(this.gameObject);
    }
}
