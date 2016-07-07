﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIFadeScript : MonoBehaviour
{

    public List<Image> uiImages = new List<Image>();
    BlockSpawner bs;
    MoveCameraMobileTest cameraScript;

    float fadeTime = 5f;
    float currentTime;
    float alphaTime;

    void Start()
    {
        bs = GameObject.FindGameObjectWithTag("BlockSpawner").GetComponent<BlockSpawner>();
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCameraMobileTest>();
        currentTime = 0f;
        alphaTime = 1f;
        var gos = GameObject.FindGameObjectsWithTag("UI");

        foreach (var go in gos)
        {
            uiImages.Add(go.GetComponent<Image>());
        }
    }

    void Update()
    {
        if (Input.touchCount == 0 && !bs.isDragging)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= fadeTime)
            {
                

                if (alphaTime <= .4f)
                {
                    alphaTime = .4f;
                }
                else
                {
                    alphaTime -= Time.deltaTime * .75f;
                }
                for (int i = 0; i < uiImages.Count; i++)
                {
                    uiImages[i].color = new Color(1f, 1f, 1f, alphaTime);
                }

            }
            
        }
        else if (bs.isDragging || cameraScript.followDoge)
        {
            currentTime = 0f;
            alphaTime = 1f;
            for (int i = 0; i < uiImages.Count; i++)
            {
                uiImages[i].color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
