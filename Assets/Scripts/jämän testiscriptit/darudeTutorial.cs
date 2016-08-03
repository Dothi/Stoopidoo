using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class darudeTutorial : MonoBehaviour {

    public Image SandStorm;
    public bool pause;
	// Use this for initialization
	void Start () {
        pause = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(pause)
        {
            GameManager.instance.pauseState = true;
        }
	}

    public void Close()
    {
        pause = false;
        SandStorm.gameObject.SetActive(false);
        GameManager.instance.pauseState = false;
    }
}
