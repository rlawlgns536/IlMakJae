using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectedJump : MonoBehaviour
{
    public static float b; // 1이면 중력 끔, 0이면 중력 켬

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // b가 1이면 중력 끔, 0이면 중력 켬
        rb.gravityScale = (b == 1) ? 0 : 1;

        Debug.Log(b);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Byeok")
        {
            b = 1; // 벽에 닿아있으면 중력 끔
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Byeok")
        {
            b = 0; // 벽에서 떨어지면 중력 켬
        }
    }
}
