using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloudScroller : MonoBehaviour {

    public float speed = 0.5f;
    float pos = 0;
    public Button play;
    public int pressNumber;
	// Use this for initialization
	void Start () {
        pressNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        pos -= speed;
        if (pos > 0)
            pos += 1.0f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);
	}

    public void PlayGame()
    {
        play.interactable = false;
        GameManager.instance.sceneLoader("MenuMap");
        //if (pressNumber == 0)
        //{
        //    GameManager.instance.sceneLoader("MenuMap");
        //    pressNumber++;
        //}
    }
}
