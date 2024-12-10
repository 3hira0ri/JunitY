using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject9 : MonoBehaviour
{
    private float alphaX, alphaY, alphaZ;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string name = player.name;
        float angle = 2 * Time.deltaTime;
        alphaX = alphaX + angle + 10;
        if (name == "Bot (8)")
        {      
            player.transform.rotation = Quaternion.Euler(alphaX, 0, 0);
        }else if (name == "Bot (9)")
        {
            player.transform.rotation = Quaternion.Euler(0, alphaX, 0);
        }else if (name == "Bot (10)")
        {
            player.transform.rotation = Quaternion.Euler(0, 0, alphaX);
        }

    }
}
