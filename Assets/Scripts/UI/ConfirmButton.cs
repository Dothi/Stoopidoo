using UnityEngine;
using System.Collections;

public class ConfirmButton : MonoBehaviour
{
    BlockSpawner bs;

    void Awake()
    {
        bs = GameObject.FindGameObjectWithTag("BlockSpawner").GetComponent<BlockSpawner>();
    }
    void Update()
    {
        
    }
    public void Confirm()
    {
        bs.isDragging = false;
        this.gameObject.SetActive(false);
    }
}
