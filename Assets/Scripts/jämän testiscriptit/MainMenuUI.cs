﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public Image credits, settings;
    public Button backbutton, closeSettings, quit, play, info, setting;
    public GameObject wantToQuit;
    public GameObject kajaklogo;
    //public Button closeSettings;
    public Toggle music, sound;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if(!GameManager.instance.logo)
        {
            kajaklogo.gameObject.SetActive(false);
        }
	}
    public void Credits()
    {
        quit.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
    }
    public void BackButton()
    {
        quit.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
        backbutton.gameObject.SetActive(false);
    }
    public void Settings()
    {
        quit.interactable = false;
        info.interactable = false;
        play.interactable = false;
        settings.gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        quit.interactable = true;
        info.interactable = true;
        play.interactable = true;
        settings.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        wantToQuit.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        setting.gameObject.SetActive(false);
    }
    public void yes()
    {
        Application.Quit();
    }
    public void no()
    {
        wantToQuit.gameObject.SetActive(false);
        quit.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        setting.gameObject.SetActive(true);
    }
}
