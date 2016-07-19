using UnityEngine;
using System.Collections;

public class Darude : MonoBehaviour {
    public float rayLength = 5f;
    public int verticalRayCount = 4;
    public int horizontalRayCount = 4;
    const float skinWidth = .015f;

    float verticalRaySpacing;
    float horizontalRaySpacing;
    BoxCollider2D boxCollider;
    RaycastOrigins raycastOrigins;

	// Use this for initialization
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
	void Start () {
        calculateRaySpacing();
	}
	
	// Update is called once per frame
	void Update () {
        raycast();
        UpdateRaycastOrigins();
        calculateRaySpacing();
	}
    void raycast()
    {
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.bottomMiddle;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            Debug.DrawRay(rayOrigin, Vector2.up * -rayLength, Color.red);
        }
        for (int j = 0; j < verticalRayCount; j++)
        {
            Vector2 rayOrigin = raycastOrigins.topMiddle;
            rayOrigin += Vector2.right * (verticalRaySpacing * j);
            Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);
        }

    }
    public void calculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
    public void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);
        //raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);        
        //raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        //raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);        
        //raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        raycastOrigins.bottomMiddle = new Vector2(bounds.center.x, bounds.min.y);
        raycastOrigins.topMiddle = new Vector2(bounds.center.x, bounds.max.y);
        raycastOrigins.leftMiddle = new Vector2(bounds.min.x, bounds.center.y);
        raycastOrigins.rightMiddle = new Vector2(bounds.max.x, bounds.center.y);
    }
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
        public Vector2 bottomMiddle, topMiddle;
        public Vector2 leftMiddle, rightMiddle;
    }
}
