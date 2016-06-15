using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryLose : MonoBehaviour {
    public Text WinLose;
    float timer = 0;
    bool win;
    bool lose;
	// Use this for initialization
	void Start ()
    {
        WinLose.gameObject.SetActive(false);
        win = false;
        lose = false;
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
            timer += Time.deltaTime;
            if(timer >5)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Victoryyyy!");
            WinLose.gameObject.SetActive(true);
            WinLose.text = "Victory";
            win = true;

            //Victory.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "LoseBlock")
        {
            Debug.Log("Loseeeeer!");
            //Destroy(this.gameObject);
            WinLose.gameObject.SetActive(true);
            WinLose.text = "You Lose";
            lose = true;
            //Lose.gameObject.SetActive(true);
        }
    }
}
