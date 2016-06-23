using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    float speed = 10f;
    public Transform player;
    public Transform goal;
     int pOffset = 7;
     int gOffset = 7;
    Vector3 pos;
    Vector3 goalPos;

    float pointerx;
	// Use this for initialization
	void Start () {
        pos.z = transform.position.z;
        goalPos.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        pos.x = player.position.x + pOffset;
        goalPos.x = goal.position.x - gOffset;
    }

    void LateUpdate ()
    {
        if(Input.touchCount > 0 && !BlockSpawner.instance.isDragging)
        {
            foreach(Touch touch in Input.touches)
            {
                if(touch.fingerId < 1)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            pointerx = Input.touches[0].deltaPosition.x;
                            break;
                        case TouchPhase.Moved:
                            if (Input.touches[0].deltaPosition.x > 0)
                            {
                                transform.position -= new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * speed, 0, 0);
                            }
                            if (Input.touches[0].deltaPosition.x < 0)
                            {
                                transform.position -= new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * speed, 0, 0);
                            }
                            break;
                    }
                }
            }
        }
        //if (Input.GetMouseButton(0) && !BlockSpawner.instance.isDragging)
        //{
        //    if (Input.GetAxis("Mouse X") > 0)
        //    {
        //        transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
        //    }
        //    else if (Input.GetAxis("Mouse X") < 0)
        //    {
        //        transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
        //    }
        //}

        if(transform.position.x < player.position.x + pOffset )
        {
            transform.position = pos;
        }
        if(transform.position.x > goal.position.x - gOffset)
        {
            transform.position = goalPos;
        }


    }
}
