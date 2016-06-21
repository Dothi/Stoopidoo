using UnityEngine;
using System.Collections;

public class CharacterController : RaycastController
{
    //Structi collisioninfo josta saadaan, noh, collisioninfoo
    public CollisionInfo collisions;
    [HideInInspector]
    //public Vector2 moveInput; //Input jonka perusteella liikutaan

    public override void Start()
    {
        //Startataan myös RaycastController, alussa katsotaan oikealle
        base.Start();
        collisions.faceDir = 1;
    }

    public void Move(Vector3 velocity, Vector2 input)
    {
        UpdateRaycastOrigins(); //Päivitetään raycastien aloitukset
        collisions.Reset(); //Nollataan collisionit
        collisions.velocityOld = velocity; //Laitetaan velocity talteen

        //Asetetaan faceDir, eli minne pelaaja katsoo
        if (velocity.x != 0)
        { collisions.faceDir = (int)Mathf.Sign(velocity.x); }

        HorizontalCollisions(ref velocity); //Tarkistetaan vaakatason collisiot

        //Jos velocity ei ole 0, tarkistetaan pystysuunnan collisiot
        if (velocity.y != 0)
        { VerticalCollisions(ref velocity); }

        //Liikutetaan pelaajaa
        transform.Translate(velocity);
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        //suunta
        float directionX = collisions.faceDir;
        //rayn pituus
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        //säädetään rayn pituutta
        if (Mathf.Abs(velocity.x) < skinWidth)
        { rayLength = 2 * skinWidth; }

        //loopataan horizontal raycastit läpi
        for (int i = 0; i < horizontalRayCount; i++)
        {
            //asetetaan raycastien aloituspiste direction mukaan, asetetaan suunta ja tallennetaan raycastin osuma talteen
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            //piirretään debugray
            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

            //jos osutaan
            if (hit)
            {
                //if (hit.distance == 0) { continue; }
                //velocity X asettaminen osuman ja suunnan perusteella
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance; //rayn asettaminen

                //collisioiden asettaminen
                collisions.left = directionX == -1;
                collisions.right = directionX == 1;
            }
        }
    }

    //Pystycollisiot
    void VerticalCollisions(ref Vector3 velocity)
    {
        //Ysuunta + rayn pituus
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        //loopataan rayt läpi
        for (int i = 0; i < verticalRayCount; i++)
        {
            //mistä raycast aloitetaan + suunta ja osuman tallentaminen
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red); //debug piirto

            //ja jos osutaan, säädellään velocityä
            if (hit)
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }
    }

    //structi josta saadaan tietoa
    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public Vector3 velocityOld;
        public int faceDir;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }

}