using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 10f; // movement speed in m/s
    public float fireRate = 0.3f; // seconds/shot
    public float health = 10f; // Hit points needed to destroy enemy
    public int score = 100; // Points earned for destroying enemy

    protected BoundsCheck boundsCheck;
    void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(boundsCheck.LocIs(BoundsCheck.eScreenLocs.offDown))
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        
        if(otherGO.GetComponent<ProjectileHero>() != null)
        {
            Destroy(otherGO);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }
}
