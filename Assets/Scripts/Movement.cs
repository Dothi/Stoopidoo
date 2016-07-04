﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRB;
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
    VictoryLose vl;
    public LayerMask DefaultTerrainLayerMask;

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
        timer = 0f;
        moving = false;
        movingRight = true;
        isTouchingWall = false;
        isGrounded = false;
        spriteRend = GetComponent<SpriteRenderer>();
        idleTimer = 0f;
        layerMask = 1 << LayerMask.NameToLayer("Player");


        layerMask = ~layerMask;
        vl = GetComponent<VictoryLose>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!moving)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 5 && !moving)
        {
            Debug.Log(timer);
            moving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !moving)
        {
            Debug.Log("jloj");
            moving = true;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 1f, DefaultTerrainLayerMask);
       // RaycastHit2D rightHit = Physics2D.Raycast(transform.position + transform.right * 1f, -transform.up, 1f, DefaultTerrainLayerMask);

        Debug.DrawRay(transform.position, -transform.up * 1f, Color.green);
       // Debug.DrawRay(transform.position + -transform.right * 1f, -transform.up * 1f, Color.green);


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

        if (hit)
        {
            
            

            Vector3 averageNormal = hit.normal;
            Debug.Log(averageNormal);
            Vector3 averagePoint = hit.point;
            Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, averageNormal);
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 4f);
           
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 10f * Time.deltaTime);

        }
        
        
        
        else
        {
            
            Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 4f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, finalRotation.eulerAngles.z), 10f * Time.deltaTime);
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
            if (moving && movingRight)
            {
                myRB.velocity = new Vector2(speed * Time.deltaTime, myRB.velocity.y);
            }
            else if (moving && !movingRight)
            {
                myRB.velocity = new Vector2(-speed * Time.deltaTime, myRB.velocity.y);
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
    }




}
