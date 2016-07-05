using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour
{

    public int smallBlocks;
    public int mediumBlocks;
    public int longBlocks;

    public int blocksUsed;
    public float speed;
    public float friction;
    public float lerpSpeed;
    public float xDeg;
    public float yDeg;
    Quaternion fromRotation;
    Quaternion toRotation;

    public bool isRotating = false;
    public bool isDragging = false;
    public bool isHit = false;
    public static BlockSpawner instance;
    public Transform[] prefabs;

    Vector3 newPos;
    Vector3 mousePos;
    Vector3 GOpos;
    Vector3 offset;
    
    public GameObject confirmButton;
    public GameObject cancelButton;
    public GameObject restartButton;
    public Touch[] myTouches;
    public Transform spawn;
    public Rect[] rect;
    public float oldAngle;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {

    }
    void Update()
    {
        myTouches = Input.touches;
        if (myTouches.Length > 0)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(myTouches[0].position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            if (myTouches[0].phase == TouchPhase.Began && restartButton.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Restart();
            }
            if (spawn != null)
            {
                isDragging = true;

                var pos = new Vector3(myTouches[0].position.x, myTouches[0].position.y, -Camera.main.transform.position.z);
                // pos.z = -Camera.main.transform.position.z;




                if (myTouches[0].phase == TouchPhase.Began && spawn.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    Debug.Log("hit");
                    isHit = true;
                    offset = spawn.transform.position - Camera.main.ScreenToWorldPoint(pos);

                }
                if (myTouches[0].phase == TouchPhase.Began && cancelButton.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    Cancel();
                }
                if (myTouches[0].phase == TouchPhase.Began && confirmButton.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    Confirm();
                }

                if (myTouches[0].phase == TouchPhase.Ended)
                {
                    isHit = false;
                }
                if (isHit)
                {
                    spawn.transform.position = Camera.main.ScreenToWorldPoint(pos) + offset;
                }

                if (myTouches.Length == 2)
                {
                    Rotate();
                }
                else if (myTouches.Length == 1 && !isHit && isDragging && myTouches[0].phase == TouchPhase.Moved)
                {
                    Rotate();
                }
                else
                {
                    StopRotate();
                }
                if (isRotating)
                {
                    
                        /*newPos = spawn.transform.position;
                        spawn.transform.position = newPos;*/
                        if (myTouches.Length == 2)
                        {
                            /*mousePos = new Vector3(myTouches[1].position.x, myTouches[1].position.y, 10);*/
                            
                            var v2 = myTouches[0].position - myTouches[1].position;
                            var newAngle = Mathf.Atan2(v2.y, v2.x);
                           // var deltaAngle = Mathf.DeltaAngle(newAngle, spawn.transform.rotation.z);
                            
                           // oldAngle = newAngle;
                            
                            spawn.transform.rotation = Quaternion.EulerAngles(0f, 0f, newAngle);
                            
                        }
                        else if (myTouches.Length == 2 && isHit)
                        {
                             
                        
                            /*mousePos = new Vector3(myTouches[1].position.x, myTouches[1].position.y, 10);*/
                            
                            var v2 = myTouches[0].position - myTouches[1].position;
                            var newAngle = Mathf.Atan2(v2.y, v2.x);
                           // var deltaAngle = Mathf.DeltaAngle(newAngle, spawn.transform.rotation.z);
                            
                           // oldAngle = newAngle;
                            
                            spawn.transform.rotation = Quaternion.EulerAngles(0f, 0f, newAngle);
                        }
                        else
                        {
                            /*mousePos = new Vector3(myTouches[0].position.x, myTouches[0].position.y, 10);
                            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
                            lookPos = lookPos - spawn.transform.position;
                            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                            spawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
                        }
                      /*  Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
                        lookPos = lookPos - spawn.transform.position;
                        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
                        spawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

                    
                    
                }
            }


        }
        
        /*else
        {
            isDragging = false;
        }*/
        if (!isDragging)
        {

            Debug.Log("sad");
            if (spawn != null)
            {
                offset = Vector3.zero;
            }
            spawn = null;
        }
        if (isDragging)
        {
            confirmButton.SetActive(true);
            cancelButton.SetActive(true);
            spawn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }
        else
        {
            confirmButton.SetActive(false);
            cancelButton.SetActive(false);
        }
    }
    public void Rotate()
    {
        
            isRotating = true;
        
    }
    public void StopRotate()
    {
        isRotating = false;
    }
    public void SmallBlock()
    {
        if (smallBlocks > 0 && spawn == null)
        {
            var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[0], pos, Quaternion.identity) as Transform;
            smallBlocks--;
            blocksUsed++;
        }
    }
    public void MediumBlock()
    {
        if (mediumBlocks > 0 && spawn == null)
        {
            var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[1], pos, Quaternion.identity) as Transform;
            mediumBlocks--;
            blocksUsed++;
        }
    }
    public void LongBlock()
    {
        if (longBlocks > 0 && spawn == null)
        {
            var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            spawn = Instantiate(prefabs[2], pos, Quaternion.identity) as Transform;
            longBlocks--;
            blocksUsed++;
        }
    }

    public void Confirm()
    {
        if (!isHit)
        {
            isDragging = false;
            spawn.GetComponent<Collider2D>().isTrigger = false;
            spawn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            spawn = null;
        }

    }
    public void Cancel()
    {
        if (!isHit)
        {
            isDragging = false;

            if (spawn.tag == "SmallBlock")
            {
                smallBlocks++;
            }
            if (spawn.tag == "MediumBlock")
            {
                mediumBlocks++;
            }
            if (spawn.tag == "LongBlock")
            {
                longBlocks++;
            }
            blocksUsed--;
            Destroy(spawn.gameObject);
            spawn = null;
        }
    }

    public void Restart()
    {
        if (!isHit)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    
    void OnGUI()
    {
        /*Event e = Event.current;

         if (e.type == EventType.MouseDown && rect[0].Contains(e.mousePosition) && smallBlocks > 0)
         {
             var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
             pos = Camera.main.ScreenToWorldPoint(pos);
             spawn = Instantiate(prefabs[0], pos, Quaternion.identity) as Transform;
             smallBlocks--;
             blocksUsed++;
         }
         if (e.type == EventType.MouseDown && rect[1].Contains(e.mousePosition) && mediumBlocks > 0)
         {
             var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
             pos = Camera.main.ScreenToWorldPoint(pos);
             spawn = Instantiate(prefabs[1], pos, Quaternion.identity) as Transform;
             mediumBlocks--;
             blocksUsed++;
         }
         if (e.type == EventType.MouseDown && rect[2].Contains(e.mousePosition) && longBlocks > 0)
         {
             var pos = Input.touches[0].position;
            // pos.z = -Camera.main.transform.position.z;
             pos = Camera.main.ScreenToWorldPoint(pos);
             spawn = Instantiate(prefabs[2], pos, Quaternion.identity) as Transform;
             longBlocks--;
             blocksUsed++;
         }*/


        /*GUI.Button(rect[0], "Small block x" + smallBlocks);
        GUI.Button(rect[1], "Medium block x" + mediumBlocks);
        GUI.Button(rect[2], "Long block x" + longBlocks);*/


    }


}

