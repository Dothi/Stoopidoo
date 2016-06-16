using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    public int smallBlocks;
    public int mediumBlocks;
    public int longBlocks;

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

    private Transform spawn;
    private Rect[] rect = { new Rect(50, 310, 100, 50), new Rect(160, 310, 110, 50), new Rect(280, 310, 100, 50) };

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
    
    void Update()
    {
        
        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            if (Input.GetKey(KeyCode.Z) && spawn != null)
            {
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
            if (isRotating)
            {
                Vector3 newPos = spawn.transform.position;
                spawn.transform.position = newPos;
               /* xDeg -= Input.GetAxis("Mouse X") * speed * friction;
                yDeg += Input.GetAxis("Mouse Y") * speed * friction;
                fromRotation = spawn.transform.rotation;
                toRotation = Quaternion.Euler(0, 0, yDeg);
                spawn.transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);*/

                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
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
        if (Input.GetMouseButtonUp(0))
        {
            if (spawn != null)
            {
                spawn.GetComponent<BoxCollider2D>().enabled = true;
            }
            spawn = null;
            isDragging = false;
        }
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.MouseDown && rect[0].Contains(e.mousePosition) && smallBlocks > 0)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[0], pos, Quaternion.identity) as Transform;
            smallBlocks--;
        }
        if (e.type == EventType.MouseDown && rect[1].Contains(e.mousePosition) && mediumBlocks > 0)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[1], pos, Quaternion.identity) as Transform;
            mediumBlocks--;
        }
        if (e.type == EventType.MouseDown && rect[2].Contains(e.mousePosition) && largeBlocks > 0)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[2], pos, Quaternion.identity) as Transform;
            longBlocks--;
        }

        GUI.Button(rect[0], "Small block x" + smallBlocks);
        GUI.Button(rect[1], "Medium block x" + mediumBlocks);
        GUI.Button(rect[2], "Long block x" + longBlocks);
    }
}
