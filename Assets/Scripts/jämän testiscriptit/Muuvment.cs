using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Muuvment : MonoBehaviour
{
    //muuttujia
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 5;
    int inputX = 1;
    float gravity;
    Vector3 velocity;
    float velocityXSmoothing;

    CharacterController controller;
    SpriteRenderer spriteRend;
    Vector2 input; //AIlle tämmöinen inputtijuttu
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        //asetetaan muuttujia
        controller = GetComponent<CharacterController>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        input.x = 1;
    }

    void Update()
    {
        if (controller.collisions.right || controller.collisions.left) { inputX *= -1;}
        if (inputX != 0)
        {
            input.x = inputX;
            if(inputX == 1)
            {
                //spriteRend.flipX = false;
                Debug.Log("1");
            }
            else if(inputX == -1)
            {
                //spriteRend.flipX = true;
                Debug.Log("2");
            }
        }


        //muuttuja velocitylle, joka halutaan saavuttaa
        float targetVelocityX = input.x * moveSpeed;
        //asetetaan nopeus pehmeästi unityn smoothdamp:n avulla
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        //päivitetään velocityä painovoimalla
        velocity.y += gravity * Time.deltaTime;

        //liikutetaan velocityn perusteella
        controller.Move(velocity * Time.deltaTime, input);
        if (controller.collisions.above || controller.collisions.below)
        { velocity.y = 0; }
    }
}