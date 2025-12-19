using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDirectedJump : MonoBehaviour
{
    public float a;
    public static float b;
    public float c;
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (a + 0.7 >= Time.time)
        {
            b = 1;
        }
        else if (a + 0.7 <= Time.time)
        {
            b = 0;
        }
        if (b == 1)
        {
            rb.gravityScale = 1;
        }
        Debug.Log(b);
    }
    void OnCollisionStay2D(Collision2D other)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "Byeok" && b == 0)
        {
            a = Time.time;
            rb.gravityScale = 0;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "byeok" && a + 0.7 <= Time.time)
        {
            b = 0;
        }
        
    }
    
}