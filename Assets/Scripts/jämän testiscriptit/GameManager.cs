﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool destroyed;
    //public int forest1, forest2, forest3, japan1, japan2, japan3, winter1, winter2, winter3, hell1, hell2, hell3, desert1, desert2, desert3;
    public int theme;
    public int selectedNumber = 16;
    public int[] levelNumber = new int[15];
    public bool continued;
    public Vector3 levelPos = new Vector3(-15, 0, -10);
    public Vector3 highlightPos;
    public Vector3 camPos = new Vector3(0, 0, -10);
    public Vector3 camePos;
    public bool firstUnlock, secondUnlock;
    public bool gameStarted;
    public bool loadingScreen;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        destroyed = false;
    }
	// Use this for initialization
	void Start () {
        continued = false;
        gameStarted = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

   public void sceneLoader(string sceneName)
    {
        camePos = Camera.main.transform.position;
        ScreenManager.instance.StartCoroutine(ScreenManager.instance.LoadSceneAsync(sceneName));
    }
}
