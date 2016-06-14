using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    int smallBlocks;
    int mediumBlocks;
    int largeBlocks;

    public Transform[] prefabs;

    private Transform spawn;
    private Rect[] rect = { new Rect(50, 310, 100, 50), new Rect(160, 310, 110, 50), new Rect(280, 310, 100, 50) };

    void Start()
    {
        smallBlocks = 2;
        mediumBlocks = 1;
        largeBlocks = 1;
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && spawn != null)
        {
            var pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            spawn.transform.position = Camera.main.ScreenToWorldPoint(pos);

            
        }

        if (Input.GetMouseButtonUp(0))
        {
            spawn.GetComponent<BoxCollider2D>().enabled = true;
            spawn = null;
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
            largeBlocks--;
        }

        GUI.Button(rect[0], "Small block x" + smallBlocks);
        GUI.Button(rect[1], "Medium block x" + mediumBlocks);
        GUI.Button(rect[2], "Large block x" + largeBlocks);
    }
}
