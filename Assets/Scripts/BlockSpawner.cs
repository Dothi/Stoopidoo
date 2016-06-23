﻿using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    public int smallBlocks;
    public int mediumBlocks;
    public int longBlocks;

    public int blocksUsed;
    public float speed;
    public float friction;
    public float lerpSpeed;
    public float xDeg;
    public float yDeg;
    Quaternion fromRotation;
    Quaternion toRotation;

    public bool isRotating = false;
    public bool isDragging = false;
    public static BlockSpawner instance;
    public Transform[] prefabs;
    
    
    public Touch[] myTouches;
    public Transform spawn;
    private Rect[] rect = { new Rect(Screen.width / 2 - Screen.width / 2 + 50, Screen.height / 2 + 260, 100, 50), new Rect(Screen.width / 2 - Screen.width / 2 + 150, Screen.height / 2 + 260, 110, 50), new Rect(Screen.width / 2 - Screen.width / 2 + 260, Screen.height / 2 + 260, 100, 50) };

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        myTouches = Input.touches;

        if (myTouches.Length > 0 && spawn != null)
        {
            var pos = new Vector3(myTouches[0].position.x, myTouches[0].position.y, -Camera.main.transform.position.z);
            // pos.z = -Camera.main.transform.position.z;

            if (isRotating)
            {
                Vector3 newPos = spawn.transform.position;
                spawn.transform.position = newPos;
                Vector3 mousePos = new Vector3(myTouches[0].position.x, myTouches[0].position.y, 10);
                Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
                lookPos = lookPos - spawn.transform.position;
                float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                spawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
            else
            {
                spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);
            }
            isDragging = true;

            
        }
        else
        {
            isDragging = false;
        }
        if (myTouches.Length < 1)
        {
            Debug.Log("sad");
            if (spawn != null)
            {
                spawn.GetComponent<BoxCollider2D>().enabled = true;
            }
            spawn = null;
        }  
    }
    public void Rotate()
    {
        isRotating = true;
    }
    public void StopRotate()
    {
        isRotating = false;
    }

    void OnGUI()
    {
       Event e = Event.current;

        if (e.type == EventType.MouseDown && rect[0].Contains(e.mousePosition) && smallBlocks > 0)
        {
            var pos = Input.touches[0].position;
           // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[0], pos, Quaternion.identity) as Transform;
            smallBlocks--;
            blocksUsed++;
        }
        if (e.type == EventType.MouseDown && rect[1].Contains(e.mousePosition) && mediumBlocks > 0)
        {
            var pos = Input.touches[0].position;
           // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[1], pos, Quaternion.identity) as Transform;
            mediumBlocks--;
            blocksUsed++;
        }
        if (e.type == EventType.MouseDown && rect[2].Contains(e.mousePosition) && longBlocks > 0)
        {
            var pos = Input.touches[0].position;
           // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[2], pos, Quaternion.identity) as Transform;
            longBlocks--;
            blocksUsed++;
        }
        

        GUI.Button(rect[0], "Small block x" + smallBlocks);
        GUI.Button(rect[1], "Medium block x" + mediumBlocks);
        GUI.Button(rect[2], "Long block x" + longBlocks);
    }
    
    
}

