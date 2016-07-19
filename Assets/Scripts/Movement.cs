using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float speed = 50f;
    public float fan = 1f;
    float boostTimer = 0f;
    float hitLength;
    float timer;
    public float idleTimer;
    public bool moving;
    public bool isGrounded;
    public bool movingRight;
    public bool isTouchingWall;
    public bool iceWalk;
    bool jumped;
    bool hitForward;
    bool started;
    RaycastHit2D hit;
    SpriteRenderer spriteRend;
    LayerMask layerMask;
    LayerMask UIlayerMask;
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

        layerMask = 1 << LayerMask.NameToLayer("Player");
        UIlayerMask = 1 << LayerMask.NameToLayer("UI");

        layerMask = ~layerMask;
        UIlayerMask = ~UIlayerMask;
        vl = GetComponent<VictoryLose>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.pauseState)
        {
            RaycastHit2D hit;
            RaycastHit2D hit2;
            RaycastHit2D groundHit;
            RaycastHit2D forwardHit;
            hit = Physics2D.Raycast(transform.position, -transform.up + transform.right, hitLength, DefaultTerrainLayerMask);
            hit2 = Physics2D.Raycast(transform.position, -transform.up + -transform.right, hitLength, DefaultTerrainLayerMask);


            if (movingRight)
            {
                groundHit = Physics2D.Raycast(transform.position + new Vector3(-.2f, 0), -transform.up, 1.2f, DefaultTerrainLayerMask);

                forwardHit = Physics2D.Raycast(transform.position, transform.right, 1.2f, DefaultTerrainLayerMask);

            }
            else
            {
                groundHit = Physics2D.Raycast(transform.position + new Vector3(.2f, 0), -transform.up, 1.2f, DefaultTerrainLayerMask);

                forwardHit = Physics2D.Raycast(transform.position, -transform.right, 1.2f, DefaultTerrainLayerMask);

            }

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

                    if (moving && myRB.velocity.x == 0)
                    {

                        if (!forwardHit)
                        {

                            Debug.Log("cyka");
                            boostTimer += Time.deltaTime;
                            if (boostTimer > .2f)
                            {
                                Debug.Log("Blyat");
                                if (!jumped)
                                {
                                    myRB.AddForce(new Vector2(100, 100));
                                }

                                if (myRB.velocity.x == 0 && jumped)
                                {
                                    movingRight = false;
                                    jumped = false;
                                    boostTimer = 0f;

                                }
                                jumped = true;
                                boostTimer = 0f;

                            }

                        }
                        else
                        {
                            idleTimer += 10 * Time.deltaTime;
                            Debug.Log(idleTimer);
                            if (idleTimer >= 1f)
                            {
                                idleTimer = 0f;
                                movingRight = false;
                                jumped = false;

                            }
                        }


                    }
                }
                else
                {

                    spriteRend.flipX = true;

                    if (moving && myRB.velocity.x == 0)
                    {
                        if (!forwardHit)
                        {

                            Debug.Log("cyka");
                            boostTimer += Time.deltaTime;
                            if (boostTimer > .2f)
                            {
                                Debug.Log("Blyat");
                                if (!jumped)
                                {
                                    myRB.AddForce(new Vector2(-100, 100));
                                }

                                if (myRB.velocity.x == 0 && jumped)
                                {
                                    movingRight = true;
                                    boostTimer = 0f;

                                }
                                jumped = true;
                                boostTimer = 0f;

                            }

                        }
                        else
                        {
                            idleTimer += 10 * Time.deltaTime;
                            if (idleTimer >= 1f)
                            {
                                idleTimer = 0f;
                                movingRight = true;
                                jumped = false;

                            }
                        }

                    }
                }
            }
            if (!moving && !started)
            {
                uiManager.instance.CountDown.enabled = true;
                timer -= Time.deltaTime;
                Debug.Log(uiManager.instance.timerSprites.Length);
                uiManager.instance.CountDown.sprite = uiManager.instance.timerSprites[(int)timer];
            }
            if (timer <= 0 && !moving && !started)
            {
                Debug.Log(timer);
                uiManager.instance.CountDown.enabled = false;
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


            /*if (movingRight)
            {


            }*/
            /*else
            {
                hit = Physics2D.Raycast(transform.position + new Vector3(.4f, 0f), -transform.up, hitLength, DefaultTerrainLayerMask);
            }*/
            // RaycastHit2D rightHit = Physics2D.Raycast(transform.position + transform.right * 1f, -transform.up, 1f, DefaultTerrainLayerMask);
            if (groundHit && !groundHit.collider.isTrigger && groundHit.transform.gameObject.layer == LayerMask.NameToLayer("Ice"))
            {
                if (groundHit.transform.rotation.z != 0)
                {
                    iceWalk = true;
                    moving = false;
                    if (!isGrounded)
                    {
                        isGrounded = true;
                    }
                }
                else
                {
                    isGrounded = true;
                    moving = true;
                }
            }
            else if (groundHit && groundHit.collider.isTrigger && bs.spawn != null && groundHit.collider == bs.spawn.GetComponent<Collider2D>())
            {
                if (isGrounded)
                {

                    isGrounded = true;
                }
            }

            else if (groundHit && groundHit.transform.gameObject.layer == LayerMask.NameToLayer("Ground") || groundHit && groundHit.transform.gameObject.layer == LayerMask.NameToLayer("Block"))
            {

                isGrounded = true;
                if (started)
                {
                    moving = true;
                    Debug.Log("Hit ground");
                }
            }
            else if (!groundHit)
            {

                isGrounded = false;

                iceWalk = false;
            }
            if (isGrounded)
            {
                anim.SetBool("falling", false);
            }
            else
            {
                if (myRB.velocity.y > 2f || myRB.velocity.y < -2f)
                {

                    anim.SetBool("falling", true);

                }
            }


            Debug.DrawRay(transform.position, -transform.up + -transform.right * hitLength, Color.green);
            Debug.DrawRay(transform.position, -transform.up + transform.right * hitLength, Color.green);
            Debug.DrawRay(transform.position, -transform.up * hitLength, Color.green);
            if (movingRight)
            {
                Debug.DrawRay(transform.position, transform.right * 1.2f, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, -transform.right * 1.2f, Color.green);
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

            if (hit && hit2)
            {
                if (!hit.collider.isTrigger && !hit2.collider.isTrigger)
                {
                    if (!iceWalk)
                    {
                        if (hit.transform.rotation.z != transform.rotation.z && hit2.transform.rotation.z != transform.rotation.z)
                        {
                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            if (hit.collider.transform.gameObject.layer == LayerMask.NameToLayer("Ground") && hit2.collider.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 15f * Time.deltaTime);
                            }

                            else
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 15f * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {

                        {
                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);

                        }
                    }


                }
            }
            else if (hit && !hit2)
            {
                if (!hit.collider.isTrigger)
                {
                    if (!iceWalk)
                    {
                        if (hit.transform.rotation.z != transform.rotation.z)
                        {

                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            if (hit.collider.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 15f * Time.deltaTime);
                            }
                            else
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 15f * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {

                        {
                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);

                        }
                    }
                }
            }

            else if (hit2 && !hit)
            {
                if (!hit2.collider.isTrigger)
                {
                    if (!iceWalk)
                    {
                        if (hit2.transform.rotation.z != transform.rotation.z)
                        {
                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            if (hit2.collider.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 15f * Time.deltaTime);
                            }
                            else
                            {
                                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 15f * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {

                        {
                            Vector3 averageNormal = (hit.normal + hit2.normal) / 2;
                            Debug.Log(averageNormal);
                            Vector3 averagePoint = (hit.point + hit2.point) / 2;

                            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
                            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 6f);

                            transform.rotation = Quaternion.Euler(0, 0, finalRotation.eulerAngles.z);

                        }
                    }
                }

            }
            else
            {
                
                Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 4f);


                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 15f * Time.deltaTime);

            }
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


        if (!GameManager.instance.pauseState)
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
                    else if (iceWalk && movingRight && myRB.velocity == Vector2.zero)
                    {
                        myRB.AddForce(new Vector2(100, myRB.velocity.y));
                    }
                    else if (iceWalk && !movingRight && myRB.velocity == Vector2.zero)
                    {
                        myRB.AddForce(new Vector2(-100, myRB.velocity.y));
                    }


                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            anim.SetBool("dead", true);
            Debug.Log("trappe'd");
            Debug.Log("gaemover");
            // Destroy(collision.gameObject);
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
