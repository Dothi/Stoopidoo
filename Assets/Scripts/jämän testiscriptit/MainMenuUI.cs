using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    public Image credits, settings;
    public Button backbutton, closeSettings, quit, play, info, setting;
    public GameObject wantToQuit;
    public GameObject kajaklogo;
    public GameObject soundEffects;
    GameManager gm;
    //public Button closeSettings;
    public Toggle music, sound;
    float timer;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffects = GameObject.FindGameObjectWithTag("SoundEffects");
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.logo)
        {
            kajaklogo.gameObject.SetActive(false);
        }

        if (sound.isOn)
        {
            gm.soundEffects = true;
        }
        else
        {
            gm.soundEffects = false;
        }
        if (music.isOn)
        {
            gm.music = true;
        }
        else
        {
            gm.music = false;
        }
    }
    public void Credits()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        credits.gameObject.SetActive(true);
        backbutton.gameObject.SetActive(true);
    }
    public void BackButton()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        credits.gameObject.SetActive(false);
        backbutton.gameObject.SetActive(false);
    }
    public void Settings()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        settings.gameObject.SetActive(true);
    }
    public void CloseSettings()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        settings.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        wantToQuit.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        setting.gameObject.SetActive(false);
    }
    public void yes()
    {
        soundEffects.GetComponent<SoundEffects>().PlayLoseSound();

        Invoke("QuitYes", 3f);
    }
    public void QuitYes()
    {
        Application.Quit();
    }
    public void no()
    {
        soundEffects.GetComponent<SoundEffects>().PlayMenuButtonSound();
        wantToQuit.gameObject.SetActive(false);
        quit.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        setting.gameObject.SetActive(true);
    }
}
