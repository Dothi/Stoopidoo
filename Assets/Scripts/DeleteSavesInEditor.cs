using UnityEngine;
using System.Collections;

public class DeleteSavesInEditor : MonoBehaviour
{

    public bool deleteSaves;
    GameManager gm;

    void Start()
    {
        deleteSaves = false;
        gm = GetComponent<GameManager>();
    }
    void Update()
    {
        if (deleteSaves)
        {
            PlayerPrefs.DeleteAll();
            gm.firstUnlock = false;
        }
    }
}
