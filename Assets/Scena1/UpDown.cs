using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float speed = 2;

    public float minX = -3;

    public float maxX = 3;
    Vector3 v;
   
    private bool left = false;
    [SerializeField]  bool local = false;
    void Update()
    {
        if (!local) { 
        v = transform.position;
        }
        else
        {
        v = transform.localPosition;
        }
        float sx = speed * Time.deltaTime;

        if (left)
        {
            v.y = v.y - sx;
            if (v.y <= minX)
            {
                v.y = minX;
                left = false;
            }
        }
        else
        {
            v.y = v.y + sx;
            if (v.y >= maxX)
            {
                v.y = maxX;
                left = true;
            }
        }

        if (!local)
        {
            transform.position = v;
        }
        else
        {
            transform.localPosition = v;
        }
    }
}