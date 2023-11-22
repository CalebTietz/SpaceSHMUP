using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationsPerSec = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;

    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        int currLevel = Hero.S.shieldLevel;
        if(levelShown != currLevel)
        {
            levelShown = currLevel;
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }

        float rZ = -(rotationsPerSec * Time.time * 360f) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
