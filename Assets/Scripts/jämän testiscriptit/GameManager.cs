using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

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
    public bool firstUnlock, secondUnlock, thirdUnlock, fourthUnlock;
    public bool gameStarted;
    public bool loadingScreen;
    public bool saved;
    public bool pauseState;
    public bool doubleSpeed;
    public bool logo = true;
    public bool soundEffects;
    public bool music;
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
        DontDestroyOnLoad(gameObject);
        destroyed = false;
    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < levelNumber.Length; i++)
        {
            
            levelNumber[i] = PlayerPrefs.GetInt("Level " + i + "Stars", levelNumber[i]);
        }

        if (PlayerPrefs.GetInt("FirstUnlock") == 1)
        {
            firstUnlock = true;
            if (PlayerPrefs.GetInt("SecondUnlock") == 1)
            {
                secondUnlock = true;
                if(PlayerPrefs.GetInt("ThirdUnlock") == 1)
                {
                    thirdUnlock = true;
                    if(PlayerPrefs.GetInt("FourthUnlock") == 1)
                    {
                        fourthUnlock = true;
                    }
                }
            }
        }

        continued = false;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update() {
        if (loadingScreen)
        {
            for (int i = 0; i < levelNumber.Length; i++)
            {
                PlayerPrefs.SetInt("Level " + i + "Stars", levelNumber[i]);
            }
            
        }
        if (firstUnlock)
        {
            PlayerPrefs.SetInt("FirstUnlock", 1);
            if (secondUnlock)
            {
                PlayerPrefs.SetInt("SecondUnlock", 1);
                if (thirdUnlock)
                {
                    PlayerPrefs.SetInt("ThirdUnlock", 1);
                    if (fourthUnlock)
                    {
                        PlayerPrefs.SetInt("FourthUnlock", 1);
                    }
                }
            }
        }
        
        
	}

    public void sceneLoader(string sceneName)
    {
        camePos = Camera.main.transform.position;
        ScreenManager.instance.StartCoroutine(ScreenManager.instance.LoadSceneAsync(sceneName));
    }
}
