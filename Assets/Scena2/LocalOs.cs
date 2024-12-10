using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalOs : MonoBehaviour
{
    public int invert = 1;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(Vector3.up, speed * invert);

        
    }
}
