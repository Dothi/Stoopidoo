﻿using UnityEngine;
using System.Collections;

public class cameramenu : MonoBehaviour
{

    ///The background image to use
    public Transform Area;

    //Sprite details
    private Sprite Sprite;
    private float PixelUnits;
    private Vector2 Size;
    private Vector2 Offset;
    public Vector3 startpos;
    public Vector3 endpos;
    public bool buttonpressed;
    //Camera bounds
    private float Left;
    private float Right;
    private float Top;
    private float Bottom;
    private float MaxZoom;
    private float MinZoom;
    public float speed = 2;

    public void Start()
    {
        Sprite = Area.transform.GetComponent<SpriteRenderer>().sprite;

        CalculatePixelUnits();
        CalculateSize();
        Refresh();
        if (GameManager.instance.continued)
        {
            transform.position = GameManager.instance.camPos;
        }
        // Center();
    }

    //Calculate the pixel per unit value is for this sprite
    private void CalculatePixelUnits()
    {
        PixelUnits = Sprite.rect.width / Sprite.bounds.size.x;
    }

    //Calculate the size and offset of the background sprite
    private void CalculateSize()
    {
        Size = new Vector2(Area.transform.localScale.x * Sprite.texture.width / PixelUnits,
                            Area.transform.localScale.y * Sprite.texture.height / PixelUnits);

        Offset = Area.transform.position;
    }

    //Get zoom constraints, and zoom as large as possible for current view
    private void Refresh()
    {
        //calculate current screen ratio
        float w = Screen.width / Size.x;
        float h = Screen.height / Size.y;
        float ratio = w / h;
        float ratio2 = h / w;
        if (ratio2 > ratio)
        {
            MaxZoom = (Size.y / 2);
        }
        else
        {
            MaxZoom = (Size.y / 2);
            MaxZoom /= ratio;
        }

        MinZoom = 1;
        //Camera.main.orthographicSize = MaxZoom;

        RefreshBounds();
    }

    //Position the camera at the center of the background image
    private void Center()
    {
        //set camera to center of background image
        Vector2 position = Area.transform.position;
        Vector3 camPosition = position;
        Vector3 point = Camera.main.WorldToViewportPoint(camPosition);
        Vector3 delta = camPosition - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = destination;
    }

    //Calculate the max distance the camera can travel
    private void RefreshBounds()
    {
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        Left = horzExtent - Size.x / 2.0f + Offset.x;
        Right = Size.x / 2.0f - horzExtent + Offset.x;
        Bottom = vertExtent - Size.y / 2.0f + Offset.y;
        Top = Size.y / 2.0f - vertExtent + Offset.y;
    }

    public void Update()
    {
        //You would typically hook into Refresh on a screen rotation or aspect ratio change
        //In demo, we call it non stop to demonstrate the camera system 
        Refresh();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !BlockSpawner.instance.isDragging)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * Time.deltaTime * speed, 0, 0);
            GameManager.instance.camPos = transform.position;
        }
        //if (Input.GetMouseButton(0))
        //{
        //    transform.Translate(new Vector3(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * 10, 0, 0));
        //    GameManager.instance.camPos = transform.position;
        //}
    }

    public void LateUpdate()
    {
        //Clamp camera inside of our bounds
        Vector3 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, Left, Right);
        v3.y = Mathf.Clamp(v3.y, Bottom, Top);
        transform.position = v3;
    }
}