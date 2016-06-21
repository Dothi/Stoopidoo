using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Text WinLose;
    //public Transform star1;
    //public Transform star2;
    //public Transform star3;
    //public Image star01;
    //public Image star02;
    //public Image star03;
    Image[] stars;

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
        stars = gameObject.GetComponentsInChildren<Image>();


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreStars()
    {
            if (BlockSpawner.instance.blocksUsed <= 5)
            {
            stars[0].color = new Color(1f, 1f, 1f, 1f);
            stars[1].color = new Color(1f, 1f, 1f, 1f);
            stars[2].color = new Color(1f, 1f, 1f, 1f);
            }
            else if (BlockSpawner.instance.blocksUsed <= 7)
            {
            stars[0].color = new Color(1f, 1f, 1f, 1f);
            stars[1].color = new Color(1f, 1f, 1f, 1f);
            stars[2].color = new Color(0f, 0f, 0f, 0.4f);
            }
            else
            {
            stars[0].color = new Color(1f, 1f, 1f, 1f);
            stars[1].color = new Color(0f, 0f, 0f, 0.4f);
            stars[2].color = new Color(0f, 0f, 0f, 0.4f);
            }        
    }
}
