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

        for (int i = 0; i < levelObjects.Length; i++ )
        {
            if(!levels.Contains(levelObjects[i]))
            levels.Add(levelObjects[i]);
        }
    }
}
