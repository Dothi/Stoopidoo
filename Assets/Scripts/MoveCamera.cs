using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    float speed = 10f;
    public Transform player;
    public Transform rightEnd;
    //public Transform rightEnd;
    public Transform leftEnd;
     int pOffset = 3;
     int gOffset = 9;
    Vector3 pos;
    Vector3 endPos;
    Vector3 startPos;

    float pointerx;
	// Use this for initialization
	void Start () {
        pos.z = transform.position.z;
        endPos.z = transform.position.z;
        startPos.z = transform.position.z;
        endPos.x = rightEnd.position.x;
        startPos.x = leftEnd.position.x;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButton(0) && !BlockSpawnerBackup.instance.isDragging)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 0);
            }
        }
    }

    void LateUpdate ()
    {

        if (Movement.instance.movingRight)
        {
            pos.x = player.position.x + pOffset;
            endPos.x = rightEnd.position.x - gOffset;
            if (transform.position.x < player.position.x + pOffset)
            {
                transform.position = pos;
            }
            if (transform.position.x > rightEnd.position.x - gOffset)
            {
                transform.position = endPos;
            }
        }

        if (!Movement.instance.movingRight)
        {
            pos.x = player.position.x - pOffset;
            endPos.x = leftEnd.position.x + gOffset;
            if (transform.position.x > player.position.x - pOffset)
            {
                transform.position = pos;
            }
            if (transform.position.x < leftEnd.position.x + gOffset)
            {
                transform.position = endPos;
            }
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
