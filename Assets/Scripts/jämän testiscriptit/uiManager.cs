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
    int threeStar, twoStar, oneStar;
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
            twoStar = 6;  
        }
        if(level == "JonnaTestMobile")
        {
            threeStar = 6;
            twoStar = 7;
        }
            if (BlockSpawner.instance.blocksUsed <= threeStar)
            {
                ThreeStars();
                Debug.Log(BlockSpawner.instance.blocksUsed);

            }
            else if (BlockSpawner.instance.blocksUsed <= twoStar)
            {
                Debug.Log(BlockSpawner.instance.blocksUsed);
                TwoStars();
            }
            else
            {
                Debug.Log(BlockSpawner.instance.blocksUsed);
            ThreeStars();
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
        GameManager.instance.levelNumber[GameManager.instance.selectedNumber] = starAmount;
       // GameManager.instance.continued = true;
        Time.timeScale = 1;
        GameManager.instance.sceneLoader("MenuMap");

    }
    public void returnMapMenu()
    {
        //GameManager.instance.continued = true;
       // GameManager.instance.pauseState = false;
        GameManager.instance.sceneLoader("MenuMap");
    }
    public void restart()
    {
        GameManager.instance.pauseState = false;
        Application.LoadLevel(Application.loadedLevel);
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
        if (!GameManager.instance.pauseState)
        {
            GameManager.instance.pauseState = true;
            menu.gameObject.SetActive(true);
        }
    }
    public void gameContinue()
    {
        GameManager.instance.pauseState = false;
        menu.gameObject.SetActive(false);
    }
    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }
}
