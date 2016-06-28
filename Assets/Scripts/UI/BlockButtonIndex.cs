using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockButtonIndex : MonoBehaviour
{
    public Sprite[] indexSprites;
    BlockSpawner bs;
    public GameObject[] indexes;
    void Start()
    {
        bs = GameObject.FindGameObjectWithTag("BlockSpawner").GetComponent<BlockSpawner>();
    }
    void Update()
    {
        HandleIndexes();
    }
    void HandleIndexes()
    {
        switch (bs.smallBlocks)
        {
            case 3:
                indexes[0].GetComponent<Image>().sprite = indexSprites[3];
                break;
            case 2:
                indexes[0].GetComponent<Image>().sprite = indexSprites[2];
                break;
            case 1:
                indexes[0].GetComponent<Image>().sprite = indexSprites[1];
                break;
            case 0:
                indexes[0].GetComponent<Image>().sprite = indexSprites[0];
                break;
        }
        switch (bs.mediumBlocks)
        {
            case 3:
                indexes[1].GetComponent<Image>().sprite = indexSprites[3];
                break;
            case 2:
                indexes[1].GetComponent<Image>().sprite = indexSprites[2];
                break;
            case 1:
                indexes[1].GetComponent<Image>().sprite = indexSprites[1];
                break;
            case 0:
                indexes[1].GetComponent<Image>().sprite = indexSprites[0];
                break;
        }
        switch (bs.longBlocks)
        {
            case 3:
                indexes[2].GetComponent<Image>().sprite = indexSprites[3];
                break;
            case 2:
                indexes[2].GetComponent<Image>().sprite = indexSprites[2];
                break;
            case 1:
                indexes[2].GetComponent<Image>().sprite = indexSprites[1];
                break;
            case 0:
                indexes[2].GetComponent<Image>().sprite = indexSprites[0];
                break;
        }

    }
}
