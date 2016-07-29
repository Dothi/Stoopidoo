using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryLose : MonoBehaviour {
    //public Text WinLose;
    float timer = 0;
    bool goalSoundPlayed;
    bool loseSoundPlayed;
    public bool win;
    public bool lose;
    GameObject Canvas;
    GameObject soundEffects;
    Movement mov;
	// Use this for initialization
	void Start ()
    {
        //WinLose.gameObject.SetActive(false);
        win = false;
        lose = false;
        goalSoundPlayed = false;
        loseSoundPlayed = false;
        mov = GetComponent<Movement>();
        Time.timeScale = 1;
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        soundEffects = GameObject.FindGameObjectWithTag("SoundEffects");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(win && !lose)
        {
            
            if (!goalSoundPlayed)
            {
                soundEffects.transform.GetChild(0).GetComponent<AudioSource>().clip = null;
                soundEffects.GetComponent<SoundEffects>().PlayGoalSound();
                goalSoundPlayed = true;
            }
            timer += Time.deltaTime;
            if(timer >= 10)
            {
                //Destroy(this.gameObject);
                Debug.Log("peli paussille ny");
            }
        }
    if(lose && !win)
        {
            if (!loseSoundPlayed)
            {
                soundEffects.transform.GetChild(0).GetComponent<AudioSource>().clip = null;
                soundEffects.GetComponent<SoundEffects>().PlayLoseSound();
                loseSoundPlayed = true;
            }
            //WinLose.gameObject.SetActive(true);
            uiManager.instance.Lose.gameObject.SetActive(true);

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
