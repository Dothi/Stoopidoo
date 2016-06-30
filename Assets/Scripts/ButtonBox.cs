using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonBox : MonoBehaviour
{

    public GameObject player;
    public List<GameObject> rotatingBlocks = new List<GameObject>();

    bool Rotating;

    //TODO: Make block rotate also clockwise

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
            if (temp > 90)
            {
                Rotating = false;
                temp = 0f;
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
        }
    }
    void RotateBlocks()
    {


        for (int i = 0; i < rotatingBlocks.Count; i++)
        {
            Vector3 destination = new Vector3(0, 0, 90);
            Vector3 fromRot = rotatingBlocks[i].transform.eulerAngles;

            rotatingBlocks[i].transform.eulerAngles += Vector3.Lerp(transform.rotation.eulerAngles, destination, Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            //RotateBlocks();
            Rotating = true;
        }
    }
}
