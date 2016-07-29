using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Image Lose;
    public Sprite[] timerSprites;
    public Image CountDown;
    public Transform Victory;
    public Transform menu;
    public Button fastForward;
    public Button pauseMenu;
    //public Transform star1;
    //public Transform star2;
    //public Transform star3;
    public Image star01;
    public Image star02;
    public Image star03;
    int starAmount;
    int threeStar, twoStar, oneStar, pressNumber;
    public Button map;
    public GameObject wantToQuit;
    public Image mapButton;
    public GameObject soundEffects;
    //public bool doubleSpeed;

    public static uiManager instance;
    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Victory.gameObject.SetActive(false);
        pressNumber = 0;
        //Color spriteColor = mapButton.color;
        //spriteColor.a = 1f;
        //mapButton.color = spriteColor;
        soundEffects = GameObject.FindGameObjectWithTag("SoundEffects");

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.doubleSpeed)
        {
            Time.timeScale = 2;
            Debug.Log("Double pseed!");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("going Normal");
        }
    }

    public void ScoreStars()
    {
        string level = Application.loadedLevelName;
        if (level == "Jonna Forest 1")
        {
            threeStar = 4;
            twoStar = 5;
        }
        if (level == "JonnaTestMobile")
        {
            threeStar = 5;
            twoStar = 6;
        }
        if (level == "Forest level 3")
        {
            threeStar = 6;
            twoStar = 7;
        }
        if (level == "Winter level 1")
        {
            threeStar = 6;
            twoStar = 7;
        }
        if (level == "winter level 2")
        {
            threeStar = 6;
            twoStar = 7;
        }
        if (level == "Winter level 3")
        {
            threeStar = 11;
            twoStar = 12;
        }
        if (level == "Japan level 1")
        {
            threeStar = 3;
            twoStar = 4;
        }
        if (level == "Japan level 4")
        {
            threeStar = 2;
            twoStar = 4;
        }
        if (level == "Japan level 5")
        {
            threeStar = 4;
            twoStar = 6;
        }
        if (level == "Desert level 1")
        {
            threeStar = 3;
            twoStar = 4;
        }
        if (level == "Desert level 2")
        {
            threeStar = 4;
            twoStar = 5;
        }
        if (level == "Desert level 3")
        {
            threeStar = 4;
            twoStar = 5;
        }
        if (level == "Lava level 1")
        {
            threeStar = 8;
            twoStar = 10;
        }
        if (level == "Lava level 3")
        {
            threeStar = 13;
            twoStar = 16;
        }
        if (level == "Lava level 4")
        {
            threeStar = 8;
            twoStar = 10;
        }
        if (BlockSpawner.instance.blocksUsed <= threeStar)
        {
            ThreeStars();
            Debug.Log(BlockSpawner.instance.blocksUsed + "Blocks used");

        }
        else if (BlockSpawner.instance.blocksUsed <= twoStar)
        {
            Debug.Log(BlockSpawner.instance.blocksUsed + "Blocks used");
            TwoStars();
        }
        else
        {
            Debug.Log(BlockSpawner.instance.blocksUsed + "blocks used");
            OneStar();
        }
    }

    public void ThreeStars()
    {
        starAmount = 3;
        star01.color = new Color(1f, 1f, 1f, 1f);
        star02.color = new Color(1f, 1f, 1f, 1f);
        star03.color = new Color(1f, 1f, 1f, 1f);
    }
    public void TwoStars()
    {
        starAmount = 2;
        star01.color = new Color(1f, 1f, 1f, 1f);
        star02.color = new Color(1f, 1f, 1f, 1f);
        star03.color = new Color(0f, 0f, 0f, 0.4f);
    }
    public void OneStar()
    {
        starAmount = 1;
        star01.color = new Color(1f, 1f, 1f, 1f);
        star02.color = new Color(0f, 0f, 0f, 0.4f);
        star03.color = new Color(0f, 0f, 0f, 0.4f);
    }
    public void ContinueGame()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        if (pressNumber == 0)
        {
            GameManager.instance.levelNumber[GameManager.instance.selectedNumber] = starAmount;
            GameManager.instance.continued = true;
            Time.timeScale = 1;
            GameManager.instance.sceneLoader("MenuMap");
            pressNumber++;
        }

    }
    public void returnMapMenu()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        Color spriteColor = mapButton.color;
        spriteColor.a = 0.7f;
        mapButton.color = spriteColor;
        map.interactable = false;
        GameManager.instance.sceneLoader("MenuMap");
        GameManager.instance.continued = true;
        //if (pressNumber == 0)
        //{
        //    GameManager.instance.continued = true;
        //    // GameManager.instance.pauseState = false;
        //    GameManager.instance.sceneLoader("MenuMap");
        //    pressNumber++;
        //}
    }
    public void restart()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        if (pressNumber == 0)
        {
            GameManager.instance.pauseState = false;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void fastSpeed()
    {
        if(!GameManager.instance.pauseState)
        GameManager.instance.doubleSpeed = true;
    }
    public void normalSpeed()
    {
        if (!GameManager.instance.pauseState)
            GameManager.instance.doubleSpeed = false;
    }
    public void gamePause()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        if (!GameManager.instance.pauseState)
        {
            GameManager.instance.pauseState = true;
            menu.gameObject.SetActive(true);
        }
    }
    public void gameContinue()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        GameManager.instance.pauseState = false;
        menu.gameObject.SetActive(false);
    }
    public void quitGame()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        wantToQuit.gameObject.SetActive(true);
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#endif
//        Application.Quit();

    }
    public void yes()
    {
        soundEffects.GetComponent<SoundEffects>().PlayLoseSound();


        Invoke("QuitYes", 3f);
       
        
    }
    public void QuitYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void no()
    {
        wantToQuit.gameObject.SetActive(false);
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
    }
}
