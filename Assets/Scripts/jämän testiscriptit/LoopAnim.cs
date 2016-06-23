using UnityEngine;
using System.Collections;

public class LoopAnim : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameRate = 1;
    private float frameTimer = 0;
    private byte curFrame = 0;
    private SpriteRenderer myRend;

    void Start()
    {
        myRend = GetComponent<SpriteRenderer>();
        frameTimer = GetFrameTime();
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0)
        {
            frameTimer = GetFrameTime() + frameTimer;
            curFrame++;
            if (curFrame >= sprites.Length) { curFrame = 0; }
            myRend.sprite = sprites[curFrame];
        }
    }

    private float GetFrameTime()
    {
        return 1 / frameRate;
    }
}
