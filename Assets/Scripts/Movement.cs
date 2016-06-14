using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Rigidbody2D myRB;
    public float speed;
    public float fan = 1f;
    float timer;
    bool moving;
    public bool movingRight;
    public bool isTouchingWall;
    RaycastHit2D hit;
    SpriteRenderer spriteRend;
    
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        timer = 0f;
        moving = false;
        movingRight = true;
        isTouchingWall = false;
        spriteRend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (movingRight)
        {
            hit = Physics2D.Raycast(transform.position, transform.right, .6f);
            spriteRend.flipX = false;
            if (hit && hit.collider.tag == "Wall")
            {
                movingRight = false;
            }
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, -transform.right, .6f);
            spriteRend.flipX = true;
            if (hit && hit.collider.tag == "Wall")
            {
                movingRight = true;
            }
        }
        if (hit)
        
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
            myRB.velocity = new Vector2(speed * Time.deltaTime, myRB.velocity.y);
        }
        else if(moving && !movingRight)
        {
            myRB.velocity = new Vector2(-speed * Time.deltaTime, myRB.velocity.y);
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
      /* else if (collision.gameObject.tag == "Wall" && movingRight && !isTouchingWall)
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
        }*/
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
       /* if (collision.gameObject.tag == "Wall" && isTouchingWall)
        {
            isTouchingWall = false;
        }
        else
        {
            isTouchingWall = true;
        }*/
    }
    
}
