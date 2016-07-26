using UnityEngine;
using System.Collections;

public class ButtonBoxCollision : MonoBehaviour
{
    ButtonBox bb;

    public bool rotated;

    void Start()
    {
        bb = GameObject.FindGameObjectWithTag("ButtonBoxController").GetComponent<ButtonBox>();
        rotated = false;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ButtonBox" && !rotated)
        {
            bb.Rotating = true;
            rotated = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ButtonBox" && rotated)
        {
            
            rotated = false;
        }
    }
}
