using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoundsCheck))]
public class ProjectileHero : MonoBehaviour
{
    private BoundsCheck boundsCheck;
    private Renderer rend;

    [Header("Dynamic")]
    public Rigidbody rb;
    [SerializeField] private eWeaponType _type;

    // public property masks private field _type
    public eWeaponType type
    {
        get { return _type; }
        set { SetType(value); }
    }

    void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boundsCheck.LocIs(BoundsCheck.eScreenLocs.offUp))
        {
            Destroy(gameObject);
        }
    }

    public void SetType(eWeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GET_WEAPON_DEFINITION(_type);
        rend.material.color = def.projectileColor;
    }

    public Vector3 vel
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }
}
