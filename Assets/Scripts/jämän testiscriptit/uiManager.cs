using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Text WinLose;
    public Transform Victory;
    //public Transform star1;
    //public Transform star2;
    //public Transform star3;
    public Image star01;
    public Image star02;
    public Image star03;


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

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreStars()
    {
        Debug.Log("adsofija");
            if (BlockSpawner.instance.blocksUsed <= 5)
            {
            Debug.Log(BlockSpawner.instance.blocksUsed);
            star01.color = new Color(1f, 1f, 1f, 1f);
            star02.color = new Color(1f, 1f, 1f, 1f);
            star03.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (BlockSpawner.instance.blocksUsed <= 7)
            {
            Debug.Log(BlockSpawner.instance.blocksUsed);
            star01.color = new Color(1f, 1f, 1f, 1f);
            star02.color = new Color(1f, 1f, 1f, 1f);
            star03.color = new Color(0f, 0f, 0f, 0.4f);
            }
            else
            {
            Debug.Log(BlockSpawner.instance.blocksUsed);
            star01.color = new Color(1f, 1f, 1f, 1f);
            star02.color = new Color(0f, 0f, 0f, 0.4f);
            star03.color = new Color(0f, 0f, 0f, 0.4f);
            }        
    }

    public void ContinueGame()
    {
        Application.LoadLevel("MenuMap");
    }
}
