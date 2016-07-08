using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float speed = 50f;
    public float fan = 1f;
    float hitLength;
    float timer;
    public float idleTimer;
    public bool moving;
    public bool isGrounded;
    public bool movingRight;
    public bool isTouchingWall;
    public bool iceWalk;
    bool started;
    RaycastHit2D hit;
    SpriteRenderer spriteRend;
    LayerMask layerMask;
    VictoryLose vl;
    BlockSpawner bs;
    public LayerMask DefaultTerrainLayerMask;
    public Vector3 vel;
    public static Movement instance;
    Animator anim;
    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawner").GetComponent<BlockSpawner>();
        timer = 5f;
        moving = false;
        movingRight = true;
        isTouchingWall = false;
        isGrounded = false;
        started = false;
        spriteRend = GetComponent<SpriteRenderer>();
        idleTimer = 0f;
        layerMask = 1 << LayerMask.NameToLayer("Player");


        layerMask = ~layerMask;
        vl = GetComponent<VictoryLose>();
    }

    // Update is called once per frame
    void Update()
    {
        
        vel = myRB.velocity;
        if (iceWalk)
        {
            moving = false;
        }
        if (vl.lose)
        {
            this.enabled = false;
        }
        if (!vl.win)
        {
            if (movingRight)
            {

                spriteRend.flipX = false;

                if (moving && myRB.velocity.x == 0f)
                {
                    idleTimer += 10 * Time.deltaTime;
                    Debug.Log(idleTimer);
                    if (idleTimer >= 1f)
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
                    if (idleTimer >= 1f)
                    {
                        movingRight = true;
                        idleTimer = 0f;
                    }

                }
            }
        }
        if (!moving && !started)
        {
            timer -= Time.deltaTime;
            uiManager.instance.startTime.text = "" + (int)(timer + 1);
        }
        if (timer <= 0 && !moving && !started)
        {
            Debug.Log(timer);
            uiManager.instance.startTime.enabled = false;
            moving = true;
            started = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !moving && !started)
        {
            Debug.Log("jloj");
            moving = true;
        }
        if (!iceWalk)
        {
            hitLength = 1.5f;
        }
        else
        {
            hitLength = 1.5f;
        }
        RaycastHit2D hit;
        if (movingRight)
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(-.4f, 0f), -transform.up, hitLength, DefaultTerrainLayerMask);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position + new Vector3(.4f, 0f), -transform.up, hitLength, DefaultTerrainLayerMask);
        }
       // RaycastHit2D rightHit = Physics2D.Raycast(transform.position + transform.right * 1f, -transform.up, 1f, DefaultTerrainLayerMask);
        if (hit && !hit.collider.isTrigger && hit.transform.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            
                iceWalk = true;
                moving = false;
                if (!isGrounded)
                {
                    isGrounded = true;
                }
                
                
        }
        else if (hit && hit.collider.isTrigger && bs.spawn != null && hit.collider == bs.spawn.GetComponent<Collider2D>())
        {
            if (isGrounded)
            {
                
                isGrounded = true;
            }
        }

        else if (hit && hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            
            isGrounded = true;
            if (started)
            {
                moving = true;
                Debug.Log("Hit ground");
            }
        }
        else
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
            iceWalk = false;
        }
        if (isGrounded)
        {
            anim.SetBool("falling", false);
        }
        else
        {
            if (myRB.velocity.y > 1f || myRB.velocity.y < -1f)
            {
                anim.SetBool("falling", true);
            }
        }

        if (movingRight)
        {
            Debug.DrawRay(transform.position, -transform.up * hitLength, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * hitLength, Color.green);
        }
        //Debug.DrawRay(transform.position + -transform.right * 1f, -transform.up * 1f, Color.green);


        //if moving left
       /* if (!movingRight)
        {
            RaycastHit2D overrideLeftHitInfo = Physics2D.Raycast(transform.position, -transform.right, 1f, DefaultTerrainLayerMask);
            
            if (overrideLeftHitInfo)
            {
                leftHit = overrideLeftHitInfo;
            }
        }
        //if moving right
        else
        {
            RaycastHit2D overrideRightHitInfo = Physics2D.Raycast(transform.position, transform.right, 1f, DefaultTerrainLayerMask);


            if (overrideRightHitInfo)
            {
                rightHit = overrideRightHitInfo;
            }

        }*/

        if (hit && !hit.collider.isTrigger)
        {

            Vector3 averageNormal = hit.normal;
            Debug.Log(averageNormal);
            Vector3 averagePoint = hit.point;
            
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);
           if (iceWalk)
           {
               transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);
           }
           else
           {
               transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);
           }
            

        }
        else
        {
            
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 6f);
            
           
                transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);
            
        }


        /*  RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1.2f, layerMask);

          if (hit && hit.transform.tag == "Ground" || hit && hit.transform.tag == "SmallBlock" || hit && hit.transform.tag == "MediumBlock" || hit && hit.transform.tag == "LongBlock")
          {
              Debug.Log(hit.transform);
              if (!hit.collider.isTrigger)
              {
                  isGrounded = true;
              }
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
          }*/
    }
    void FixedUpdate()
    {
        if (myRB.velocity.x > 0)
        {
            anim.SetFloat("speed", myRB.velocity.x);
        }
        else if (myRB.velocity.x < 0)
        {
            anim.SetFloat("speed", -myRB.velocity.x);
        }

        if (!vl.win)
        {
            if (!iceWalk)
            {
                if (!moving)
                {
                    Vector3 newVel = myRB.velocity;
                    myRB.velocity = newVel;

                    
                }
                if (moving && movingRight)
                {
                    myRB.velocity = new Vector2(speed * Time.deltaTime, myRB.velocity.y);
                }
                else if (moving && !movingRight)
                {
                    myRB.velocity = new Vector2(-speed * Time.deltaTime, myRB.velocity.y);
                }
            }
            else
            {
                if (iceWalk && myRB.velocity.x > 0 && myRB.velocity.y < 0)
                {
                    moving = false;
                    myRB.AddForce(new Vector2(speed * 2 * Time.deltaTime, myRB.velocity.y));
                }
                else if (iceWalk && myRB.velocity.x > 0 && myRB.velocity.y > 0)
                {
                    Vector3 newVel = myRB.velocity;
                    myRB.velocity = newVel;
                }
                else if (iceWalk && myRB.velocity.x < 0 && movingRight && myRB.velocity.y < 0)
                {
                    moving = false;
                    myRB.AddForce(new Vector2(-speed * Time.deltaTime, myRB.velocity.y));
                }
                else if (iceWalk && myRB.velocity.x < 0 && myRB.velocity.y > 0)
                {
                    Vector3 newVel = myRB.velocity;
                    myRB.velocity = newVel;
                }
                
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("trappe'd");
            Debug.Log("gaemover");
            Destroy(collision.gameObject);
            vl.lose = true;
        }
       /* if (collision.gameObject.layer == LayerMask.NameToLayer("Ice") && !iceWalk && !hit)
        {
            iceWalk = true;
        }*/
        
    }
   /* void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice") && !iceWalk)
        {
            iceWalk = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice") && iceWalk)
        {
            iceWalk = false;
        }
    }*/




}
