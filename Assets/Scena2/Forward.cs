using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward2 : MonoBehaviour
{
    public float speed = 2;

    public float minZ = -3;
    public float maxZ = 3;

    private bool przod = false;

    void Update()
    {
        Vector3 v = transform.localPosition;

        float sz = speed * Time.deltaTime;

        if (przod)
        {
            v.z = v.z - sz;
            if (v.z <= minZ)
            {
                v.z = minZ;
                przod = false;
            }
        }
        else
        {
            v.z = v.z + sz;
            if (v.z >= maxZ)
            {
                v.z = maxZ;

                przod = true;
            }
        }

        transform.localPosition = v;
    }
}