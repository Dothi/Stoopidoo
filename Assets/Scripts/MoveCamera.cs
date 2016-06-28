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
            Debug.Log("WOHO");
            if (transform.position.x >= xMin)
            {
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
                }
                else if (transform.position.x >= xMax)
                {
                   
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

    void LateUpdate()
    {
        if (!mouseClicked)
        {
            if (Movement.instance.movingRight)
            {
                pOffset += Time.deltaTime * 5;
                if (pOffset >= 3)
                    pOffset = 3;
                //pos.x = player.position.x + pOffset;
                //pOffset += Time.deltaTime * 2;
                //if(pOffset >= 3)
                //{
                //    pOffset = 3;
                //}
            }
            if (!Movement.instance.movingRight)
            {
                pOffset -= Time.deltaTime * 5;
                if (pOffset <= -3)
                    pOffset = -3;
                //pos.x = player.position.x + pOffset;
                //pOffset -= Time.deltaTime;
                //if(pOffset <= -3)
                //{
                //    pOffset = -3;
                //}
            }
            pos.x = player.position.x + pOffset;
            transform.position = new Vector3(Mathf.Clamp(pos.x, xMin, xMax), transform.position.y, transform.position.z);
            //if (Movement.instance.movingRight)
            //{
            //    pos.x = player.position.x + pOffset;
            //    endPos.x = rightEnd.position.x - gOffset;
            //    if (transform.position.x < player.position.x + pOffset)
            //    {
            //        transform.position = pos;
            //    }
            //    if (transform.position.x > rightEnd.position.x - gOffset)
            //    {
            //        transform.position = endPos;
            //    }

            //}

            //if (!Movement.instance.movingRight)
            //{
            //    pos.x = player.position.x - pOffset;
            //    endPos.x = leftEnd.position.x + gOffset;
            //    if (transform.position.x > player.position.x - pOffset)
            //    {
            //        transform.position = pos;
            //    }
            //    if (transform.position.x < leftEnd.position.x + gOffset)
            //    {
            //        transform.position = endPos;
            //    }
            //}

        }
    }

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
