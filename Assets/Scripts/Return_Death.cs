using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            transform.position = new Vector3(0f, 0.5f, 0f);
        }
    }
}
