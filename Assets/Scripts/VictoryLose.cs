using UnityEngine;
using System.Collections;

public class VictoryLose : MonoBehaviour {
    public Transform Victory;
    public Transform Lose;
    bool victory;
    bool lose;
	// Use this for initialization
	void Start () {
        victory = false;
        lose = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Victoryyyy!");
            Debug.Log("gaemover");
            Destroy(this.gameObject);
            Victory.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "LoseBlock")
        {
            Debug.Log("Loseeeeer!");
            Destroy(this.gameObject);
            Lose.gameObject.SetActive(true);
        }
    }
}
