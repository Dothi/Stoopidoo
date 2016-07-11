using UnityEngine;
using System.Collections;

public class blockCollision : MonoBehaviour
{
    GameObject player;
    public bool hitPlayer;
    public bool placed;

    public SpriteRenderer spriteRend;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hitPlayer && !placed)
        {
            spriteRend.color = new Color(1f, 0f, 0f, 0.4f);
        }
        else if (!hitPlayer && !placed)
        {
            spriteRend.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>() && !placed)
        {
            hitPlayer = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>() && !placed)
        {
            hitPlayer = false;
        }
    }
}
