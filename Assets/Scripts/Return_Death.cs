using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Death : MonoBehaviour
{
    public static float a = 0;
    public static float b = 0.5f;
    public static float c = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            JumpGumsa.jumpstate = 0;
            transform.position = new Vector3(a, b, c);
        }
    }
}
