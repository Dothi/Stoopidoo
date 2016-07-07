using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Text WinLose;
    public Transform Victory;
    public Text startTime;
    //public Transform star1;
    //public Transform star2;
    //public Transform star3;
    public Image star01;
    public Image star02;
    public Image star03;
    int starAmount;
    int threeStar, twoStar, oneStar;

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
        WinLose.gameObject.SetActive(false);
        Victory.gameObject.SetActive(false);
        startTime = GameObject.Find("StartTime").GetComponent<Text>();
        startTime.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

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
        GameManager.instance.continued = true;
        Time.timeScale = 1;
        GameManager.instance.sceneLoader("MenuMap");

    }
    public void returnMapMenu()
    {
        GameManager.instance.continued = true;
        GameManager.instance.sceneLoader("MenuMap");
    }
}
