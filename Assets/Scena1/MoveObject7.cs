using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
    }
    Vector3 v,s ;
    // Określenie prędkości przemieszczania się obiektu
    public float speed = 2;
    private float alphaX,alphaY,alphaZ;
    // Update is called once per frame
    void Update()
    {
        v = transform.position;
        s = transform.localScale;
        // Określenie drogi przebytej przez obiekt podczas ruchu na podstawie jego prędkości i czasu jaki upłynął od wyrysowania ostatniej klatki
        float sz = speed * Time.deltaTime;
        float scale = speed * Time.deltaTime;
        float angle = speed * Time.deltaTime;
        // Odczytanie aktualnego położenia obiektu

        if (Input.GetKey(KeyCode.W))
        {
            v.y = v.y + sz;
        }
        if (Input.GetKey(KeyCode.S))
        {
            v.y = v.y - sz;
        }
        if (Input.GetKey(KeyCode.D))
        {
            v.x = v.x - sz;
        }
        if (Input.GetKey(KeyCode.A))
        {
            v.x = v.x + sz;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            v.z = v.z - sz;
        }
        if (Input.GetKey(KeyCode.E))
        {
            v.z = v.z + sz;
        }
        if (Input.GetKey(KeyCode.B))
        {
            s *= (1 + scale);
            transform.localScale = s;
        }
        if (Input.GetKey(KeyCode.L))
        {
            s *= (1 - scale);
            transform.localScale = s;
        }
        if (Input.GetKey(KeyCode.X))
        {
            alphaX = alphaX + angle+10;
        }
        if (Input.GetKey(KeyCode.Y))
        {
            alphaY = alphaY + angle + 10;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            alphaZ = alphaZ + angle + 10;
        }
    }
    void FixedUpdate()
    {
        transform.position = v;
        transform.rotation = Quaternion.Euler(alphaX, alphaY, alphaZ);
    }
}
