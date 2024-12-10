using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIdeOS : MonoBehaviour
{
    // Kąt maksymalnego wychylenia
    public float maxAngle = 45f;
    // Szybkość oscylacji
    public float speed = 2f;
    public bool Inne = false,inverse=false;
    // Początkowy obrót
    private Quaternion startRotation;

    void Start()
    {
        // Zapisz początkowy obrót
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle;
        if(!inverse) { 
        // Oblicz wychylenie w aktualnym momencie
         angle = maxAngle * Mathf.Sin(Time.time * speed);
        }
        else
        {
          angle = maxAngle * -Mathf.Sin(Time.time * speed);
        }

        if (Inne)
        {
            // Oblicz nowy obrót
            Quaternion pendulumRotation = Quaternion.Euler(0, angle, 0);
            // Połącz początkowy obrót z ruchem wahadłowym
            transform.rotation = startRotation * pendulumRotation;
        }
        else
        {
            // Oblicz nowy obrót
            Quaternion pendulumRotation = Quaternion.Euler(0, 0, angle);
            // Połącz początkowy obrót z ruchem wahadłowym
            transform.rotation = startRotation * pendulumRotation;
        }
    
    }
}

