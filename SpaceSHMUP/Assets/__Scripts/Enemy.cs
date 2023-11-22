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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
