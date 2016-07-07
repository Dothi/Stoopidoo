using UnityEngine;
using System.Collections;

public class camPos : MonoBehaviour {

    void Awake()
    {
    }
	// Use this for initialization
	void Start () {
        transform.position = GameManager.instance.camPos;
        GameManager.instance.camePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    }
}
