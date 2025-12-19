using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerpos = transform.position;
        float playerx = transform.position.x;
        float playery = transform.position.y;
        float playerz = transform.position.z;
        Vector2 Gumsapos = transform.position;
        float gumx = transform.position.x;
        float gumy = transform.position.y;
        float gumz = transform.position.z;
        gumx = playerx;
        playery = gumy;
    }
}
