using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class darudeTutorial : MonoBehaviour {

    public Button closeTutorial;
    public Image SandStorm;
	// Use this for initialization
	void Start () {
        GameManager.instance.pauseState = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Close()
    {
        SandStorm.gameObject.SetActive(false);
        closeTutorial.gameObject.SetActive(false);
        GameManager.instance.pauseState = false;
    }
}
