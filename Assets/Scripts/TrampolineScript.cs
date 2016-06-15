using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour
{

    public float jumpForce = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
    }
}


