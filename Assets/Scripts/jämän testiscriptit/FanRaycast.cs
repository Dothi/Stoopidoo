using UnityEngine;
using System.Collections;

public class FanRaycast : RaycastController {
    float rayLength = 5f;
    public Transform player;
    Vector3 velocity;
    // Use this for initialization
    public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, rayLength);
            Debug.DrawRay(transform.position, Vector2.up * rayLength, Color.red);

            if (hit && hit.transform.tag == "Player")
            {
                velocity.y = 100 * Time.deltaTime;
                velocity.x = player.GetComponent<Rigidbody2D>().velocity.x;
                player.GetComponent<Rigidbody2D>().velocity = velocity;
            }
            else if (hit)
            {
                rayLength = hit.distance;
            }
        }
	}
}
