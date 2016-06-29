using UnityEngine;
using System.Collections;

public class MoveCameraMobile : MonoBehaviour
{
    public Transform player;
    public Transform goal;
    int pOffset = 7;
    int gOffset = 7;
    public float speed = 1f;

    public float rightBound;
    public float leftBound;

    private float minX;
    private float maxX;

    private SpriteRenderer spriteBounds;
    Vector3 pos;
    Vector3 goalPos;
    void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        spriteBounds = GameObject.Find("Background").GetComponent<SpriteRenderer>();

        leftBound = (float)horzExtent - spriteBounds.sprite.bounds.size.x / 2f;
        rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - horzExtent);

        pos.z = transform.position.z;
        goalPos.z = transform.position.z;
    }
    void Update()
    {
        /*pos.x = player.position.x + pOffset;
        goalPos.x = goal.position.x - gOffset;*/
        
        float posX = Mathf.Clamp(transform.position.x, leftBound, rightBound);

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !BlockSpawner.instance.isDragging)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            
            transform.Translate(-touchDeltaPosition.x * Time.deltaTime * speed, 0, 0);

        }

       /* if (transform.position.x < player.position.x + pOffset)
        {
            transform.position = pos;
        }
        if (transform.position.x > goal.position.x - gOffset)
        {
            transform.position = goalPos;
        }*/
    }

   
}




