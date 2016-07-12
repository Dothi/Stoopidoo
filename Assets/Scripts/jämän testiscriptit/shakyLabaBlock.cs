using UnityEngine;
using System.Collections;

public class shakyLabaBlock : MonoBehaviour {

    bool up;
    bool shaking;
    public float ShakeY = 0.8f;
    public float ShakeYSpeed = 0.8f;
    public Transform lavaBlock;
    Vector2 newPosition;
	// Use this for initialization
	void Start () {
        shaking = false;
       
	}




    //public void setShake(float someY)
    //{
    //    ShakeY = someY;
    //}

    void Update()
    {
        if (shaking)
        {
            //newPosition = new Vector2(lavaBlock.position.x, lavaBlock.position.y + ShakeY);
            newPosition = new Vector2(0, ShakeY);
            if (ShakeY > 0)
            {
                ShakeY *= ShakeYSpeed;
            }
            ShakeY = -ShakeY;
            lavaBlock.Translate(newPosition, Space.Self);
         
        }
    }



    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            shaking = true;
       
        }
    }

}
