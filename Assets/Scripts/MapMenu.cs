﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMenu : MonoBehaviour
{

    public List<GameObject> levels;
    public List<GameObject> gameLevel;
    public Transform highlight;
    public Transform gameLevels;
    public bool levelSelect;
    Vector3 levelPos;
    int theme;
    public int star01, star02, star03;
    public List<GameObject> star1, star2, star3;
    public int forest1, forest2, forest3, japan1, japan2, japan3, winter1, winter2, winter3, hell1, hell2, hell3, desert1, desert2, desert3;
    
    void Start()
    {
        //levelPos.z = -10;
        star1 = new List<GameObject>();
        star2 = new List<GameObject>();
        star3 = new List<GameObject>();
        for (int i = 1; i <= 3; i++) { star1.Add(GameObject.Find("star10" + i)); }
        for (int i = 1; i <= 3; i++) { star2.Add(GameObject.Find("star20" + i)); }
        for (int i = 1; i <= 3; i++) { star3.Add(GameObject.Find("star30" + i)); }
        levels = new List<GameObject>();
        gameLevel = new List<GameObject>();
        highlight.gameObject.SetActive(false);
        for (int i = 1; i <= 5; i++)
        {
            levels.Add(GameObject.Find("Level_" + i));
        }
        for(int j = 1; j <= 3; j++)
        {
            gameLevel.Add(GameObject.Find("Level" + j));
        }
    }

    void Update()
    {
        
        

        levelSelection();
    }

    void Highlighter()
    {
        gameLevels.transform.position = levelPos;
        highlight.gameObject.SetActive(true);
        gameLevels.gameObject.SetActive(true);
        Debug.Log("Lol");


    }
    void stars()
    {
        for (int x = 0; x < star01; x++)
        {
            star1[x].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (int k = 0; k < star02; k++)
        {
            star2[k].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (int j = 0; j < star03; j++)
        {
            star3[j].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log(star1[j]);
        }
    }
    void levelSelection()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            for (int x = 0; x < 3; x++)
            {
                star1[x].GetComponent<SpriteRenderer>().enabled = false;
            }
            for (int k = 0; k < 3; k++)
            {
                star2[k].GetComponent<SpriteRenderer>().enabled = false;
            }
            for (int j = 0; j < 3; j++)
            {
                star3[j].GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log(star1[j]);
            }
            if (ray)
            {
                if (ray && ray.collider.GetComponent<CircleCollider2D>())
                {
                    highlight.transform.position = ray.collider.gameObject.transform.position;

                }
                levelPos = ray.collider.gameObject.transform.position;
                levelPos.y += 2;
                levelPos.z = -10;
                for (int i = 0; i < 5; i++)
                {
                    if (ray && ray.collider == levels[i].GetComponent<CircleCollider2D>())
                    {
                        Highlighter();
                        levelSelect = true;
                        theme = i;
                        Debug.Log(theme + " theme");
                        if(theme == 0)
                        {
                            star01 = forest1;
                            star02 = forest2;
                            star03 = forest3;
                        }
                        if (theme == 1)
                        {
                            star01 = japan1;
                            star02 = japan2;
                            star03 = japan3;
                        }
                        if (theme == 2)
                        {
                            star01 = winter1;
                            star02 = winter2;
                            star03 = winter3;
                        }
                        if (theme == 3)
                        {
                            star01 = hell1;
                            star02 = hell2;
                            star03 = hell3;
                        }
                        if (theme == 4)
                        {
                            star01 = desert1;
                            star02 = desert1;
                            star03 = desert1;
                        }
                    }

                }
                stars();
                if (levelSelect)
                {                    
                    for (int j = 0; j < 3; j++)
                    {
                        if (ray & ray.collider == gameLevel[j].GetComponent<BoxCollider2D>())
                        {
                            if (theme == 0)
                            {
                                if (j == 0)
                                {
                                    Debug.Log("eka themen eka kenttä");
                                }
                                if (j == 1)
                                {
                                    Debug.Log("eka themen toinen kenttä");
                                }
                                if (j == 2)
                                {
                                    Debug.Log("eka themen viimeinen kenttä");  
                                }
                            }
                            if (theme == 1)
                            {
                                if (j == 0)
                                {
                                    Debug.Log("toisen themen eka kenttä");  
                                }
                                if (j == 1)
                                {
                                    Debug.Log("toisen themen toinen kenttä");     
                                }
                                if (j == 2)
                                {
                                    Debug.Log("toisen themen viimeinen kenttä");         
                                }
                            }
                            if (theme == 2)
                            {
                                if (j == 0)
                                {
                                    Debug.Log("kolmannen themen eka kenttä");
                                }
                                if (j == 1)
                                {
                                    Debug.Log("kolmannen themen toinen kenttä"); 
                                }
                                if (j == 2)
                                {
                                    Debug.Log("kolmannen themen viimeinen kenttä");     
                                }
                            }
                            if (theme == 3)
                            {
                                if (j == 0)
                                {
                                    Debug.Log("neljännen themen eka kenttä");      
                                }
                                if (j == 1)
                                {
                                    Debug.Log("neljännen themen toinen kenttä");                           
                                }
                                if (j == 2)
                                {
                                    Debug.Log("neljännen themen viimeinen kenttä");
                                }
                            }
                            if (theme == 4)
                            {
                                if (j == 0)
                                {
                                    Debug.Log("viidennen themen eka kenttä");
                                }
                                if (j == 1)
                                {
                                    Debug.Log("viidennen themen toinen kenttä");
                                }
                                if (j == 2)
                                {
                                    Debug.Log("viidennen themen viimeinen kenttä");
                                }
                            }
                        }
                    }
                }
            }

            else if (!ray)
            {
                levelSelect = false;
                highlight.gameObject.SetActive(false);
                gameLevels.gameObject.SetActive(false);
            }
        }
    }
}
