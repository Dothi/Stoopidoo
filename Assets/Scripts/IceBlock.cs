using UnityEngine;
using System.Collections;

public class IceBlock : MonoBehaviour {

    GameObject player;
    Rigidbody2D playerRB;
    Movement playerMovement;

    public bool touchesIce;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        if (touchesIce)
        {
            playerMovement.iceWalk = true;
        }
        /*else
        {
            playerMovement.iceWalk = false;
        }*/
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("osu");
            if (!touchesIce)
            {
                touchesIce = true;
            }
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("osu");
            if (!touchesIce)
            {
                touchesIce = true;
            }
        }
    }
    /*void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            touchesIce = false;
        }
    }*/
}
