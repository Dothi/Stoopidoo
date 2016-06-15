using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryLose : MonoBehaviour {
    public Text WinLose;
    float timer = 0;
    bool win;
	// Use this for initialization
	void Start ()
    {
        WinLose.gameObject.SetActive(false);
        win = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(win)
        {
            timer += Time.deltaTime;
            if(timer >= 10)
            {
                Destroy(this.gameObject);
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
            Destroy(this.gameObject);
            WinLose.gameObject.SetActive(true);
            WinLose.text = "You Lose";
            //Lose.gameObject.SetActive(true);
        }
    }
}
