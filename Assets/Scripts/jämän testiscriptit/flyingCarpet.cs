using UnityEngine;
using System.Collections;

public class flyingCarpet : MonoBehaviour {

    public float verticalRayLength = 5;
    public float horizontalRayLength = 5;
    public float speed = 1f;
    public int distance;
    LayerMask layermask;
    LayerMask playermask;
    public Vector3 endpos;
    public Vector3 playerpos;
    public GameObject Player;
    public bool up, down, left, right, moving, playerMove, moved;
    int upcount, downcount, leftcount, rightcount = 0;
    public float timer;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        layermask = 1 << LayerMask.NameToLayer("Hurricane");
        playermask = 1 << LayerMask.NameToLayer("Player");
        up = false;
        down = false;
        left = false;
        right = false;
        playerMove = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (!playerMove)
        {
            Movement.instance.moving = false;
            Movement.instance.anim.SetFloat("speed", 0);
        }
        //if(moving)
        //{
        //    timer += Time.deltaTime;
        //    if(timer >= 3)
        //    {
        //        Movement.instance.moving = true;
        //    }
        //}
        RaycastHit2D uphit;
        RaycastHit2D downhit;
        RaycastHit2D lefthit;
        RaycastHit2D righthit;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.up, verticalRayLength, playermask);
        uphit = Physics2D.Raycast(transform.position, Vector2.up, verticalRayLength, layermask);
        downhit = Physics2D.Raycast(transform.position, Vector2.down, verticalRayLength, layermask);
        lefthit = Physics2D.Raycast(transform.position, Vector2.left, horizontalRayLength, layermask);
        righthit = Physics2D.Raycast(transform.position, Vector2.right, horizontalRayLength, layermask);
        Debug.DrawRay(transform.position, Vector2.up * verticalRayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * verticalRayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * horizontalRayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * horizontalRayLength, Color.red);
        if(hit && !moved)
        {
            //Movement.instance.moving = false;
            playerMove = false;
            timer += Time.deltaTime;
            if(timer >= 3 && !moving)
            {
                playerMove = true;
                Movement.instance.moving = true;
            }
        }
        if(uphit)
        {
            //Movement.instance.moving = false;
            playerMove = false;
            if (!down)
            {
               
                endpos = transform.position;
                endpos.y += -distance;
                playerpos = Player.transform.position;
                playerpos.y += -distance;
                Debug.Log("Ylhäältä osu");
                moving = true;
            }
            
            down = true;
        }
        if (downhit)
        {
            //Movement.instance.moving = false;
            playerMove = false;
            if (!up)
            {
                
                endpos = transform.position;
                endpos.y += distance;
                playerpos = Player.transform.position;
                playerpos.y += distance;
                Debug.Log("alhaalta osu");
                moving = true;
            }
            
            up = true;
        }
        if (lefthit)
        {
            //Movement.instance.moving = false;
            playerMove = false;
            if (!right)
            {
                
                endpos = transform.position;
                endpos.x += distance;
                playerpos = Player.transform.position;
                playerpos.x += distance;
                Debug.Log("vasemmalta osu");
                moving = true;
            }
            
            right = true;
        }
        if (righthit)
        {
            //Movement.instance.moving = false;
            playerMove = false;
            
            if (!left)
            {
                
                endpos = transform.position;
                endpos.x += -distance;
                playerpos = Player.transform.position;
                playerpos.x += -distance;
                Debug.Log("oikeelta osu");
                moving = true;
            }
            
            
            left = true;
        }
        if(down && downcount < 1) { movingDown(); }
        if(up && upcount < 1) { movingUp(); }
        if(right && rightcount < 1) { movingRight(); }
        if(left && leftcount < 1) { movingLeft(); }
    }
    void movingUp()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, playerpos, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            upcount = 1;
            up = false;
            moving = false;
            playerMove = true;
            Movement.instance.moving = true;
            moved = true;
        }
    }
    void movingDown()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, playerpos, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            downcount = 1;
            down = false; moving = false;
            playerMove = true;
            Movement.instance.moving = true;
            moved = true;
        }
    }
    void movingRight()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, playerpos, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if (transform.position == endpos)
        {
            rightcount = 1;
            right = false; moving = false;
            playerMove = true;
            Movement.instance.moving = true;
            moved = true;
        }
    }
    void movingLeft()
    {
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, playerpos, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            leftcount = 1;
            left = false; moving = false;
            playerMove = true;
            Movement.instance.moving = true;
            moved = true;
        }
    }
}
