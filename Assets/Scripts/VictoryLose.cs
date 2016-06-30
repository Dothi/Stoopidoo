using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryLose : MonoBehaviour {
    //public Text WinLose;
    float timer = 0;
    public bool win;
    public bool lose;
    GameObject Canvas;
	// Use this for initialization
	void Start ()
    {
        //WinLose.gameObject.SetActive(false);
        win = false;
        lose = false;
        Time.timeScale = 1;
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(win)
        {
            
            timer += Time.deltaTime;
            if(timer >= 10)
            {
                //Destroy(this.gameObject);
                Debug.Log("peli paussille ny");
            }
        }
    if(lose)
        {
            //WinLose.gameObject.SetActive(true);
            uiManager.instance.WinLose.gameObject.SetActive(true);
            uiManager.instance.WinLose.text = "You Lose";
            //WinLose.text = "You Lose";
            timer += Time.deltaTime;
            if(timer >= 3)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal" && !win)
        {
            
            Debug.Log("Victoryyyy!");
            //WinLose.gameObject.SetActive(true);
            uiManager.instance.WinLose.gameObject.SetActive(true);
            uiManager.instance.WinLose.text = "Victory";
            uiManager.instance.WinLose.color = Color.green;
            uiManager.instance.Victory.gameObject.SetActive(true);
            uiManager.instance.ScoreStars();
            win = true;
            
            Time.timeScale = 0;

            //Victory.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "LoseBlock" && !lose)
        {
            Debug.Log("Loseeeeer!");
            //Destroy(this.gameObject);
            
            lose = true;
            
            //Lose.gameObject.SetActive(true);
        }
    }
}
