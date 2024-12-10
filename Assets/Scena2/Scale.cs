using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Określenie prędkości zmiany skali obiektu
    public float speed = 0.33f;

    // Minimalna skala obiektu
    public float minScale = 0.1f;
    // Minimalna skala obiektu
    public float maxScale = 1f;

    // Zmienna przechowuje informację, czy obiekt aktualnie rośnie czy maleje. Jeżeli obiekt maleje, to przyjmuje wartość true
    private bool small = false;

    void Update()
    {
        // Odczytanie aktualnej skali obiektu
        Vector3 s = transform.localScale;

        // Określenie o ile ma zmienić się skala z uwzględnieniem czasu jaki upłynął od wyrysowania ostatniej klatki
        float scale = speed * Time.deltaTime;

        // Sprawdzenie czy aktualnie obiekt maleje czy rośnie
        if (small)
        {
            // Zmniejszanie wartości współrzędnych wektora określającego skalę obiektu (operacja mnożenia wektora przez skalar)
            s = s * (1 - scale);
            // Sprawdzenie czy obiekt uzyskał minimalną skalę. Założono, że skala obiektu we wszystkich trzech osiach jest taka sama, stąd wystarczy sprawdzić tylko s.x
            if (s.x <= minScale)
            {
                // Wpisanie minimalnej skali jako skali obiektu (na wypadek gdyby wyliczona skala była mniejsza)
                s.x = minScale;
                s.y = minScale;
                s.z = minScale;
                // Zaznaczenie, że od tego momentu obiekt będzie rosnąć
                small = false;
            }
        }
        else
        {
            // Zwiększenie wartości współrzędnych wektora określającego skalę obiektu (operacja mnożenia wektora przez skalar)
            s = s * (1 + scale);
            // Sprawdzenie czy obiekt uzyskał maksymalną skalę
            if (s.x >= maxScale)
            {
                // Wpisanie maksymalnej skali jako skali obiektu (na wypadek gdyby wyliczona skala była większa)
                s.x = maxScale;
                s.y = maxScale;
                s.z = maxScale;
                // Zaznaczenie, że od tego momentu obiekt będzie maleć
                small = true;
            }
        }

        // Zaktualizowanie skali obiektu
        transform.localScale = s;
    }
}