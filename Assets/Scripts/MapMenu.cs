using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMenu : MonoBehaviour
{

    public List<GameObject> levels;

    void Start()
    {
        levels = new List<GameObject>();

        var levelObjects = GameObject.FindGameObjectsWithTag("Level");
        var levelCount = levelObjects.Length;

        System.Array.Reverse(levelObjects);

        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (!levels.Contains(levelObjects[i]))
            {
                levels.Add(levelObjects[i]);
            }
        }
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (ray && ray.collider == levels[0].GetComponent<CircleCollider2D>())
            {
                Debug.Log("jee");
                Application.LoadLevel("JonnaTest");
            }
        }

    }
}
