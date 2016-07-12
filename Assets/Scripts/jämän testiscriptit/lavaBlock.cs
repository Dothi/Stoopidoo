using UnityEngine;
using System.Collections;

public class lavaBlock : MonoBehaviour {

    bool destroying;
    Animator anim;
    public BoxCollider2D box;
    BoxCollider2D boxi;
    BoxCollider2D parentBox;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        destroying = false;
        anim = GetComponent<Animator>() as Animator;
        anim.enabled = false;
        boxi = GetComponentInChildren<BoxCollider2D>();
        parentBox = GetComponentInParent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("SADF");
            rb.isKinematic = false;
            destroying = true;
            anim.enabled = true;
            box.enabled = false;
        }
        if(collision.gameObject.tag == "LoseBlock")
        {
            Destroy(gameObject);
        }
    }
}
