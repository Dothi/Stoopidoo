using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
    int pressNumber;
    public int sormi = 0;
    public float yPos;
    public List<GameObject> levels;
    public List<GameObject> gameLevel;
    public Sprite[] pointers;
    public Transform highlight;
    public Transform gameLevels;
    public SpriteRenderer themePointer;
    public bool levelSelect;
    public bool fingerMoved;
    Vector3 levelPos;
    public Vector2 startPos;
    public Vector2 endPos;
    public int theme;
    public int star01, star02, star03;
    public List<GameObject> star1, star2, star3;
    public AudioClip plob;
    public Button playButton;
    public Image mainMenuPic;
    public SpriteRenderer[] mappi;
    public int overAllStars;
    public int forestStars, iceStars, japanStars, desertStars;
    float currentTime = 0;
    float TimeitTakesToFade = 2;
    float fadeValue = 1;
    bool faded;
    //public bool themeClicked;
    //public int clickCounter = 0;
    void Awake()
    {
        pressNumber = 0;
        //themeClicked = false;
        //levelPos.z = -10;
        star1 = new List<GameObject>();
        star2 = new List<GameObject>();
        star3 = new List<GameObject>();
        for (int i = 1; i <= 3; i++) { star1.Add(GameObject.Find("star10" + i)); }
        for (int i = 1; i <= 3; i++) { star2.Add(GameObject.Find("star20" + i)); }
        for (int i = 1; i <= 3; i++) { star3.Add(GameObject.Find("star30" + i)); }
        levels = new List<GameObject>();
        gameLevel = new List<GameObject>();
        ////highlight.gameObject.SetActive(false);
        //for (int i = 0; i < GameManager.instance.levelNumber.Length; i++)
        //{
        //    overAllStars += GameManager.instance.levelNumber[i];
        //}
        for(int i = 0; i < 3; i++)
        {
            forestStars += GameManager.instance.levelNumber[i];
        }
        for(int i = 3; i < 6; i++)
        {
            iceStars += GameManager.instance.levelNumber[i];
        }
        for(int i = 6; i < 9; i++)
        {
            japanStars += GameManager.instance.levelNumber[i];
        }
        for(int i = 9; i < 12; i++)
        {
            desertStars += GameManager.instance.levelNumber[i];
        }
        levelPos = GameManager.instance.levelPos;
        theme = GameManager.instance.theme;
        if (GameManager.instance.continued)
        {
            highlight.gameObject.SetActive(true);
            highlight.gameObject.transform.position = GameManager.instance.highlightPos;
            levelSelect = true;
            gameLevels.position = GameManager.instance.levelPos;
        }
        for (int i = 1; i <= 5; i++)
        {
            levels.Add(GameObject.Find("Level_" + i));
        }
        for (int j = 1; j <= 3; j++)
        {
            gameLevel.Add(GameObject.Find("Level" + j));
        }
        if (GameManager.instance.gameStarted)
        {

        }
        hideStars();
        unlocking();
    }

    void Update()
    {

        if (forestStars >= 3)
        {
            GameManager.instance.firstUnlock = true;
            Unlock();
        }
        if(iceStars >= 4)
        {
            GameManager.instance.secondUnlock = true;
            Unlock();
        }
        if (japanStars >= 6)
        {
            GameManager.instance.thirdUnlock = true;
            Unlock();
        }
        if (desertStars >= 8)
        {
            GameManager.instance.fourthUnlock = true;
            Unlock();
        }
        //levelSelection();
        showStars();
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId < 1)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                                startPos = touch.position;
                            if (levelSelect)
                            {
                                sormi++;
                            }
                            levelSelectionMobile();
                            break;
                        case TouchPhase.Moved:
                            if(levelSelect)
                            {
                                fingerMoved = true;
                            }
                            break;
                        case TouchPhase.Stationary:
                            if(levelSelect)
                            {
                                fingerMoved = false;
                            }
                            break;
                        case TouchPhase.Ended:
                                endPos = touch.position;
                            endTouch();
                                break;
                    }
                }
            }
        }

    }
    void endTouch()
    {
        if (sormi > 0)
        {
            if (startPos == endPos && levelSelect)
            {
                gameLevels.gameObject.SetActive(false);
                levelSelect = false;
                sormi = 0;
            }
        }
    }
    void Highlighter()
    {
        gameLevels.transform.position = levelPos;
        GameManager.instance.levelPos = levelPos;
        highlight.gameObject.SetActive(true);
        gameLevels.gameObject.SetActive(true);
    }
    void showStars()
    {
        themeSelect();
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
        }
    }
    void hideStars()
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
        }

    }
    void themeSelect()
    {
        if (theme == 0)
        {
            themePointer.sprite = pointers[theme];
            star01 = GameManager.instance.levelNumber[0];
            star02 = GameManager.instance.levelNumber[1];
            star03 = GameManager.instance.levelNumber[2];
        }
        if (theme == 1)
        {
            themePointer.sprite = pointers[theme];
            star01 = GameManager.instance.levelNumber[3];
            star02 = GameManager.instance.levelNumber[4];
            star03 = GameManager.instance.levelNumber[5];
        }
        if (theme == 2)
        {
            themePointer.sprite = pointers[theme];
            star01 = GameManager.instance.levelNumber[6];
            star02 = GameManager.instance.levelNumber[7];
            star03 = GameManager.instance.levelNumber[8];
        }
        if (theme == 3)
        {
            themePointer.sprite = pointers[theme];
            star01 = GameManager.instance.levelNumber[9];
            star02 = GameManager.instance.levelNumber[10];
            star03 = GameManager.instance.levelNumber[11];
        }
        if (theme == 4)
        {
            themePointer.sprite = pointers[theme];
            star01 = GameManager.instance.levelNumber[12];
            star02 = GameManager.instance.levelNumber[13];
            star03 = GameManager.instance.levelNumber[14];
        }
    }
    //void levelSelection()
    //{
    //    RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        hideStars();
    //        if (ray)
    //        {
    //            Debug.Log("lol");
    //            if (ray && ray.collider.GetComponent<CircleCollider2D>())
    //            {
    //                Debug.Log(ray.collider.gameObject);
    //                highlight.transform.position = ray.collider.gameObject.transform.position;
    //                GameManager.instance.highlightPos = ray.collider.gameObject.transform.position;
    //            }
    //            levelPos = ray.collider.gameObject.transform.position;
    //            levelPos.y += yPos;
    //            levelPos.z = -10;
    //            for (int i = 0; i < 5; i++)
    //            {
    //                if (ray && ray.collider == levels[i].GetComponent<CircleCollider2D>())
    //                {
    //                    AudioSource.PlayClipAtPoint(plob, transform.position);
    //                    Highlighter();
    //                    levelSelect = true;
    //                    theme = i;
    //                    GameManager.instance.theme = i;
    //                    Debug.Log(theme + " theme");
    //                }

    //            }
    //            //showStars();
    //            if (levelSelect)
    //            {
    //                for (int j = 0; j < 3; j++)
    //                {
    //                    if (ray & ray.collider == gameLevel[j].GetComponent<BoxCollider2D>())
    //                    {
    //                        if (theme == 0)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                GameManager.instance.selectedNumber = 0;
    //                                //Application.LoadLevel("Jonna Forest 1");
    //                                ScreenManager.instance.StartCoroutine(ScreenManager.instance.LoadSceneAsync("Jonna Forest 1"));
    //                                Debug.Log("eka themen eka kenttä");
    //                            }
    //                            if (j == 1)
    //                            {
    //                                GameManager.instance.selectedNumber = 1;
    //                                //Application.LoadLevel("JonnaTestMobile");
    //                                StartCoroutine(ScreenManager.instance.LoadSceneAsync("JonnaTestMobile"));
    //                                Debug.Log("eka themen toinen kenttä");
    //                            }
    //                            if (j == 2)
    //                            {
    //                                GameManager.instance.selectedNumber = 2;
    //                                //Application.LoadLevel("jmlevelsuunnittelu");
    //                                StartCoroutine(ScreenManager.instance.LoadSceneAsync("jmlevelsuunnittelu"));
    //                                Debug.Log("eka themen viimeinen kenttä");
    //                            }
    //                        }
    //                        if (theme == 1)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                GameManager.instance.selectedNumber = 3;
    //                                //Application.LoadLevel("Winter1 level");
    //                                StartCoroutine(ScreenManager.instance.LoadSceneAsync("Winter1 level"));
    //                                Debug.Log("toisen themen eka kenttä");
    //                            }
    //                            if (j == 1)
    //                            {
    //                                GameManager.instance.selectedNumber = 4;
    //                                //Application.LoadLevel("Winter1 leve 2");
    //                                StartCoroutine(ScreenManager.instance.LoadSceneAsync("Winter1 leve 2"));
    //                                Debug.Log("toisen themen toinen kenttä");
    //                            }
    //                            if (j == 2)
    //                            {
    //                                GameManager.instance.selectedNumber = 5;
    //                                //Application.LoadLevel("Winter level 3");
    //                                StartCoroutine(ScreenManager.instance.LoadSceneAsync("Winter level 3"));
    //                                Debug.Log("toisen themen viimeinen kenttä");
    //                            }
    //                        }
    //                        if (theme == 2)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                GameManager.instance.selectedNumber = 6;
    //                                Debug.Log("kolmannen themen eka kenttä");
    //                            }
    //                            if (j == 1)
    //                            {
    //                                GameManager.instance.selectedNumber = 7;
    //                                Debug.Log("kolmannen themen toinen kenttä");
    //                            }
    //                            if (j == 2)
    //                            {
    //                                GameManager.instance.selectedNumber = 8;
    //                                Debug.Log("kolmannen themen viimeinen kenttä");
    //                            }
    //                        }
    //                        if (theme == 3)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                GameManager.instance.selectedNumber = 9;
    //                                Debug.Log("neljännen themen eka kenttä");
    //                            }
    //                            if (j == 1)
    //                            {
    //                                GameManager.instance.selectedNumber = 10;
    //                                Debug.Log("neljännen themen toinen kenttä");
    //                            }
    //                            if (j == 2)
    //                            {
    //                                GameManager.instance.selectedNumber = 11;
    //                                Debug.Log("neljännen themen viimeinen kenttä");
    //                            }
    //                        }
    //                        if (theme == 4)
    //                        {
    //                            if (j == 0)
    //                            {
    //                                GameManager.instance.selectedNumber = 12;
    //                                Debug.Log("viidennen themen eka kenttä");
    //                            }
    //                            if (j == 1)
    //                            {
    //                                GameManager.instance.selectedNumber = 13;
    //                                Debug.Log("viidennen themen toinen kenttä");
    //                            }
    //                            if (j == 2)
    //                            {
    //                                GameManager.instance.selectedNumber = 14;
    //                                Debug.Log("viidennen themen viimeinen kenttä");
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        else if (!ray)
    //        {
    //            Debug.Log("ei osu :l");
    //            //levelSelect = false;
    //            //highlight.gameObject.SetActive(false);
    //            //gameLevels.gameObject.SetActive(false);

    //        }
    //    }
    //}

    void levelSelectionMobile()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
        
        if (ray)
        {
            if (ray && ray.collider.GetComponent<CircleCollider2D>())
            {
                hideStars();

            }
            levelPos = ray.collider.gameObject.transform.position;
            levelPos.y += yPos;
            levelPos.z = -10;
            for (int i = 0; i < 5; i++)
            {
                if (ray && ray.collider == levels[i].GetComponent<CircleCollider2D>())
                {
                    highlight.transform.position = ray.collider.gameObject.transform.position;
                    GameManager.instance.highlightPos = ray.collider.gameObject.transform.position;
                    AudioSource.PlayClipAtPoint(plob, transform.position);
                    Highlighter();
                    levelSelect = true;
                    sormi = 0;
                    theme = i;
                    GameManager.instance.theme = i;
                }

            }
            //showStars();
            if (levelSelect)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ray & ray.collider == gameLevel[j].GetComponent<CircleCollider2D>())
                    {
                        GameManager.instance.camPos = Camera.main.transform.position;
                        if (theme == 0)
                        {
                            if (j == 0)
                            {
                                GameManager.instance.selectedNumber = 0;
                                GameManager.instance.sceneLoader("Jonna Forest 1");
                                //GameManager.instance.sceneLoader("Winter1 leve 2");
                                Debug.Log("eka themen eka kenttä");
                            }
                            if (j == 1)
                            {
                                GameManager.instance.selectedNumber = 1;
                                //GameManager.instance.sceneLoader("Winter1 leve 2");
                                GameManager.instance.sceneLoader("JonnaTestMobile");
                                Debug.Log("eka themen toinen kenttä");
                            }
                            if (j == 2)
                            {
                                GameManager.instance.selectedNumber = 2;
                                //GameManager.instance.sceneLoader("Winter1 leve 2");
                                GameManager.instance.sceneLoader("Forest level 3");
                                Debug.Log("eka themen viimeinen kenttä");
                            }
                        }
                        if (theme == 1)
                        {
                            if (j == 0)
                            {
                                GameManager.instance.selectedNumber = 3;
                                //GameManager.instance.sceneLoader("Winter1 leve 2");
                                GameManager.instance.sceneLoader("Winter level 1");
                                Debug.Log("toisen themen eka kenttä");
                            }
                            if (j == 1)
                            {
                                GameManager.instance.selectedNumber = 4;
                                GameManager.instance.sceneLoader("Winter level 2");
                                Debug.Log("toisen themen toinen kenttä");
                            }
                            if (j == 2)
                            {
                                GameManager.instance.selectedNumber = 5;
                                //GameManager.instance.sceneLoader("Winter1 leve 2");
                                GameManager.instance.sceneLoader("Winter level 3");
                                Debug.Log("toisen themen viimeinen kenttä");
                            }
                        }
                        if (theme == 2)
                        {
                            if (j == 0)
                            {
                                GameManager.instance.selectedNumber = 6;
                                Debug.Log("kolmannen themen eka kenttä");
                                GameManager.instance.sceneLoader("Japan level 1");
                            }
                            if (j == 1)
                            {
                                GameManager.instance.selectedNumber = 7;
                                Debug.Log("kolmannen themen toinen kenttä");
                                GameManager.instance.sceneLoader("Japan level 4");
                            }
                            if (j == 2)
                            {
                                GameManager.instance.selectedNumber = 8;
                                Debug.Log("kolmannen themen viimeinen kenttä");
                                GameManager.instance.sceneLoader("Japan level 5");
                            }
                        }
                        if (theme == 3)
                        {
                            if (j == 0)
                            {
                                GameManager.instance.selectedNumber = 9;
                                Debug.Log("neljännen themen eka kenttä");
                                GameManager.instance.sceneLoader("Desert level 1");
                            }
                            if (j == 1)
                            {
                                GameManager.instance.selectedNumber = 10;
                                Debug.Log("neljännen themen toinen kenttä");
                                GameManager.instance.sceneLoader("Desert level 2");
                            }
                            if (j == 2)
                            {
                                GameManager.instance.selectedNumber = 11;
                                Debug.Log("neljännen themen viimeinen kenttä");
                                GameManager.instance.sceneLoader("Desert level 3");
                            }
                        }
                        if (theme == 4)
                        {
                            if (j == 0)
                            {
                                GameManager.instance.selectedNumber = 12;
                                Debug.Log("viidennen themen eka kenttä");
                                GameManager.instance.sceneLoader("Lava level 1");
                            }
                            if (j == 1)
                            {
                                GameManager.instance.selectedNumber = 13;
                                Debug.Log("viidennen themen toinen kenttä");
                                GameManager.instance.sceneLoader("Lava level 3");
                            }
                            if (j == 2)
                            {
                                GameManager.instance.selectedNumber = 14;
                                Debug.Log("viidennen themen viimeinen kenttä");
                                GameManager.instance.sceneLoader("Lava level 4");
                            }
                        }
                    }
                }
            }
        }

        else if (!ray)
        {
            //levelSelect = false;
            Debug.Log("ei osu");
            //levelSelect = false;
            highlight.gameObject.SetActive(false);
            //gameLevels.gameObject.SetActive(false);
        }

    }

    public void playGame()
    {
        AudioSource.PlayClipAtPoint(plob, transform.position);
        playButton.gameObject.SetActive(false);
        mainMenuPic.gameObject.SetActive(false);
        levels[0].GetComponent<CircleCollider2D>().enabled = true;

    }
    void Unlock()
    {
        if (!GameManager.instance.loadingScreen)
        {
            currentTime += Time.deltaTime;
            if (GameManager.instance.firstUnlock && !GameManager.instance.secondUnlock)
            {
                if (currentTime <= TimeitTakesToFade)
                {
                    Debug.Log("firstunlock");
                    fadeValue = 1 - (currentTime / TimeitTakesToFade);
                    mappi[0].color = new Color(1, 1, 1, fadeValue);
                    Debug.Log(fadeValue);
                    if(fadeValue <= 0.01f)
                    {
                        levels[1].GetComponent<CircleCollider2D>().enabled = true;
                        levels[1].GetComponent<SpriteRenderer>().enabled = true;
                    }
                }

            }
            if (GameManager.instance.secondUnlock && !GameManager.instance.thirdUnlock)
            {
                if (currentTime <= TimeitTakesToFade)
                {
                    Debug.Log("sescond unlock");
                    fadeValue = 1 - (currentTime / TimeitTakesToFade);
                    mappi[1].color = new Color(1, 1, 1, fadeValue);

                }
                if (fadeValue <= 0.01f)
                {
                    levels[2].GetComponent<CircleCollider2D>().enabled = true;
                    levels[2].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            if (GameManager.instance.thirdUnlock && !GameManager.instance.fourthUnlock)
            {
                if (currentTime <= TimeitTakesToFade)
                {
                    Debug.Log("third unlock");
                    fadeValue = 1 - (currentTime / TimeitTakesToFade);
                    mappi[2].color = new Color(1, 1, 1, fadeValue);

                }
                if (fadeValue <= 0.01f)
                {
                    levels[3].GetComponent<CircleCollider2D>().enabled = true;
                    levels[3].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            if (GameManager.instance.fourthUnlock)
            {
                if (currentTime <= TimeitTakesToFade)
                {
                    Debug.Log("fourth unlock");
                    fadeValue = 1 - (currentTime / TimeitTakesToFade);
                    mappi[3].color = new Color(1, 1, 1, fadeValue);

                }
                if (fadeValue <= 0.01f)
                {
                    levels[4].GetComponent<CircleCollider2D>().enabled = true;
                    levels[4].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    void unlocking()
    {
        if (GameManager.instance.firstUnlock)
        {
            Debug.Log("first unlock");
            mappi[0].GetComponent<SpriteRenderer>().enabled = false;
            levels[1].GetComponent<CircleCollider2D>().enabled = true;
            levels[1].GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.instance.secondUnlock)
        {
            Debug.Log("Second unlock");
            mappi[1].GetComponent<SpriteRenderer>().enabled = false;
            levels[2].GetComponent<CircleCollider2D>().enabled = true;
            levels[2].GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.instance.thirdUnlock)
        {
            Debug.Log("Third unlock");
            mappi[2].GetComponent<SpriteRenderer>().enabled = false;
            levels[3].GetComponent<CircleCollider2D>().enabled = true;
            levels[3].GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GameManager.instance.fourthUnlock)
        {
            Debug.Log("Fourth unlock");
            mappi[3].GetComponent<SpriteRenderer>().enabled = false;
            levels[4].GetComponent<CircleCollider2D>().enabled = true;
            levels[4].GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    public void MainMenu()
    {
        if (pressNumber == 0)
        {
            GameManager.instance.sceneLoader("MainMenu");
            pressNumber++;
        }
    }
}
