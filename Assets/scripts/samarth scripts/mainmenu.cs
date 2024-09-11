using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject aboutMenu;

    public GameObject levelMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // This method loads the game scene, replace "GameScene" with your actual scene name
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    // This method can be expanded to open a settings menu
    public void About()
    {
        // Code to open the settings menu
        aboutMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    // This method quits the game
    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }

    public void aboutBack()
    {
        aboutMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void levelBack()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void level1()
    {
        print("level 1 started");
    }
    public void level2()
    {
        print("level 2 started");
    }
    public void level3()
    {
        print("level 3 started");
    }

}