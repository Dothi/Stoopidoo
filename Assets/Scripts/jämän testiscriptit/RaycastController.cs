using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    //Tämä classi hoitaa raycastien sijoittelut + vaatii että liikuteltavalla hahmolla on boxCollider

    public LayerMask collisionMask; //Layer johon törmätään, esim Ground

    public const float skinWidth = .015f; //pieni offsetti
    public int horizontalRayCount = 4; //Vaakatason raycastien määrä, korkeammalla boxcolliderilla enemmän
    public int verticalRayCount = 4; //pystytason raycastit

    [HideInInspector]
    public float horizontalRaySpacing; //raycastien erotukset, ei tarvitse välittää
    [HideInInspector]
    public float verticalRaySpacing;

    [HideInInspector]
    public BoxCollider2D boxCollider; //boxCollider joka tulee automaattisesti
    public RaycastOrigins raycastOrigins; //Strukti josta saadaan tietoa

    public virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing(); //Lasketaan raycastien erotukset
    }

    public void UpdateRaycastOrigins()
    {
        //Päivitetään raycastien aloituspisteet, aluksi haetaan boxcolliderin reunat, tehdään siitä hitusen suurempi että pelaaja ei oikeasti ole kiinni palikoissa, ja asetetaan arvot struktiin
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing()
    {
        //Lasketaan raycastien välit
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    //Strukti josta saadaan raycastien aloituspisteet
    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}