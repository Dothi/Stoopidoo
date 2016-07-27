using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonBox : MonoBehaviour
{

    public GameObject player;
    public List<GameObject> rotatingBlocks = new List<GameObject>();


    public bool Rotating;

    //TODO: Make block rotate also clockwise
    // public bool clockWise;

    float temp = 0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var rotatingblocks = GameObject.FindGameObjectsWithTag("RotatingBlock");
        foreach (var block in rotatingblocks)
        {
            rotatingBlocks.Add(block);
        }




    }
    void Update()
    {

        if (Rotating)
        {
            for (int i = 0; i < rotatingBlocks.Count; i++)
            {
                //disable colliders
                Collider2D[] colliders = rotatingBlocks[i].GetComponentsInChildren<BoxCollider2D>();
                foreach (var collider in colliders)
                {
                    collider.isTrigger = true;
                }

            }
            if (temp > 90)
            {
                Rotating = false;
                temp = 0f;
                Debug.Log(rotatingBlocks[0].transform.eulerAngles.z);
            }
            else
            {


                RotateBlocks();
                float rotationVal = Mathf.Lerp(0, 90f, Time.deltaTime);
                temp += rotationVal;
            }
        }
        else
        {


            for (int i = 0; i < rotatingBlocks.Count; i++)
            {

                if (rotatingBlocks[i].GetComponent<RotatingBoxRotation>().clockWise)
                {
                    if (rotatingBlocks[i].transform.eulerAngles.z > 271)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z < 90 && rotatingBlocks[i].transform.eulerAngles.z > 0)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z < 180 && rotatingBlocks[i].transform.eulerAngles.z > 91)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z < 270 && rotatingBlocks[i].transform.eulerAngles.z > 181)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 270);
                    }

                    
                   
                }


                else
                {

                    if (rotatingBlocks[i].transform.eulerAngles.z < 90)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z > 90 && rotatingBlocks[i].transform.eulerAngles.z < 180)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 90);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z > 180 && rotatingBlocks[i].transform.eulerAngles.z < 270)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                    else if (rotatingBlocks[i].transform.eulerAngles.z > 270)
                    {
                        rotatingBlocks[i].transform.eulerAngles = new Vector3(0, 0, 270);
                    }
                }

                //enable colliders
                Collider2D[] colliders = rotatingBlocks[i].GetComponentsInChildren<BoxCollider2D>();
                foreach (var collider in colliders)
                {
                    collider.isTrigger = false;
                }
            }
        }
    }
    void RotateBlocks()
    {
        for (int i = 0; i < rotatingBlocks.Count; i++)
        {
            if (rotatingBlocks[i].GetComponent<RotatingBoxRotation>().clockWise)
            {
                Vector3 destination = new Vector3(0, 0, -90);
                Vector3 fromRot = rotatingBlocks[i].transform.eulerAngles;

                rotatingBlocks[i].transform.eulerAngles += Vector3.Lerp(transform.rotation.eulerAngles, destination, Time.deltaTime);
            }
            else
            {
                Vector3 destination = new Vector3(0, 0, 90);
                Vector3 fromRot = rotatingBlocks[i].transform.eulerAngles;

                rotatingBlocks[i].transform.eulerAngles += Vector3.Lerp(transform.rotation.eulerAngles, destination, Time.deltaTime);
            }
        }
    }
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Rotating = true;
    //    }
    //}
}
