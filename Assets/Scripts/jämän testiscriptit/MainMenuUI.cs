using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public Image credits, settings;
    public Button backbutton, closeSettings;
    //public Button closeSettings;
    public Toggle music, sound;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Credits()
    {
        credits.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
    }
    public void BackButton()
    {
        credits.gameObject.SetActive(false);
        backbutton.gameObject.SetActive(false);
    }
    public void Settings()
    {
        settings.gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        settings.gameObject.SetActive(false);
    }
}
