using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    void Start()
    {
        v = transform.position;
    }
    Vector3 v;

    // Określenie prędkości przemieszczania się obiektu
    public float speed = 2;
    private float alphaX, alphaY, alphaZ;
    bool startk = false;
    // Update is called once per frame
    void Update()
    {
       
        v = transform.position;
        // Określenie drogi przebytej przez obiekt podczas ruchu na podstawie jego prędkości i czasu jaki upłynął od wyrysowania ostatniej klatki
        float sz = speed * Time.deltaTime;
        // Odczytanie aktualnego położenia obiektu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startk = true;
        }
    if(startk)
        {
            v.x = v.x - sz * 1;
            
        }
/*       
 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            v.y = v.y + sz*-1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            v.y = v.y - sz * -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = v.x - sz * -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = v.x + sz * -1;
        }
        if (Input.GetKey(KeyCode.G))
        {
            v.z = v.z - sz * -1;
        }
        if (Input.GetKey(KeyCode.H))
        {
            v.z = v.z + sz * -1;
        }*/
    }
    void FixedUpdate()
    {
        transform.position = v;
    }
}
