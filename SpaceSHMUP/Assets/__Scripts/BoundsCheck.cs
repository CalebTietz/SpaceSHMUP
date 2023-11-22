using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public enum eType { center, inset, outset };

    [Header("Inscribed")]
    public eType boundsType = eType.center;
    public float radius = 1f;

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;

        Vector3 pos = transform.position;

        float hBound = camWidth + checkRadius;
        float vBound = camHeight + checkRadius;
        
        if(pos.x > hBound)
        {
            pos.x = hBound;
        }
        if(pos.x < -hBound)
        {
            pos.x = -hBound;
        }
        if(pos.y > vBound)
        {
            pos.y = vBound;
        }
        if(pos.y < -vBound)
        {
            pos.y = -vBound;
        }

        transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
