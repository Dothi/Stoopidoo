using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Rigidbody2D myRB;
    public float speed = 1f;
    public float fan = 1f;
    float timer;
    bool moving;
    public bool movingRight;
    public bool isTouchingWall;
    public Vector3 vel;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        timer = 0f;
        moving = false;
        movingRight = true;
        isTouchingWall = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        vel = ((transform.position - pos) / Time.deltaTime).normalized;
        pos = transform.position;
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
       else if (collision.gameObject.tag == "Wall" && movingRight && !isTouchingWall)
        {
            movingRight = false;
            Debug.Log("a");
            isTouchingWall = true;
        }
        else if (collision.gameObject.tag == "Wall" && !movingRight && !isTouchingWall)
        {
            movingRight = true;
            Debug.Log("a");
            isTouchingWall = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && isTouchingWall)
        {
            isTouchingWall = false;
        }
        else
        {
            isTouchingWall = true;
        }
    }
    
}
