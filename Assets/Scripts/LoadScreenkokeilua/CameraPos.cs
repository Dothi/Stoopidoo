using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {

    public Vector3 jee;
	// Use this for initialization
	void Start () {
        jee.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        jee.x = GameManager.instance.camePos.x;
        jee.y = GameManager.instance.camePos.y;
        transform.position = jee;

        //transform.position = Camera.main.transform.position;
    }
}
