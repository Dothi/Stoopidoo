using UnityEngine;
using System.Collections;

public class ButtonBoxCollision : MonoBehaviour
{
    ButtonBox bb;

    void Start()
    {
        bb = GameObject.FindGameObjectWithTag("ButtonBoxController").GetComponent<ButtonBox>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ButtonBox")
        {
            bb.Rotating = true;
        }
    }
}
