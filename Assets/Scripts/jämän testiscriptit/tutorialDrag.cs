using UnityEngine;
using System.Collections;

public class tutorialDrag : MonoBehaviour {

    Vector3 offset;
    public bool isHit;
    public bool rotating;
    public bool leftFirst;
    Vector2 v2 = new Vector2();
    float newAngle;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.touches.Length > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            Vector3 pos = new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, -Camera.main.transform.position.z);
            if (Input.touches[0].phase == TouchPhase.Began && transform.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                offset = transform.position - Camera.main.ScreenToWorldPoint(pos);
                isHit = true;
                
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                isHit = false;
                Debug.Log("LOL ET PAINA RUUTUA");
            }
            if(isHit)
            {
                transform.position = Camera.main.ScreenToWorldPoint(pos) + offset;
            }

            if (Input.touches.Length == 2)
            {
                Rotate();
            }
            else
                rotating = false;
            if (rotating)
            {
                if(Input.touches.Length == 2)
                {
                    
                    if(Input.touches[1].phase == TouchPhase.Began)
                    {
                        if (Input.touches[0].position.x < Input.touches[1].position.x) { leftFirst = true; }
                        if (Input.touches[0].position.x > Input.touches[1].position.x) { leftFirst = false; }
                    }
                    if(leftFirst)
                    {
                        v2 = Input.touches[1].position - Input.touches[0].position;
                    }
                    if(!leftFirst)
                    {
                        v2 = Input.touches[0].position - Input.touches[1].position;
                    }

                    newAngle = Mathf.Atan2(v2.y, v2.x);
                    transform.rotation = Quaternion.EulerAngles(0f, 0f, newAngle);

                    Vector3 newPos = new Vector3((Input.touches[1].position.x + Input.touches[0].position.x) / 2, (Input.touches[1].position.y + Input.touches[0].position.y) / 2, -Camera.main.transform.position.z - 5f);
                    transform.position = Camera.main.ScreenToWorldPoint(newPos);
                }
                //else if (Input.touches.Length == 2)
                //{
                //    v2 = Input.touches[0].position - Input.touches[1].position;
                //    if(v2.x < 0)
                //    {
                //        newAngle = Mathf.Atan2(-v2.y, -v2.x);
                //        transform.rotation = Quaternion.EulerAngles(0f, 0f, newAngle);
                //    }
                //    else
                //    {
                //        newAngle = Mathf.Atan2(v2.y, v2.x);
                //        transform.rotation = Quaternion.EulerAngles(0f, 0f, newAngle);
                //    }
                //}

                    
                    Debug.Log("vasemmalla puolen");
              
            }
        }
	}
    void Rotate()
    {
        rotating = true;
    }
}
