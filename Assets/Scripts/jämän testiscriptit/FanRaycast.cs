using UnityEngine;
using System.Collections;
public class FanRaycast : MonoBehaviour
{
    public float rayLength = 5f;
    public Transform player;
    public int verticalRayCount = 4;
    Vector3 velocity;
    float verticalRaySpacing;
    float horizontalRaySpacing;
    int horizontalRayCount;
    [HideInInspector]
    public BoxCollider2D boxcollider; //boxCollider joka tulee automaattisesti
    public RaycastOrigins raycastOrigins; //Strukti josta saadaan tietoa
    float distance = 0;
    float maxDistance;
    float percent;
    public const float skinWidth = .015f; //pieni offsetti
    // Use this for initialization
    void Start()
    {
        asdRaycastOrigins();
        CalculateRaySpacing();
        Debug.Log(verticalRayCount);
        //velocity = transform.position;
        //float directionY = Mathf.Sign(velocity.y);
        raycast();
    }

    void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        raycast();
    }

    void raycast()
    {
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            distance = Vector2.Distance(transform.position, rayOrigin);
            percent = (distance / maxDistance) * 5;
            rayLength -= percent;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength);
            Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);
            if (hit && hit.transform.tag == "Player")
            {
                Debug.Log(hit.collider.name);
                velocity.y = 50 * Time.deltaTime;
                velocity.x = player.GetComponent<Rigidbody2D>().velocity.x;
                player.GetComponent<Rigidbody2D>().velocity = velocity;
            }
            rayLength += percent;
        }
    }
    void asdRaycastOrigins()
    {
        Bounds bounds = boxcollider.bounds;
        bounds.Expand(skinWidth * 2);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        maxDistance = Vector2.Distance(raycastOrigins.topLeft, raycastOrigins.topRight);
    }

    public void CalculateRaySpacing()
    {
        //Lasketaan raycastien välit
        Bounds bounds = boxcollider.bounds;
        bounds.Expand(skinWidth * 2);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
    //Strukti josta saadaan raycastien aloituspisteet
    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
    }
}
