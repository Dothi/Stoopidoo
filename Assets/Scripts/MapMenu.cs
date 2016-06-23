using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMenu : MonoBehaviour
{

    public List<GameObject> levels;

    void Start()
    {
        levels = new List<GameObject>();

        for (int i = 1; i <= 5; i++)
        {
            levels.Add(GameObject.Find("Level_" + i));
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
