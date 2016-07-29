using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip dogWoof;
    public AudioClip clickSound;
    public Button playButton;
    bool played;
    public bool soundEffects;
    public bool music;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        played = false;
        
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            played = false;
        }
        if (playButton != null)
        {
            if (!playButton.interactable && soundEffects)
            {
                PlayWoof();
                played = true;
            }
        }
        if (music)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void PlayWoof()
    {
        if (!played && soundEffects)
        {
            audioSource.clip = dogWoof;
            audioSource.Play();
            played = true;
            
        }
    }
    public void PlayMenuButtonSound()
    {
        if (!played && soundEffects)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
            played = true;
        }
    }
    
}
