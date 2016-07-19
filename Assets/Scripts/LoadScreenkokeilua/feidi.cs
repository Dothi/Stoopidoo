using UnityEngine;
using System.Collections;

public class feidi : MonoBehaviour {
    float timer;
    public FadeSprite blackScreenCover;
    public FadeSprite kajakLogo;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= 2)
        {
            Debug.Log("TADAA");
            StartCoroutine(blackScreenCover.FadeOut());
            StartCoroutine(kajakLogo.FadeOut());
        }
	}
}
