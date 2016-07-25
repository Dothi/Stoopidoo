using UnityEngine;
using System.Collections;

public class DeleteSavesInEditor : MonoBehaviour
{

    public bool deleteSaves;

    void Start()
    {
        deleteSaves = false;
    }
    void Update()
    {
        if (deleteSaves)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
