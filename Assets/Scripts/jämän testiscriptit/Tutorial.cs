using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Sprite[] tutorial;
    SpriteRenderer tuto;
    public GameObject _tutor;
    public GameObject buttons;
    public GameObject rotatingBlock;
    public GameObject accept;
    public GameObject cancel;
    public GameObject restart;
    public GameObject fastForward;
    public GameObject goal;
    public GameObject WholeScreen;
    public GameObject SkipTutorial;
    public GameObject soundEffects;
    public int tutorialNumber;
    public bool tutorialDone;
    public Button buttonNext;
    public SpriteRenderer darken;
    SpriteRenderer player;
    
	// Use this for initialization
	void Start () {
        tuto = GetComponent<SpriteRenderer>();
        tutorialNumber = 0;
        Color spriteColor = darken.color;
        spriteColor.a = 1f;
        darken.color = spriteColor;
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        soundEffects = GameObject.FindGameObjectWithTag("SoundEffects");
        tutorialDone = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!tutorialDone)
        {
            GameManager.instance.pauseState = true;
        }
        else if (tutorialDone)
        {
            GameManager.instance.pauseState = false;
        }
        Color spriteColor = darken.color;
        spriteColor.a = 0.7f;
        darken.color = spriteColor;
        if (tutorialNumber <= 8)
        {
            
            tuto.sprite = tutorial[tutorialNumber];
        }
        switch (tutorialNumber)
        {
            case 0:
                Debug.Log("Aijai ei oo mittää painettu");
                break;
            case 1:
                player.sortingLayerName = "Tutorial";
                
                break;
            case 2:
                goal.gameObject.SetActive(true);
                player.sortingLayerName = "Default";
                break;
            case 3:
                goal.gameObject.SetActive(false);
                buttons.gameObject.SetActive(true);
                Debug.Log("Kolmesti painettu");
                break;
            case 4:
                buttons.gameObject.SetActive(false);
                WholeScreen.gameObject.SetActive(false);
                rotatingBlock.gameObject.SetActive(true);
                Debug.Log("neljästi painettu");
                break;
            case 5:
                Debug.Log("viidesti painettu");
                WholeScreen.gameObject.SetActive(true);
                rotatingBlock.gameObject.SetActive(false);
                accept.gameObject.SetActive(true);
                break;
            case 6:
                Debug.Log("kuudesti painettu");
                accept.gameObject.SetActive(false);
                cancel.gameObject.SetActive(true);
                break;
            case 7:
                Debug.Log("seittämästi painettu");
                cancel.gameObject.SetActive(false);
                buttons.gameObject.SetActive(true);
                break;
            case 8:
                Debug.Log("kaheksa painettu");
                buttons.gameObject.SetActive(false);
                fastForward.gameObject.SetActive(true);
                break;
            case 9:
                Debug.Log("kököö");
                fastForward.gameObject.SetActive(false);
                WholeScreen.gameObject.SetActive(false);
                restart.gameObject.SetActive(true);
                break;
  
        }
        Debug.Log(tutorial.Length);
        if(tutorialNumber >= 9)
        {
            GameManager.instance.pauseState = false;
            tutorialDone = true;
            tuto.enabled = false;
            _tutor.gameObject.SetActive(false);
            buttonNext.gameObject.SetActive(false);
            
            Debug.Log("button should be enabled");
        }
	}

    public void nextButton()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        //if (!tutorialDone)
        //{
            if (tutorialNumber < tutorial.Length)
            {
                tutorialNumber++;
            }
        //}
    }
    public void skipButton()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        GameManager.instance.pauseState = false;
        tutorialDone = true;
        tuto.enabled = false;
        _tutor.gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(false);
        WholeScreen.gameObject.SetActive(false);
    }
}
