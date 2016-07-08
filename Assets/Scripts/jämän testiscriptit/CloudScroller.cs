using UnityEngine;
using System.Collections;

public class CloudScroller : MonoBehaviour {

    public float speed = 0.5f;
    float pos = 0;
	// Use this for initialization
	void Start () {
	
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
        GameManager.instance.sceneLoader("MenuMap");
    }
}
