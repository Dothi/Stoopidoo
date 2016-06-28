using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    float speed = 10f;
    public Transform player;
    public Transform endPoss;
    public Transform startPoss;
     float pOffset = 3;
    Vector3 pos;
    Vector3 endPos;
    Vector3 startPos;
    float pointerx;
    float xMin;
    float xMax;
    public bool mouseClicked;
	// Use this for initialization
	void Start () {
        endPos.x = endPoss.position.x;
        startPos.x = startPoss.position.x;
        xMax = endPoss.position.x - 9;
        xMin = startPos.x + 9;
        mouseClicked = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButton(0) && !BlockSpawnerBackup.instance.isDragging)
        {
            mouseClicked = true;
            if (transform.position.x >= xMin)
            {
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
                }
            }
            if (transform.position.x <= xMax)
            { 
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
                }
            }
        }
        else
            mouseClicked = false;
    }

    //void LateUpdate()
    //{
    //    if (!mouseClicked)
    //    {
    //        pos.x = player.position.x;
    //        if (Movement.instance.movingRight)
    //        {
    //            pOffset +=Time.deltaTime * 3;
    //            if (pOffset >= 3)
    //                pOffset = 3;
    //        }
    //        if (!Movement.instance.movingRight)
    //        {
    //            pOffset -= Time.deltaTime * 3;
    //            if (pOffset <= -3)
    //                pOffset = -3;
    //        }
            
    //        transform.position = new Vector3(Mathf.Clamp(pos.x + pOffset, xMin, xMax), transform.position.y, transform.position.z);
    //    }
    //}

    void asd()
    {
        //if(Input.touchCount > 0 && !BlockSpawner.instance.isDragging)
        //{
        //    foreach(Touch touch in Input.touches)
        //    {
        //        if(touch.fingerId < 1)
        //        {
        //            switch (touch.phase)
        //            {
        //                case TouchPhase.Began:
        //                    pointerx = Input.touches[0].deltaPosition.x;
        //                    break;
        //                case TouchPhase.Moved:
        //                    if (Input.touches[0].deltaPosition.x > 0)
        //                    {
        //                        transform.position -= new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * speed, 0, 0);
        //                    }
        //                    if (Input.touches[0].deltaPosition.x < 0)
        //                    {
        //                        transform.position -= new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * speed, 0, 0);
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
