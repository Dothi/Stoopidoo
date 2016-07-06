using UnityEngine;
using System.Collections;

public class LoadScreenAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public Sprite[] sprittes;
    int i;
    public float frameRate = 1;
    private float frameTimer = 0;
    private byte curFrame = 0;
    private SpriteRenderer myRend;

    void Start()
    {
        i = Random.Range(0, 2);
        myRend = GetComponent<SpriteRenderer>();
        frameTimer = GetFrameTime();
        if (i == 0)
            myRend.sprite = sprites[0];
        if (i == 1)
            myRend.sprite = sprittes[0];
    }

    void Update()
    {
        Debug.Log(i);
        frameTimer -= Time.deltaTime;
        if (i == 0)
        {
            if (frameTimer <= 0)
            {
                frameTimer = GetFrameTime() + frameTimer;
                curFrame++;
                if (curFrame >= sprites.Length) { curFrame = 0; }
                myRend.sprite = sprites[curFrame];
            }
        }
        if (i == 1)
        {
            if (frameTimer <= 0)
            {
                frameTimer = GetFrameTime() + frameTimer;
                curFrame++;
                if (curFrame >= sprittes.Length) { curFrame = 0; }
                myRend.sprite = sprittes[curFrame];
            }
        }
    }

    private float GetFrameTime()
    {
        return 1 / frameRate;
    }
}
