using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Rigidbody2D myRB;
    public float speed;
    public float fan = 1f;
    float timer;
    public float idleTimer;
    bool moving;
    public bool isGrounded;
    public bool movingRight;
    public bool isTouchingWall;
    RaycastHit2D hit;
    SpriteRenderer spriteRend;
    LayerMask layerMask;


    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        timer = 0f;
        moving = false;
        movingRight = true;
        isTouchingWall = false;
        isGrounded = false;
        spriteRend = GetComponent<SpriteRenderer>();
        idleTimer = 0f;
        layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {

            spriteRend.flipX = false;

            if (moving && myRB.velocity.x == 0f)
            {
                idleTimer += 10 * Time.deltaTime;
                if (idleTimer >= 3f)
                {
                    movingRight = false;
                    idleTimer = 0f;
                }
            }
        }
        else
        {

            spriteRend.flipX = true;

            if (moving && myRB.velocity.x == 0f)
            {
                idleTimer += 10 * Time.deltaTime;
                if (idleTimer >= 3f)
                {
                    movingRight = true;
                    idleTimer = 0f;
                }

            }
        }
        if (!moving)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 5 && !moving)
        {
            Debug.Log(timer);
            moving = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !moving)
        {
            Debug.Log("jloj");
            moving = true;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1f, layerMask);
        
        if (hit && hit.transform.tag == "Ground")
        {
            Debug.Log(hit.transform);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (isGrounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector2.up, hit.normal), 5f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector2.up, Vector3.zero), 5f * Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        if (moving && movingRight)
        {
            myRB.velocity = new Vector2(speed * Time.deltaTime, myRB.velocity.y);
        }
        else if (moving && !movingRight)
        {
            myRB.velocity = new Vector2(-speed * Time.deltaTime, myRB.velocity.y);
        }
    }

    //void OnTriggerStay2D(Collider2D collider)
    //{
    //    if(collider.tag == "Fan")
    //    {
    //        //transform.Translate(0, fan * Time.deltaTime, 0);
    //        myRB.velocity = new Vector2(myRB.velocity.x, fan);
    //        Debug.Log("puhallin puhuroi");            
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("trappe'd");
            Debug.Log("gaemover");
            Destroy(collision.gameObject);
        }
    }
}
