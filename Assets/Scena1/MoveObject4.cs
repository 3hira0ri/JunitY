using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject4 : MonoBehaviour
{
    // Określenie prędkości przemieszczania się obiektu
    public float speed = 2;

    // Minimalna wartość współrzędnej x, do której obiekt może się przemieścić, potem musi zawrócić
    public float minX = -3;
    // Maksymalna wartość współrzędnej x, do której obiekt może się przemieścić, potem musi zawrócić
    public float maxX = 3;
    public float minY = -3;
    // Maksymalna wartość współrzędnej x, do której obiekt może się przemieścić, potem musi zawrócić
    public float maxY = 3;
    // Zmienna przechowuje aktualny kierunek ruchu. Jeżeli obiekt porusza się w lewo, to przyjmuje wartość true
    private bool left = false;
    private bool gora = false;
    void Update()
    {
        // Odczytanie aktualnego położenia obiektu
        Vector3 v = transform.position;

        // Określenie drogi przebytej przez obiekt podczas ruchu na podstawie jego prędkości i czasu jaki upłynął od wyrysowania ostatniej klatki
        float sx = speed * Time.deltaTime;
        float sy = speed * Time.deltaTime;
        // Sprawdzenie kierunku ruchu obiektu
        if (left)
        {
            // Jeżeli obiekt ma poruszać się w lewo, to wartość współrzędnej x położenia obiektu jest zmniejszana
            v.x = v.x - sx;
            // Sprawdzenie czy obiekt dotarł do lewej granicy obszaru, po którym się porusza
            if (v.x <= minX)
            {
                // Wpisanie położenia lewej granicy jako współrzędnej x obiektu (na wypadek gdyby był już za tą granicą)
                v.x = minX;
                // Zmiana kierunku ruchu na w prawo
                left = false;
            }
        }
        else
        {
            // Jeżeli obiekt ma poruszać się w prawo, to wartość współrzędnej x położenia obiektu jest zwiększana
            v.x = v.x + sx;
            // Sprawdzenie czy obiekt dotarł do prawej granicy obszaru, po którym się porusza
            if (v.x >= maxX)
            {
                // Wpisanie położenia prawej granicy jako współrzędnej x obiektu (na wypadek gdyby był już za tą granicą)
                v.x = maxX;
                // Zmiana kierunku ruchu na w lewo
                left = true;
            }
        }
        // Sprawdzenie kierunku ruchu obiektu
        if (gora)
        {
            // Jeżeli obiekt ma poruszać się w lewo, to wartość współrzędnej x położenia obiektu jest zmniejszana
            v.y = v.y - sy;
            // Sprawdzenie czy obiekt dotarł do lewej granicy obszaru, po którym się porusza
            if (v.y <= minY)
            {
                // Wpisanie położenia lewej granicy jako współrzędnej x obiektu (na wypadek gdyby był już za tą granicą)
                v.y = minY;
                // Zmiana kierunku ruchu na w prawo
                gora = false;
            }
        }
        else
        {
            // Jeżeli obiekt ma poruszać się w prawo, to wartość współrzędnej x położenia obiektu jest zwiększana
            v.y = v.y + sy;
            // Sprawdzenie czy obiekt dotarł do prawej granicy obszaru, po którym się porusza
            if (v.y >= maxY)
            {
                // Wpisanie położenia prawej granicy jako współrzędnej x obiektu (na wypadek gdyby był już za tą granicą)
                v.y = maxY;
                // Zmiana kierunku ruchu na w lewo
                gora = true;
            }
        }
        // Zaktualizowanie położenia obiektu
        transform.position = v;
    }
}