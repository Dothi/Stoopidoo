using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Rigidbody2D myRB;
    public float speed = 1f;
    public float fan = 1f;
    float timer;
    bool moving;
    bool movingRight;
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        timer = 0f;
        moving = false;
        movingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!moving)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 5 && !moving)
        {
            Debug.Log(timer);
            moving = true;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && !moving)
        {
            Debug.Log("jloj");
            moving = true;
        }
	}
    void FixedUpdate()
    {
        if (moving && movingRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);  
        }
        else if(moving && !movingRight)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);  
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Fan")
        {
            //transform.Translate(0, fan * Time.deltaTime, 0);
            myRB.velocity = new Vector2(0, fan);
            Debug.Log("puhallin puhuroi");            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("trappe'd");
            Debug.Log("gaemover");
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" && movingRight)
        {
            movingRight = false;
        }
        if (other.gameObject.tag == "Wall" && !movingRight)
        {
            movingRight = true;
        }
    }
}
