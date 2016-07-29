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
            case 10:
                indexes[0].GetComponent<Image>().sprite = indexSprites[10];
                break;
            case 9:
                indexes[0].GetComponent<Image>().sprite = indexSprites[9];
                break;
            case 8:
                indexes[0].GetComponent<Image>().sprite = indexSprites[8];
                break;
            case 7:
                indexes[0].GetComponent<Image>().sprite = indexSprites[7];
                break;
            case 6:
                indexes[0].GetComponent<Image>().sprite = indexSprites[6];
                break;
            case 5:
                indexes[0].GetComponent<Image>().sprite = indexSprites[5];
                break;
            case 4:
                indexes[0].GetComponent<Image>().sprite = indexSprites[4];
                break;
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
            case 10:
                indexes[1].GetComponent<Image>().sprite = indexSprites[10];
                break;
            case 9:
                indexes[1].GetComponent<Image>().sprite = indexSprites[9];
                break;
            case 8:
                indexes[1].GetComponent<Image>().sprite = indexSprites[8];
                break;
            case 7:
                indexes[1].GetComponent<Image>().sprite = indexSprites[7];
                break;
            case 6:
                indexes[1].GetComponent<Image>().sprite = indexSprites[6];
                break;
            case 5:
                indexes[1].GetComponent<Image>().sprite = indexSprites[5];
                break;
            case 4:
                indexes[1].GetComponent<Image>().sprite = indexSprites[4];
                break;
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
            case 10:
                indexes[2].GetComponent<Image>().sprite = indexSprites[10];
                break;
            case 9:
                indexes[2].GetComponent<Image>().sprite = indexSprites[9];
                break;
            case 8:
                indexes[2].GetComponent<Image>().sprite = indexSprites[8];
                break;
            case 7:
                indexes[2].GetComponent<Image>().sprite = indexSprites[7];
                break;
            case 6:
                indexes[2].GetComponent<Image>().sprite = indexSprites[6];
                break;
            case 5:
                indexes[2].GetComponent<Image>().sprite = indexSprites[5];
                break;
            case 4:
                indexes[2].GetComponent<Image>().sprite = indexSprites[4];
                break;
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
