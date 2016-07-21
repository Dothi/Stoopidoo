using UnityEngine;
using System.Collections;

public class flyingCarpet : MonoBehaviour {

    float rayLength = 5;
    public float speed = 1f;
    public int distance;
    LayerMask layermask;
    LayerMask playermask;
    public Vector3 endpos;
    public bool up, down, left, right;
    int upcount, downcount, leftcount, rightcount = 0;
    public float timer;
	// Use this for initialization
	void Start () {
        layermask = 1 << LayerMask.NameToLayer("Hurricane");
        playermask = 1 << LayerMask.NameToLayer("Player");
        up = false;
        down = false;
        left = false;
        right = false;
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D uphit;
        RaycastHit2D downhit;
        RaycastHit2D lefthit;
        RaycastHit2D righthit;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.up, rayLength, playermask);
        uphit = Physics2D.Raycast(transform.position, Vector2.up, rayLength, layermask);
        downhit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, layermask);
        lefthit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, layermask);
        righthit = Physics2D.Raycast(transform.position, Vector2.right, rayLength, layermask);
        Debug.DrawRay(transform.position, Vector2.up * rayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * rayLength, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * rayLength, Color.red);
        if(hit)
        {
            Movement.instance.moving = false;
            Movement.instance.anim.SetFloat("speed", 0);
            timer += Time.deltaTime;
            if(timer >= 3)
            {
                Movement.instance.moving = true;
            }
        }
        if(uphit)
        {
            
            if (!down)
            {
                endpos = transform.position;
                endpos.y += -distance;
                Debug.Log("Ylhäältä osu");
            }
            
            down = true;
        }
        if (downhit)
        {
            
            if (!up)
            {
                endpos = transform.position;
                endpos.y += distance;
                Debug.Log("alhaalta osu");
            }
            
            up = true;
        }
        if (lefthit)
        {
            
            if (!right)
            {
                endpos = transform.position;
                endpos.x += distance;
                Debug.Log("vasemmalta osu");
            }
            
            right = true;
        }
        if (righthit)
        {
            
            if(!left)
            {
                endpos = transform.position;
                endpos.x += -distance;
                Debug.Log("oikeelta osu");
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
        
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            upcount = 1;
            up = false;
        }
    }
    void movingDown()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            downcount = 1;
            down = false;
        }
    }
    void movingRight()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if (transform.position == endpos)
        {
            rightcount = 1;
            right = false;
        }
    }
    void movingLeft()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
        if(transform.position == endpos)
        {
            leftcount = 1;
            left = false;
        }
    }
}
